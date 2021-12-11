using System.Collections.Generic;
using UnityEngine;

namespace GlobalMap.Cityes.CityesScripts
{
    public class MarketDataGenerator : MonoBehaviour
    {
        public List<MarketDataContainer> MarketDataContainers;
        
        private MarketDataContainer _marketData;

        private CityContainer _container;

        public void Awake()
        {
            
            _marketData = MarketDataContainers.Find(x => gameObject.name.Contains(x.Name));
            _container = GetComponent<CityContainer>();
        }

        public float GetMarketPriceMultiplyer()
        {
            Vector2 range = _marketData.GetMarketPriceMultiplyer(_container.CurrentState);
            return Random.Range(range.x, range.y);
        }
    }
}
