namespace GlobalMap.Cityes.CityesScripts
{
    public class CityInteractiveHandler : InteractiveHandler
    {
        private CityesHolder _cityesHolder;
        private CityStatesSwitcher _citySwitcher;
        private void Awake()
        {
            base.Awake();
            _cityesHolder = GetComponent<CityesHolder>();
        }

        private void Start()
        {
            base.Start();
            foreach (var cityContainer in _cityesHolder.GetAllCityesList())
            {
                cityContainer.MousePressed.AddListener(StartInteractionWithElement);
            }
        }
        
        private void OnDestroy()
        {
            base.OnDestroy();
            foreach (var cityContainer in _cityesHolder.GetAllCityesList())
            {
                cityContainer.MousePressed.RemoveListener(StartInteractionWithElement);
            }
        }
    }
}
