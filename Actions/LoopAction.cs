using System.Drawing;

namespace TGMacro.Actions
{
    public class LoopAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.Loop;
        public string Text { get; set; }
        public string VisibleText => "Loop";
        public string VisibleValue => "Loop";
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
