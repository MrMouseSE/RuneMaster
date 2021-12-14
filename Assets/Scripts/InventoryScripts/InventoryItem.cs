using RunesScripts;
using UnityEngine;

namespace InventoryScripts
{
    public class InventoryItem : MonoBehaviour
    {
        public Texture2D ItemSprite;

        private RuneItem[] _itemRunes;

        public void SetRuneSlotCapacity(int capacity)
        {
            _itemRunes = new RuneItem [capacity];
        }

        public bool TrySetUpRune(RuneItem rune)
        {
            bool hasEmptySlot = false;
            for (int i = 0; i < _itemRunes.Length; i++)
            {
                if (_itemRunes[i] != null)
                {
                    _itemRunes[i] = rune;
                    hasEmptySlot = true;
                    break;
                }
            }
            CheckRuneWord();
            return hasEmptySlot;
        }

        private void CheckRuneWord()
        {
            
        }

        public void DestroyItem()
        {
            Destroy(gameObject);
        }
    }
}