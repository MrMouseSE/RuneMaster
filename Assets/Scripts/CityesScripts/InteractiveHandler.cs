using UnityEngine;

namespace CityesScripts
{
    public class InteractiveHandler : MonoBehaviour
    {
        protected UiHandler _uiHandler;

        protected void Awake()
        {
            _uiHandler = GetComponent<UiHandler>();
        }

        protected void Start()
        {
            _uiHandler.GetCloseButton().ButtonPressed.AddListener(StopInteracitonWithElement);
        }
        
        protected void StartInteractionWithElement()
        {
            _uiHandler.ActivateUiWindow();
        }

        protected void StopInteracitonWithElement()
        {
            _uiHandler.DeactivateUiWindow();
        }

        protected void OnDestroy()
        {
            _uiHandler.GetCloseButton().ButtonPressed.RemoveListener(StopInteracitonWithElement);
        }
    }
}
