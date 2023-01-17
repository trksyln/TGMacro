using System.Drawing;
using System.Runtime.Serialization;
using TGMacro.Bases;
using TGMacro.Interfaces;

namespace TGMacro.ProjectData
{
    [DataContract]
    public class TGMacroProject
    {
        [DataMember(Order = 0)]
        public string FileType { get; private set; } = "TGMacro Project";
        [DataMember(Order = 1)]
        public string Version { get; private set; } = Statics.AppSession.Version + " Build:" + Statics.AppSession.BuildNumber;
        [DataMember(Order = 2)]
        public Macro[] Macros { get; set; }
    }

    [DataContract]
    public class Macro
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        public Trigger Trigger { get; set; }
        [DataMember(Order = 2)]
        public Action[] Actions { get; set; }
        public Macro(string name)
        {
            Name = name;
        }
    }

    [DataContract]
    public class Trigger
    {
        [DataMember(EmitDefaultValue = true)]
        public Enums.TriggerTypes TriggerType { get; set; }
        [DataMember(EmitDefaultValue = false)] public CSInputs.Enums.KeyboardKeys? MasterKey { get; set; }
        [DataMember(EmitDefaultValue = false)] public CSInputs.Enums.KeyboardKeys? KeyboardKey { get; set; }
        [DataMember(EmitDefaultValue = false)] public CSInputs.Enums.MouseKeys? MouseKey { get; set; }
        [DataMember(EmitDefaultValue = false)] public Point? PixelPosition { get; set; }
        [DataMember(EmitDefaultValue = false)] public RGB? PixelColor { get; set; }
        [DataMember(EmitDefaultValue = false)] public Enums.ColorTriggerMethods? IfMatches { get; set; }
        [DataMember(EmitDefaultValue = false)] public Enums.TriggerKeyMethods? KeyPressMethod { get; set; }

        public Trigger() { }
        public Trigger(TriggerBase trg)
        {
            switch (trg.TriggerType)
            {
                case Enums.TriggerTypes.Mouse:
                    TriggerType = Enums.TriggerTypes.Mouse;
                    MasterKey = (trg as Triggers.MouseTrigger).PrimaryKey;
                    KeyPressMethod = (trg as Triggers.MouseTrigger).Method;
                    MouseKey = (trg as Triggers.MouseTrigger).SecondaryKey;
                    break;
                case Enums.TriggerTypes.Keyboard:
                    TriggerType = Enums.TriggerTypes.Keyboard;
                    MasterKey = (trg as Triggers.KeyboardTrigger).PrimaryKey;
                    KeyPressMethod = (trg as Triggers.KeyboardTrigger).Method;
                    KeyboardKey = (trg as Triggers.KeyboardTrigger).SecondaryKey;
                    break;
                case Enums.TriggerTypes.Pixel:
                    TriggerType = Enums.TriggerTypes.Pixel;
                    PixelPosition = (trg as Triggers.ColorTrigger).Pos;
                    PixelColor = new RGB((trg as Triggers.ColorTrigger).Color.R, (trg as Triggers.ColorTrigger).Color.G, (trg as Triggers.ColorTrigger).Color.B);
                    IfMatches = (trg as Triggers.ColorTrigger).Method;
                    break;
            }
        }

        public TriggerBase GetTrigger()
        {
            switch (TriggerType)
            {
                case Enums.TriggerTypes.Mouse:
                    return new Triggers.MouseTrigger()
                    {
                        Method = KeyPressMethod ?? default,
                        PrimaryKey = MasterKey ?? default,
                        SecondaryKey = MouseKey ?? default
                    };
                case Enums.TriggerTypes.Keyboard:
                    return new Triggers.KeyboardTrigger()
                    {
                        Method = KeyPressMethod ?? default,
                        PrimaryKey = MasterKey ?? default,
                        SecondaryKey = KeyboardKey ?? default
                    };
                case Enums.TriggerTypes.Pixel:
                    return new Triggers.ColorTrigger()
                    {
                        Method = IfMatches ?? default,
                        Color = System.Drawing.Color.FromArgb(PixelColor.Value.R, PixelColor.Value.G, PixelColor.Value.B),
                        Pos = PixelPosition ?? default
                    };
            }
            return new Triggers.EmptyTrigger();
        }

    }

    [DataContract]
    public class Action
    {
        [DataMember(EmitDefaultValue = true)]
        public Enums.ActionTypes ActionType { get; set; }
        [DataMember(EmitDefaultValue = false)] public Enums.KeyPressMethods? KeyPressMethod { get; set; }
        [DataMember(EmitDefaultValue = false)] public CSInputs.Enums.KeyboardKeys? KeyboardKeyCode { get; set; }
        [DataMember(EmitDefaultValue = false)] public CSInputs.Enums.MouseKeys? MouseKeyCode { get; set; }
        [DataMember(EmitDefaultValue = false)] public CSInputs.Enums.MousePositioning? MousePositioning { get; set; }
        [DataMember(EmitDefaultValue = false)] public Point? PixelPosition { get; set; }
        [DataMember(EmitDefaultValue = false)] public int? WaitFor { get; set; }
        [DataMember(EmitDefaultValue = false)] public string Text { get; set; }

        public Action(IMacroAction act)
        {
            switch (act.ActionType)
            {
                case Enums.ActionTypes.MoveMouse:
                    ActionType = (act as Actions.MouseMoveAction).ActionType;
                    PixelPosition = (act as Actions.MouseMoveAction).MousePos;
                    MousePositioning = (act as Actions.MouseMoveAction).MouseMoveMethod;
                    break;
                case Enums.ActionTypes.MouseButton:
                    ActionType = (act as Actions.MouseKeyAction).ActionType;
                    PixelPosition = (act as Actions.MouseKeyAction).MousePos;
                    MousePositioning = (act as Actions.MouseKeyAction).MouseMoveMethod;
                    KeyPressMethod = (act as Actions.MouseKeyAction).KeyMethod;
                    MouseKeyCode = (act as Actions.MouseKeyAction).MouseKey;
                    break;
                case Enums.ActionTypes.KeyboardKey:
                    ActionType = (act as Actions.KeyboardKeyAction).ActionType;
                    KeyboardKeyCode = (act as Actions.KeyboardKeyAction).KeyboardKey;
                    KeyPressMethod = (act as Actions.KeyboardKeyAction).KeyMethod;
                    break;
                case Enums.ActionTypes.Wait:
                    ActionType = (act as Actions.WaitAction).ActionType;
                    WaitFor = (act as Actions.WaitAction).SleepAmount;
                    break;
                case Enums.ActionTypes.Text:
                    ActionType = (act as Actions.TextAction).ActionType;
                    Text = (act as Actions.TextAction).Text;
                    break;
            }
        }

        public IMacroAction GetAction()
        {
            switch (ActionType)
            {
                case Enums.ActionTypes.MoveMouse:
                    {
                        return new Actions.MouseMoveAction
                        {
                            MouseMoveMethod = MousePositioning ?? default(int),
                            MousePos = PixelPosition ?? default
                        };
                    }
                case Enums.ActionTypes.MouseButton:
                    {
                        return new Actions.MouseKeyAction
                        {
                            MouseMoveMethod = MousePositioning ?? default(int),
                            MousePos = PixelPosition ?? default,
                            KeyMethod = KeyPressMethod ?? default,
                            MouseKey = MouseKeyCode ?? default
                        };
                    }
                case Enums.ActionTypes.KeyboardKey:
                    {
                        return new Actions.KeyboardKeyAction
                        {
                            KeyboardKey = KeyboardKeyCode ?? default,
                            KeyMethod = KeyPressMethod ?? default
                        };
                    }
                case Enums.ActionTypes.Wait:
                    {
                        return new Actions.WaitAction
                        {
                            SleepAmount = WaitFor ?? default
                        };
                    }
                case Enums.ActionTypes.Text:
                    {
                        return new Actions.TextAction
                        {
                            Text = Text ?? default
                        };
                    }
            }
            return new Actions.WaitAction();
        }
    }
}
