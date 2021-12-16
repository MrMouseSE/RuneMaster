using UnityEngine;

namespace BattleScripts
{
    public class EffectContainer : MonoBehaviour
    {
        public float Speed;

        public float LifeTime;

        public float Damage = 1f;
        public DamageTypes type = DamageTypes.Magic;

        private Transform _myTransform;
        
        private void Awake()
        {
            _myTransform = transform;
        }

        private void Update()
        {
            _myTransform.position = _myTransform.position + _myTransform.forward * Time.deltaTime * Speed;
            LifeTime -= Time.deltaTime;
            if (LifeTime <0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DemonContainer container))
            {
                container.Hurt(Damage,type);
            }
        }
    }
}