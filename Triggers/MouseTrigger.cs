
using CSInputs.ReadInput;
using CSInputs.Structs;
using System;

namespace TGMacro.Triggers
{
    public class MouseTrigger : Bases.TriggerBase, IDisposable
    {
        public Enums.TriggerKeyMethods Method { get; set; }
        public bool HasPrimary => PrimaryKey != CSInputs.Enums.KeyboardKeys.None;
        public CSInputs.Enums.KeyboardKeys PrimaryKey { get; set; }
        public CSInputs.Enums.MouseKeys SecondaryKey { get; set; }

        public MouseTrigger()
        {
            base.TriggerType = Enums.TriggerTypes.Mouse;
            Statics.AppSession.InputListener.MouseInputs += Hook_MouseInputs;
        }

        private void Hook_MouseInputs(MouseData data, ref ModifierKey modifierKey)
        {
            if (!Statics.AppSession.Enable || !base.IsEnable)
            {
                base.RunState = Enums.TriggerRunState.Stop;
                return;
            }
            bool defaultCon = (HasPrimary && Statics.SharedMethods.getPrimaryKeyStatus(PrimaryKey, modifierKey) || !HasPrimary) && data.Key == SecondaryKey;

            if (defaultCon && Method == Enums.TriggerKeyMethods.Press && data.Flags == CSInputs.Enums.KeyFlags.KeyDown)
            {
                base.RunState = Enums.TriggerRunState.RunOnce;
            }

            // Method Hold
            if (defaultCon && Method == Enums.TriggerKeyMethods.Hold && data.Flags == CSInputs.Enums.KeyFlags.KeyDown)
            {
                base.RunState = Enums.TriggerRunState.Run;
            }

            if (defaultCon && Method == Enums.TriggerKeyMethods.Hold && data.Flags == CSInputs.Enums.KeyFlags.KeyUp)
            {
                base.RunState = Enums.TriggerRunState.Stop;
            }

            // Method Toggle
            if (defaultCon && Method == Enums.TriggerKeyMethods.Toggle && data.Flags == CSInputs.Enums.KeyFlags.KeyDown)
            {
                if (base.RunState == Enums.TriggerRunState.Run)
                {
                    base.RunState = Enums.TriggerRunState.Stop;
                }
                else
                {
                    base.RunState = Enums.TriggerRunState.Run;
                }
            }
        }

        public override string ToString()
        {
            return "Mouse";
        }
    }
}
