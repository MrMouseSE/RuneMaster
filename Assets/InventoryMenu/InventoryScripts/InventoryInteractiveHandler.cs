using GlobalMap.Cityes.CityesScripts;
using UiElementsScripts;
using UnityEngine;

namespace InventoryMenu.InventoryScripts
{
    public class InventoryInteractiveHandler : InteractiveHandler
    {
        [SerializeField]
        private MyButton _inventoryButton;

        private InventoryUIContainer _inventoryUIContainer;

        private void Start()
        {
            _uiHandler.GetCloseButton().ButtonPressed.AddListener(StopInteracitonWithElement);
            _inventoryButton.ButtonPressed.AddListener(StartInteractionWithElement);
            _inventoryUIContainer = (InventoryUIContainer) _uiHandler.GetContainer();
        }

        private void StartInteractionWithElement()
        {
            base.StartInteractionWithElement();
            _inventoryUIContainer.RunesManager.AwakeRuneManager();
        }

        private void StopInteracitonWithElement()
        {
            base.StopInteracitonWithElement();
            _inventoryUIContainer.RunesManager.StopRunesManagerSession();
        }

        private void OnDestroy()
        {
            base.OnDestroy();
            _inventoryButton.ButtonPressed.RemoveListener(StartInteractionWithElement);
        }
        
    }
}
