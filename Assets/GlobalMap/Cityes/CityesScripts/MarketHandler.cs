using MarketMenu.MarketMenuScript;
using UnityEngine;

namespace GlobalMap.Cityes.CityesScripts
{
    public class MarketHandler : MonoBehaviour
    {
        [SerializeField] private MarketContainer _marketContainer;
        
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
            return _marketContainer.CloseButton;
        }

        private void SwitchMarketVisibility(bool state)
        {
            _marketContainer.UiCamera.gameObject.SetActive(state);
            _marketContainer.UiGameObject.SetActive(state);
        }
    }
}