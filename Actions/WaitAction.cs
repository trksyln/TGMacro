using System.Drawing;

namespace TGMacro.Actions
{
    public class WaitAction : Interfaces.IMacroAction
    {
        public Enums.ActionTypes ActionType => Enums.ActionTypes.Wait;
        public int SleepAmount { get; set; }
        public string VisibleText => "Wait";
        public string VisibleValue => SleepAmount + "ms";
        public Image Icon => Properties.Resources.wait_16;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void DoJob()
        {
            System.Threading.Thread.Sleep(SleepAmount);
        }
    }
}
