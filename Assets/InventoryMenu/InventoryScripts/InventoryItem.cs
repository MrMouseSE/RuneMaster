using System.Collections.Generic;
using Runes.RunesScripts;
using UnityEngine;

namespace InventoryMenu.InventoryScripts
{
    public class InventoryItem : MonoBehaviour
    {
        public Sprite ItemSprite;

        private List<RuneItem> _itemRunes;

        public void AddRune(RuneItem rune)
        {
            _itemRunes.Add(rune);
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