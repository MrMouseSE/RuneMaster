using UnityEngine;
using UnityEngine.Events;

namespace UiElementsScripts
{
    public class MyButton : MonoBehaviour
    {
        public UnityEvent ButtonPressed;
        [SerializeField] private GameObject _buttonGlow;

        private void OnMouseEnter()
        {
            _buttonGlow.SetActive(true);
        }

        private void OnMouseExit()
        {
            GlowHide();
        }

        private void OnMouseDown()
        {
            GlowHide();
            ButtonPressed.Invoke();
        }

        private void GlowHide()
        {
            _buttonGlow.SetActive(false);
        }
    }
}
