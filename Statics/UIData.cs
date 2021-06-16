
using System;
using System.Collections.Generic;

namespace TGMacro.Statics
{
    public static class UIData
    {
        private static MouseKeys[] getMouseKeys;
        public static MouseKeys[] GetMouseKeys
        {
            get
            {
                if (getMouseKeys == null)
                {
                    List<MouseKeys> keys = new List<MouseKeys>();
                    foreach (CSInputs.Enums.MouseKeys item in (CSInputs.Enums.MouseKeys[])Enum.GetValues(typeof(CSInputs.Enums.MouseKeys)))
                    {
                        if (!item.ToString().ToLower().Contains("up"))
                        {
                            keys.Add(new MouseKeys(item));
                        }
                    }
                    getMouseKeys = keys.ToArray();
                }
                return getMouseKeys;
            }
        }

        private static KeyboardKeys[] getKeyboardKeys;
        public static KeyboardKeys[] GetKeyboardKeys
        {
            get
            {
                if (getMouseKeys == null)
                {
                    List<KeyboardKeys> keys = new List<KeyboardKeys>();
                    foreach (CSInputs.Enums.KeyboardKeys item in (CSInputs.Enums.KeyboardKeys[])Enum.GetValues(typeof(CSInputs.Enums.KeyboardKeys)))
                    {
                        keys.Add(new KeyboardKeys(item));
                    }
                    getKeyboardKeys = keys.ToArray();
                }
                return getKeyboardKeys;
            }
        }

        private static PrimaryKeys[] getPrimaryKeys;
        public static PrimaryKeys[] GetPrimaryKeys
        {
            get
            {
                if (getMouseKeys == null)
                {
                    List<PrimaryKeys> keys = new List<PrimaryKeys>();
                    foreach (CSInputs.Enums.KeyboardKeys item in (CSInputs.Enums.KeyboardKeys[])Enum.GetValues(typeof(CSInputs.Enums.KeyboardKeys)))
                    {
                        keys.Add(new PrimaryKeys(item));
                    }
                    getPrimaryKeys = keys.ToArray();
                }
                return getPrimaryKeys;
            }
        }

    }

    public class MouseKeys
    {
        public string Name { get; set; }
        public CSInputs.Enums.MouseKeys Key { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public MouseKeys(CSInputs.Enums.MouseKeys key)
        {
            Name = Enum.GetName(key.GetType(), key);
        }
    }

    public class KeyboardKeys
    {
        public string Name { get; set; }
        public CSInputs.Enums.KeyboardKeys Key { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public KeyboardKeys(CSInputs.Enums.KeyboardKeys key)
        {
            Name = Enum.GetName(key.GetType(), key);
        }
    }

    public class PrimaryKeys
    {
        public string Name { get; set; }
        public CSInputs.Enums.KeyboardKeys Key { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public PrimaryKeys(CSInputs.Enums.KeyboardKeys key)
        {
            Name = Enum.GetName(key.GetType(), key);
        }
    }
}
