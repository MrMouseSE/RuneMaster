using System.Collections.Generic;

namespace RunesScripts
{
    public static class RunesHolder
    {
        private static Dictionary<RuneItem, int> _runes = new Dictionary<RuneItem, int>();

        public static void AddRune(RuneItem rune)
        {
            if (_runes.TryGetValue(rune, out int value))
            {
                _runes[rune] = value+1;
            }
            else
            {
                _runes.Add(rune,1);
            }
        }

        public static void SetRunes(Dictionary<RuneItem,int> currentRunes)
        {
            _runes = currentRunes;
        }

        public static Dictionary<RuneItem, int> GetRunes()
        {
            return _runes;
        }
    }
}
