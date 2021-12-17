using System;
using UnityEngine;

namespace BattleScripts
{
    [CreateAssetMenu(menuName = "DemonStats", fileName = "DemonStats", order = 15)]
    public class DemonStats : ScriptableObject
    {
        public int HitPoint;
        public float Speed;
        public Resist[] Resists;
        public float SizeMultiplyer;
        public Color Colorize;
        public float RuneDropBoost;
    }
}

[Serializable]
public class Resist
{
    public DamageTypes Type;
    public float ResistValue;
}

public enum DamageTypes
{
    Water,
    Earth,
    Magic
}