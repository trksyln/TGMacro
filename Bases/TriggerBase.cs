using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TGMacro.Actions;
using TGMacro.Interfaces;

namespace TGMacro.Bases
{
    public abstract class TriggerBase : IDisposable
    {
        private Enums.TriggerRunState _runState;
        public virtual Enums.TriggerRunState RunState
        {
            get => _runState;
            set
            {
                if (!IsEnable || !Statics.AppSession.Enable)
                {
                    _runState = Enums.TriggerRunState.Stop;
                }
                else
                {
                    _runState = value;
                }

                TriggerRunningStatusChanged?.Invoke();
            }
        }
        public Enums.TriggerTypes TriggerType;

        public delegate void StatusUpdate();
        public event StatusUpdate TriggerRunningStatusChanged;

        private bool _isEnable;

        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                _isEnable = value;
                if (!value)
                {
                    RunState = Enums.TriggerRunState.Stop;
                }
            }
        }


        public List<IMacroAction> Actions = new List<IMacroAction>();
        private Thread triggerThread;
        public TriggerBase()
        {
            InitiateThread();
        }

        private void InitiateThread()
        {
            triggerThread = new Thread(Watch)
            {
                IsBackground = true
            };
            triggerThread.Start();
        }

        public void Start()
        {
            if (triggerThread != null && triggerThread.IsAlive)
            {
                Stop();
            }
            else
            {
                InitiateThread();
            }
        }

        public void Stop()
        {
            if (TriggerRunningStatusChanged != null)
            {
                foreach (Delegate item in TriggerRunningStatusChanged.GetInvocationList())
                {
                    TriggerRunningStatusChanged -= (StatusUpdate)item;
                }
            }

            if (triggerThread != null && triggerThread.IsAlive)
            {
                triggerThread.Abort();
            }
        }

        public void Restart()
        {
            Stop();
            InitiateThread();
        }

        public void Watch()
        {
            while (true)
            {
                SpinWait.SpinUntil(() => IsEnable && Actions.Count > 0 && Statics.AppSession.Enable && RunState != Enums.TriggerRunState.Stop);

                int previousForIndex = -1;
                int forLoopCount = 999999;
                for (int i = 0; i < Actions.Count; i++)
                {
                    if (Actions[i].ActionType == Enums.ActionTypes.For)
                    {
                        forLoopCount = ((ForAction)Actions[i]).LoopCount;
                        previousForIndex = i;
                    }
                    else if (Actions[i].ActionType == Enums.ActionTypes.Loop && previousForIndex != -1)
                    {
                        forLoopCount--;
                        if (forLoopCount == 0)
                            continue;
                        i = previousForIndex;
                    }
                    else
                    {
                        Actions[i].DoJob();
                    }

                    if (RunState == Enums.TriggerRunState.Stop)
                    {
                        var downActions = Actions
                            .Where(m => m.ActionType == Enums.ActionTypes.KeyboardKey)
                            .Where(m => ((KeyboardKeyAction)m).KeyMethod == Enums.KeyPressMethods.Down);
                        foreach (KeyboardKeyAction action in downActions)
                        {
                            var upAction = new KeyboardKeyAction()
                            {
                                KeyboardKey = action.KeyboardKey,
                                KeyMethod = Enums.KeyPressMethods.Up
                            };
                            upAction.DoJob();
                        }
                        break;
                    }
                }

                if (RunState != Enums.TriggerRunState.Run)
                {
                    RunState = Enums.TriggerRunState.Stop;
                }

                Thread.Sleep(10);
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
