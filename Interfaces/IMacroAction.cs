using System.Drawing;

namespace TGMacro.Interfaces
{
    public interface IMacroAction : System.ICloneable
    {
        Enums.ActionTypes ActionType { get; }
        Image Icon { get; }
        string VisibleText { get; }
        string VisibleValue { get; }
        void DoJob();
    }
}
