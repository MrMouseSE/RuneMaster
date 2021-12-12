using System.Collections.Generic;
using UnityEngine;

namespace Runes.RunesScripts
{
    public class RunesManager : MonoBehaviour
    {
        [SerializeField]
        private RuneItemContainer emptyRuneItemContainer;

        private Dictionary<RuneItem, int> _currentRunes;

        private List<RuneItemContainer> _myRunes = new List<RuneItemContainer>();

        public void AwakeRuneManager()
        {
            _currentRunes = RunesHolder.GetRunes();
            DrawExistedRunes();
        }

        public void DrawExistedRunes()
        {
            var runes = RunesHolder.GetRunes();
            Vector3 runeContainerPosition = transform.position;
            int positionXShift = 0;
            int positionYShift = 0;
            foreach (var rune in runes)
            {
                if (rune.Value > 0)
                {
                    RuneItemContainer runeContainer = Instantiate(emptyRuneItemContainer);
                    runeContainer.SetRuneCount(rune.Value);
                    runeContainer.SetTexture(rune.Key.PropertyContainer.RuneTexture);
                    runeContainer.SetMyRune(rune.Key);
                    runeContainer.RunePressedEvent.AddListener(UpdateCurrentRunes);
                    var contPos = runeContainerPosition;
                    contPos.x += positionXShift * 0.5f;
                    contPos.y -= positionYShift * 0.5f;
                    runeContainer.transform.position = contPos;
                    positionXShift++;
                    if (positionXShift > 3)
                    {
                        positionXShift = 0;
                        positionYShift++;
                    }
                    
                    _myRunes.Add(runeContainer);
                }
            }
        }

        private void UpdateCurrentRunes(RuneItemContainer rune)
        {
            _currentRunes[rune.GetMyRune()] = rune.DecrementRune();
        }

        public void StopRunesManagerSession()
        {
            UpdateRunesInHolder();
            foreach (var myRune in _myRunes)
            {
                Destroy(myRune.gameObject);
            }
            _myRunes.Clear();
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