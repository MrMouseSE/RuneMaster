using System;
using UnityEngine;
using UnityEngine.Events;

namespace GlobalMap.Cityes.CityesScripts
{
    public class CityContainer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _colorTextureGameObject;
        [SerializeField]
        private GameObject _glowTextureGameObject;

        public CityesStateEnum CurrentState = CityesStateEnum.Calmness;

        private MarketDataGenerator _marketData;

        public UnityEvent MousePressed;

        private void Awake()
        {
            _marketData = GetComponent<MarketDataGenerator>();
        }

        private void OnMouseEnter()
        {
            _glowTextureGameObject.SetActive(true);
        }

        private void OnMouseDown()
        {
            _marketData.GetMarketPriceMultiplyer();
            MousePressed.Invoke();
        }

        private void OnMouseUp()
        {
            
        }

        private void OnMouseExit()
        {
            _glowTextureGameObject.SetActive(false);
        }
    }
}
