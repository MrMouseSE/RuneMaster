using System.Collections.Generic;
using UnityEngine;

namespace Runes.RunesScripts
{
    public class RunesManager : MonoBehaviour
    {
        [SerializeField]
        private RuneItemContainer emptyRuneItemContainer;

        private Dictionary<RuneItem, int> _currentRunes;

        private List<RuneItemContainer> _myRunes;

        public void AwakeRuneManager()
        {
            _currentRunes = RunesHolder.GetRunes();
        }

        public void DrawExistedRunes()
        {
            var runes = RunesHolder.GetRunes();
            foreach (var rune in runes)
            {
                if (rune.Value > 0)
                {
                    RuneItemContainer runeContainer = Instantiate(emptyRuneItemContainer);
                    runeContainer.SetRuneCount(rune.Value);
                    runeContainer.SetTexture(rune.Key.PropertyContainer.RuneTexture);
                    runeContainer.SetMyRune(rune.Key);
                    runeContainer.RunePressedEvent.AddListener(UpdateCurrentRunes);
                    
                    _myRunes.Add(runeContainer);
                }
            }
        }

        private void UpdateCurrentRunes(RuneItemContainer rune)
        {
            _currentRunes[rune.GetMyRune()] = rune.DecrementRune();
        }

        private void UpdateRunesInHolder()
        {
            RunesHolder.SetRunes(_currentRunes);
        }

        private void OnDestroy()
        {
            foreach (var runeSpriteContainer in _myRunes)
            {
                runeSpriteContainer.RunePressedEvent.RemoveListener(UpdateCurrentRunes);
            }
        }
    }
}