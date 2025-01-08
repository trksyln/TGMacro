using System.Drawing;

namespace TGMacro.Actions
{
    public class KeyboardKeyAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.KeyboardKey;
        public CSInputs.Enums.KeyboardKeys KeyboardKey { get; set; } = CSInputs.Enums.KeyboardKeys.Space;
        public Enums.KeyPressMethods KeyMethod { get; set; } = Enums.KeyPressMethods.Press;
        public string VisibleText => "Key " + KeyMethod;
        public string VisibleValue => KeyboardKey.ToString();
        public Image Icon => Properties.Resources.keyboard_16px;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void DoJob()
        {
            if (KeyMethod == Enums.KeyPressMethods.Press)
            {
                CSInputs.SendInput.Keyboard.Send(KeyboardKey);
            }
            else if (KeyMethod == Enums.KeyPressMethods.Down)
            {
                CSInputs.SendInput.Keyboard.Send(KeyboardKey, CSInputs.Enums.KeyFlags.KeyDown);
            }
            else
            {
                CSInputs.SendInput.Keyboard.Send(KeyboardKey, CSInputs.Enums.KeyFlags.KeyUp);
            }
        }
    }
}
