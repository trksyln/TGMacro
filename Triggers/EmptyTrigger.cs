namespace TGMacro.Triggers
{
    public class EmptyTrigger : Bases.TriggerBase
    {
        public Enums.TriggerKeyMethods Method { get; set; } = Enums.TriggerKeyMethods.Hold;
        public EmptyTrigger()
        {
            base.TriggerType = Enums.TriggerTypes.Keyboard;
        }
        public override string ToString()
        {
            return "None";
        }

    }
}
