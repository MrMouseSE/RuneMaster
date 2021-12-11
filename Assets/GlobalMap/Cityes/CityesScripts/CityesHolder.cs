using System.Collections.Generic;
using UnityEngine;

namespace GlobalMap.Cityes.CityesScripts
{
    public class CityesHolder : MonoBehaviour
    {
        public CityContainer[] UnstableCityes;
        public CityContainer[] StableCityes;

        private List<CityContainer> _allCityes = new List<CityContainer>(); 

        private void Awake()
        {
            _allCityes.AddRange(UnstableCityes);
            _allCityes.AddRange(StableCityes);
        }

        public List<CityContainer> GetAllCityesList()
        {
            return _allCityes;
        }
    }
}