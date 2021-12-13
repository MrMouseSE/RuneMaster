using RunesScripts;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RuneItemContainerEvent : UnityEvent<RuneItemContainer>
{
}

namespace RunesScripts
{
    public class RuneItemContainer : MonoBehaviour
    {
        private RuneItem _myRune;
        private MeshRenderer _renderer;
        private Animator _animator;
        private TextMesh _text;
        private int _count;
        private BoxCollider _collider;
        [SerializeField] private string _activateTrigger;
        private int _activateTriggerHash;
        [SerializeField] private string _deactivateTrigger;
        private int _deactivateTriggerHash;
        private int _emptryTriggerHash;
        private int _useTriggerHash;
        private bool _hasRuneSlot;

        private MaterialPropertyBlock _materialPropertyBlock;

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
            _materialPropertyBlock = new MaterialPropertyBlock();
            _renderer = GetComponentInChildren<MeshRenderer>();
            _animator = GetComponentInChildren<Animator>();
            _text = GetComponentInChildren<TextMesh>();
            _collider = GetComponent<BoxCollider>();
            _activateTriggerHash = Animator.StringToHash(_activateTrigger);
            _deactivateTriggerHash = Animator.StringToHash(_deactivateTrigger);
            _emptryTriggerHash = Animator.StringToHash("Empty");
            _useTriggerHash = Animator.StringToHash("Use");
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
            _animator.SetBool(_emptryTriggerHash,true);
        }

        public void SetTexture(Texture2D texure)
        {
            _renderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetTexture("_MainTex", texure);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }

        private void ActivateRune()
        {
            SetAnimationTrigger(_deactivateTriggerHash, _activateTriggerHash);
        }

        private void DeactivateRune()
        {
            SetAnimationTrigger(_activateTriggerHash,_deactivateTriggerHash);
        }

        public void SetUseOpportunity(bool opportunity)
        {
            _hasRuneSlot = opportunity;
        }

        private void OnMouseDown()
        {
            RunePressedEvent.Invoke(this);
            _animator.SetTrigger(_useTriggerHash);
        }

        private void OnMouseEnter()
        {
            ActivateRune();
        }

        private void OnMouseExit()
        {
            
            DeactivateRune();
        }

        private void SetAnimationTrigger(int triggerToReset, int triggerToSet)
        {
            _animator.ResetTrigger(triggerToReset);
            _animator.SetTrigger(triggerToSet);
        }
    }
}