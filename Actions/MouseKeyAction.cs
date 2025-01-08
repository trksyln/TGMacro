using System.Drawing;

namespace TGMacro.Actions
{
    public class MouseKeyAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.MouseButton;
        public Enums.KeyPressMethods KeyMethod { get; set; } = Enums.KeyPressMethods.Press;
        public CSInputs.Enums.MouseKeys MouseKey { get; set; } = CSInputs.Enums.MouseKeys.MouseLeft;
        public CSInputs.Enums.MousePositioning MouseMoveMethod { get; set; } = CSInputs.Enums.MousePositioning.Absolute;
        public Point MousePos { get; set; }
        public string VisibleText => "Mouse " + (KeyMethod == Enums.KeyPressMethods.Press ? "Click" : KeyMethod.ToString()) + $" ({MouseMoveMethod.ToString()[0]})";
        public string VisibleValue => MouseKey.ToString() + "  " + (MousePos != Point.Empty ? MousePos.ToString() : "");
        public Image Icon => Properties.Resources.mouse_16px;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void DoJob()
        {
            Point mousePos = MousePos;
            if (KeyMethod == Enums.KeyPressMethods.Press)
            {
                CSInputs.SendInput.Mouse.Send(MouseKey, mousePos, MouseMoveMethod);
            }
            else if (KeyMethod == Enums.KeyPressMethods.Down)
            {
                CSInputs.SendInput.Mouse.Send(MouseKey, CSInputs.Enums.KeyFlags.KeyDown, mousePos, MouseMoveMethod);
            }
            else
            {
                CSInputs.SendInput.Mouse.Send(MouseKey, CSInputs.Enums.KeyFlags.KeyUp, mousePos, MouseMoveMethod);
            }
        }
    }
}
