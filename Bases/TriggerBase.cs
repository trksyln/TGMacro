using System;
using System.Collections.Generic;
using System.Threading;
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
                _isEnable = value; if (!value)
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
                Restart();
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
                for (int i = 0; i < Actions.Count; i++)
                {
                    Actions[i].DoJob();
                    if (RunState == Enums.TriggerRunState.Stop)
                    {
                        break;
                    }
                }
                if (RunState != Enums.TriggerRunState.Run)
                {
                    RunState = Enums.TriggerRunState.Stop;
                }

                Thread.Sleep(1);
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
