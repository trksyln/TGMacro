using CSInputs.ReadInput;
using CSInputs.Structs;
using System;

namespace TGMacro.Triggers
{
    public class KeyboardTrigger : Bases.TriggerBase, IDisposable
    {
        public Enums.TriggerKeyMethods Method { get; set; }
        public bool HasPrimary => PrimaryKey != CSInputs.Enums.KeyboardKeys.None;
        public CSInputs.Enums.KeyboardKeys PrimaryKey { get; set; }

        public CSInputs.Enums.KeyboardKeys SecondaryKey { get; set; }

        public KeyboardTrigger()
        {
            base.TriggerType = Enums.TriggerTypes.Keyboard;
            Statics.AppSession.InputListener.KeyboardInputs += Hook_KeyboardInputs;
        }

        private void Hook_KeyboardInputs(KeyboardData data, ref ModifierKey modifierKey)
        {
            if (!Statics.AppSession.Enable || !base.IsEnable)
            {
                base.RunState = Enums.TriggerRunState.Stop;
                return;
            }

            bool defaultCon = (HasPrimary && Statics.SharedMethods.getPrimaryKeyStatus(PrimaryKey, modifierKey) || !HasPrimary) && data.Key == SecondaryKey;

            // Method Press
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
            return "Keyboard";
        }

    }
}