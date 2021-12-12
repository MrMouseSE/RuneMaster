using UiElementsScripts;
using UnityEngine;

namespace GlobalMap.Cityes.CityesScripts
{
    public class MarketHandler : MonoBehaviour
    {
        [SerializeField] private UiContainer uiContainer;
        
        public void ActivateMarket()
        {
            SwitchMarketVisibility(true);
        }

        public void DeactivateMarket()
        {
            SwitchMarketVisibility(false);
        }

        public MyButton GetCloseButton()
        {
            return uiContainer.CloseButton;
        }

        private void SwitchMarketVisibility(bool state)
        {
            uiContainer.UiCamera.gameObject.SetActive(state);
            uiContainer.UiGameObject.SetActive(state);
        }
    }
}