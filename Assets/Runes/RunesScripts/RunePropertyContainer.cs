using UnityEngine;

namespace Runes.RunesScripts
{
    public class RunePropertyContainer : ScriptableObject
    {
        public string RuneName;
        public Texture2D RuneTexture;
        
        [Space, Tooltip("Heal")]
        public int HealValue;
        public float HealMultiplyer = 1;
        public float HealOverTime = 0;
        public GameObject AdditionalHealEffect;
        
        [Space, Tooltip("Attack")]
        public int AttackDamage;
        public float AttackMultiplyer = 1;
        public float AttackRadiusMultiplyer = 1;
        public float AttackDamageOverTime = 0;
        public GameObject AdditionalAttackEffect;

        [Space, Tooltip("HitPoints")]
        public int HitPointBonus;
        public float HitPointMultiplyer;
        public float HitPointRegeneration;
        public GameObject AdditionalHitPointEffect;

        [Space, Tooltip("Chances")]
        public float DropChance;
        public float CrackChance;

        [Space, Tooltip("Market Data")]
        public float Price;

        [Space, Tooltip("Visual Effect")]
        public Color CommonColor = Color.black;
        public Color PoweredColor = new Color32(0xFB ,0x55 ,0x01, 0xFF);
        public Color DesctroyColor = Color.gray;
    }
}