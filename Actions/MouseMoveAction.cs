using System.Drawing;

namespace TGMacro.Actions
{
    public class MouseMoveAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.MoveMouse;
        public CSInputs.Enums.MousePositioning MouseMoveMethod { get; set; } = CSInputs.Enums.MousePositioning.Absolute;
        public Point MousePos { get; set; }
        public string VisibleText => $"Move Mouse ({MouseMoveMethod.ToString()[0]})";
        public string VisibleValue => MousePos.ToString();
        public Image Icon => Properties.Resources.mouse_16px;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void DoJob()
        {
            CSInputs.SendInput.Mouse.MoveTo(MousePos, MouseMoveMethod);
        }
    }
}
