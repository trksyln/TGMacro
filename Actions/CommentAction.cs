using System.Drawing;

namespace TGMacro.Actions
{
    public class CommentAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.Comment;
        public string Text { get; set; }
        public string VisibleText => "Comment";
        public string VisibleValue => $"----- {Text} -----";
        public Image Icon => Properties.Resources.min_16;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void DoJob()
        {
        }
    }
}
