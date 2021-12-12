using UiElementsScripts;
using UnityEngine;

namespace GlobalMap.Cityes.CityesScripts
{
    public class UiHandler : MonoBehaviour
    {
        [SerializeField] private UiContainer uiContainer;
        
        public void ActivateUiWindow()
        {
            SwitchUiWindowVisibility(true);
        }

        public void DeactivateUiWindow()
        {
            SwitchUiWindowVisibility(false);
        }

        public MyButton GetCloseButton()
        {
            return uiContainer.CloseButton;
        }

        private void SwitchUiWindowVisibility(bool state)
        {
            uiContainer.UiCamera.gameObject.SetActive(state);
            uiContainer.UiGameObject.SetActive(state);
        }
    }
}