using System;
using System.Drawing;
using System.Threading;
using TGMacro.Enums;

namespace TGMacro.Triggers
{
    public class ColorTrigger : Bases.TriggerBase, IDisposable
    {
        public Enums.ColorTriggerMethods Method { get; set; }
        public Color Color { get; set; }
        public Point Pos { get; set; }

        public ColorTrigger()
        {
            base.TriggerType = Enums.TriggerTypes.Pixel;
            new Thread(watchColor)
            {
                IsBackground = true
            }.Start();
        }

        private void watchColor()
        {
            while (true)
            {
                if (!Statics.AppSession.Enable || !base.IsEnable)
                {
                    base.RunState = Enums.TriggerRunState.Stop;
                    Thread.Sleep(1);
                    continue;
                }
                if (getStatus && base.RunState != TriggerRunState.Run)
                {
                    base.RunState = TriggerRunState.Run;
                }
                else if (!getStatus && base.RunState != TriggerRunState.Stop)
                {
                    base.RunState = TriggerRunState.Stop;
                }

                Thread.Sleep(1);
            }
        }

        private bool getStatus => (Method == Enums.ColorTriggerMethods.ColorMatches && Statics.SharedMethods.GetColorAt(Pos) == Color) || (Method == Enums.ColorTriggerMethods.ColorNotMatches && Statics.SharedMethods.GetColorAt(Pos) != Color);


    }
}
