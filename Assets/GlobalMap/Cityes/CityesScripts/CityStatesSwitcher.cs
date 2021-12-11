using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalMap.Cityes.CityesScripts
{
    public class CityStatesSwitcher : MonoBehaviour
    {
        private CityesHolder _holder;

        private void Awake()
        {
            _holder = GetComponent<CityesHolder>();
        }

        public void SetCityesState()
        {
            foreach (var city in _holder.UnstableCityes)
            {
                city.CurrentState = (CityesStateEnum) Random.Range(0, 3);
            }
        }
    }
}