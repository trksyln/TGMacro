using System.Drawing;

namespace TGMacro.Actions
{
    public class ForAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.For;
        public int LoopCount { get; set; }
        public string VisibleText => "For";
        public string VisibleValue => "For x" + LoopCount;
        public Image Icon => Properties.Resources.keyboard_16px;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void DoJob()
        {
        }
    }
}
