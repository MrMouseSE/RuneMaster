using System.Collections;
using UnityEngine;

namespace BattleScripts
{
    public class DemonContainer : MonoBehaviour
    {
        public Renderer MyRenderer;
        public Transform Scaler;
        public Animator MyAnimator;
        public float AttackRadius;

        private int _hitPoint;
        private float _speed;
        private Resist[] _resists;
        private float _sizeMultiplyer;
        private Color _colorize;

        private MaterialPropertyBlock _mpb;
        private Transform _myTransform;
        private Transform _player;

        private bool _isInitialize;

        private void Awake()
        {
            _mpb = new MaterialPropertyBlock();
            MyRenderer.GetPropertyBlock(_mpb);
            _myTransform = transform;
        }

        public void InitializeBySO(DemonStats so, Transform player)
        {
            _player = player;
            _hitPoint = so.HitPoint;
            _speed = so.Speed;
            _resists = so.Resists;
            _sizeMultiplyer = so.SizeMultiplyer;
            _colorize = so.Colorize;
            SetUpMe();
        }

        private void SetUpMe()
        {
            _mpb.SetColor("_Colorize", _colorize);
            MyRenderer.SetPropertyBlock(_mpb);

            Scaler.localScale *= _sizeMultiplyer;
            MyAnimator.SetFloat("Speed", _speed);
            _isInitialize = true;
        }

        public void Hurt(float damage, DamageTypes type)
        {
            damage = (int) Mathf.Round(damage * GetResist(type));
            _hitPoint -= (int) Mathf.Round(damage);
            if (_hitPoint < 0)
            {
                Die();
                return;
            }
            SetAnimatorTrigger("Hit");
        }

        private float GetResist(DamageTypes type)
        {
            float resist = 0;
            for (int i = 0; i < _resists.Length; i++)
            {
                if (_resists[i].Type == type)
                {
                    resist = _resists[i].ResistValue;
                }
            }

            resist = 1 - resist/100f;
            return resist;
        }

        private void Die()
        {
            StopMe();
            SetAnimatorTrigger("Dying");
            StartCoroutine(BodyDesappear());
        }

        private void Update()
        {
            if (!_isInitialize ) return;
            var vec = _player.position - _myTransform.position;
            if (vec.magnitude < AttackRadius)
            {
                StopMe();
                SetAnimatorTrigger("Attack");
            }
            _myTransform.LookAt(_player);
            _myTransform.Translate(vec.normalized * _speed * Time.deltaTime*1.4f);
        }

        private void SetAnimatorTrigger(string trigger)
        {
            MyAnimator.SetTrigger(trigger);
        }

        private void StopMe()
        {
            _speed = 0;
            MyAnimator.SetFloat("Speed", _speed);
            _isInitialize = false;
        }

        private IEnumerator BodyDesappear()
        {
            while (_myTransform.position.y>-1)
            {
                _myTransform.Translate(Vector3.down * Time.deltaTime * 0.3f);
                yield return new WaitForEndOfFrame();
            }
            Destroy(gameObject);
        }
    }
}