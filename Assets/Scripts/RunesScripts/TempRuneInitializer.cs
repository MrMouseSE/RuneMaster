using System.Collections.Generic;
using UnityEngine;

namespace RunesScripts
{
    public class TempRuneInitializer : MonoBehaviour
    {
        public List<RunePropertyContainer> RunePropertyContainers;
        private void Awake()
        {
            Dictionary<RuneItem, int> runes = new Dictionary<RuneItem, int>();
            foreach (var runePropertyContainer in RunePropertyContainers)
            {
                RuneItem runeItem = new RuneItem();
                runeItem.PropertyContainer = runePropertyContainer;
                runes.Add(runeItem,Random.Range(0,10));
            }
            RunesHolder.SetRunes(runes);
        }
    }
}
