using UnityEngine;

namespace GlobalMap.Cityes.CityesScripts
{
    [CreateAssetMenu(menuName = "MarketDataContainer", fileName = "MarketDataContainer", order = 0)]
    public class MarketDataContainer : ScriptableObject
    {
        public string Name; 
        public Vector2 PoorPriceMultiplyer;
        public Vector2 NormalPriceMultiplyer;
        public Vector2 RichPriceMultiplyer;

        public Vector2 GetMarketPriceMultiplyer(CityesStateEnum state)
        {
            switch (state)
            {
                case CityesStateEnum.Happiness:
                    return RichPriceMultiplyer;
                case CityesStateEnum.Calmness:
                    return NormalPriceMultiplyer;
                case CityesStateEnum.UnderAttack:
                    return PoorPriceMultiplyer;
                default:
                    return Vector2.zero;
            }
        }
    }
}