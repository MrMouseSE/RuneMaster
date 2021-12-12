using Runes.RunesScripts;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RuneItemContainerEvent : UnityEvent<RuneItemContainer>
{
}

namespace Runes.RunesScripts
{
    public class RuneItemContainer : MonoBehaviour
    {
        private RuneItem _myRune;
        private MeshRenderer _renderer;
        private Animator _animator;
        private TextMesh _text;
        private int _count;
        private Material _shaderMaterial;
        private BoxCollider _collider;

        public RuneItemContainerEvent RunePressedEvent = new RuneItemContainerEvent();

        public void SetMyRune(RuneItem rune)
        {
            _myRune = rune;
        }

        public RuneItem GetMyRune()
        {
            return _myRune;
        }
    
        private void Awake()
        {
            _renderer = GetComponentInChildren<MeshRenderer>();
            _shaderMaterial = _renderer.sharedMaterial;
            _animator = GetComponentInChildren<Animator>();
            _text = GetComponentInChildren<TextMesh>();
            _collider = GetComponent<BoxCollider>();
        }
    
        public void SetRuneCount(int count)
        {
            _count = count;
            DecrementRune(0);
        }

        public int DecrementRune(int value = 1)
        {
            _count -= value;
            _text.text = _count.ToString();
            if (_count == 0) DeactivateWhenZero();
            return _count;
        }

        private void DeactivateWhenZero()
        {
            _collider.enabled = false;
            SetAnimationTrigger("Empty");
        }

        public void SetTexture(Texture2D texure)
        {
            _shaderMaterial.mainTexture = texure;
        }

        private void ActivateRune()
        {
            SetAnimationTrigger("Activate");
        }

        private void DeactivateRune()
        {
            SetAnimationTrigger("Deactivate");
        }

        private void OnMouseDown()
        {
            RunePressedEvent.Invoke(this);
        }

        private void OnMouseEnter()
        {
            ActivateRune();
        }

        private void OnMouseExit()
        {
            DeactivateRune();
        }

        private void SetAnimationTrigger(string trigger)
        {
            _animator.SetTrigger(trigger);
        }
    }
}