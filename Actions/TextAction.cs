using System.Drawing;

namespace TGMacro.Actions
{
    public class TextAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.Text;
        public string Text { get; set; }
        public string VisibleText => "Text";
        public string VisibleValue => Text;
        public Image Icon => Properties.Resources.keyboard_16px;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void DoJob()
        {
            CSInputs.SendInput.Keyboard.SendString(Text);
        }
    }
}
