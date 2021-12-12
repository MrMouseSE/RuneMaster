using GlobalMap.Cityes.CityesScripts;
using UiElementsScripts;
using UnityEngine;

namespace InventoryMenu.InventoryScripts
{
    public class InventoryInteractiveHandler : InteractiveHandler
    {
        [SerializeField]
        private MyButton _inventoryButton;

        private void Start()
        {
            base.Start();
            _inventoryButton.ButtonPressed.AddListener(StartInteractionWithElement);
        }

        private void StopInteracitonWithElement()
        {
            base.StartInteractionWithElement();
            
        }

        private void OnDestroy()
        {
            base.OnDestroy();
            _inventoryButton.ButtonPressed.RemoveListener(StartInteractionWithElement);
        }
        
    }
}
