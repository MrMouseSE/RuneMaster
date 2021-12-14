using RunesScripts;
using UnityEngine;

namespace InventoryScripts
{
    public class InventoryItem : MonoBehaviour
    {
        public Texture2D ItemSprite;

        private RuneItem[] _itemRunes;
        private bool _hasFreeRuneSlot = true; 

        public void SetRuneSlotCapacity(int capacity)
        {
            _itemRunes = new RuneItem [capacity];
        }

        public bool CheckFreeRuneSlot()
        {
            return _hasFreeRuneSlot;
        }

        public void AddRune(RuneItem rune)
        {
            for (int i = 0; i < _itemRunes.Length; i++)
            {
                _itemRunes[i] ??= rune;
                if (i == _itemRunes.Length - 1) _hasFreeRuneSlot = false;
            }
            CheckRuneWord();
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