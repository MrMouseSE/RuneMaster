using UnityEngine;

public class SkillButton : MonoBehaviour
{
    public Transform EffectHolder;
    
    [SerializeField]
    private GameObject AttackEffect;
    
    private void OnMouseDown()
    {
        Instantiate(AttackEffect, EffectHolder.position, EffectHolder.rotation);
    }
}
