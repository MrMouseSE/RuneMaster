using System;
using UnityEngine;

namespace GlobalMap.Cityes.CityesScripts
{
    public class CityInteractiveHandler : MonoBehaviour
    {
        private MarketHandler _marketHandler;
        private CityesHolder _cityesHolder;
        private CityStatesSwitcher _citySwitcher;
        private void Awake()
        {
            _marketHandler = GetComponent<MarketHandler>();
            _cityesHolder = GetComponent<CityesHolder>();
        }

        private void Start()
        {
            _marketHandler.GetCloseButton().ButtonPressed.AddListener(StopInteracitonWithCity);
            foreach (var cityContainer in _cityesHolder.GetAllCityesList())
            {
                cityContainer.MousePressed.AddListener(StartInteractionWithCity);
            }
        }

        private void StartInteractionWithCity()
        {
            _marketHandler.ActivateMarket();
        }

        private void StopInteracitonWithCity()
        {
            _marketHandler.DeactivateMarket();
        }

        private void OnDestroy()
        {
            _marketHandler.GetCloseButton().ButtonPressed.RemoveListener(StopInteracitonWithCity);
            foreach (var cityContainer in _cityesHolder.GetAllCityesList())
            {
                cityContainer.MousePressed.RemoveListener(StartInteractionWithCity);
            }
        }
    }
}
