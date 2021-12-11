#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Runes
{
    public class RuneSoCreator : EditorWindow
    {
        private static Object _selectedRuneSprite;
        
        private int _healValue = 0;
        private float _healMultiplyer = 1;
        private float _healOverTime = 0;
        private GameObject _additionalHealEffect = null;
        private int _attackDamage = 0;
        private float _attackMultiplyer = 1;
        private float _attackRadiusMultiplyer = 1;
        private float _attackDamageOverTime = 0;
        private GameObject _additionalAttackEffect = null;
        private int _hitPointBonus = 0;
        private float _hitPointMultiplyer = 1;
        private float _hitPointRegeneration = 0;
        private GameObject _additionalHitPointEffect = null;
        private float _dropChance = 0;
        private float _crackChance = 0;
        private static EditorWindow _window;

        [MenuItem("Assets/Rune", false,10)]
        private static void CreateNewAssets()
        {
            var selectedRuneSprites = Selection.objects;
            foreach (var selectedRuneSprite in selectedRuneSprites)
            {
                _selectedRuneSprite = selectedRuneSprite;
                _window = GetWindow(typeof(RuneSoCreator));
                _window.Show();
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(_selectedRuneSprite.name);
            EditorGUILayout.Space();
            _healValue = EditorGUILayout.IntField("Heal Value", _healValue);
            _healMultiplyer = EditorGUILayout.FloatField("Heal Multiplyer", _healMultiplyer);
            _healOverTime = EditorGUILayout.FloatField("Heal Over Time", _healOverTime);
            _additionalHealEffect = EditorGUILayout.ObjectField("Heal Effect", _additionalHealEffect, typeof(GameObject)) as GameObject;
            _attackDamage = EditorGUILayout.IntField("Attack Damage", _attackDamage);
            _attackMultiplyer = EditorGUILayout.FloatField("Attack Multiplyer", _attackMultiplyer);
            _attackRadiusMultiplyer = EditorGUILayout.FloatField("Attack Radius Multiplyer", _attackRadiusMultiplyer);
            _attackDamageOverTime = EditorGUILayout.FloatField("Damage Over Time", _attackDamageOverTime);
            _additionalAttackEffect = EditorGUILayout.ObjectField("Attack Effect", _additionalAttackEffect, typeof(GameObject)) as GameObject;
            _hitPointBonus = EditorGUILayout.IntField("Hit Point Bonus", _hitPointBonus);
            _hitPointMultiplyer = EditorGUILayout.FloatField("Hitpoints Multiplyer", _hitPointMultiplyer);
            _hitPointRegeneration = EditorGUILayout.FloatField("Hitpoint Regen", _hitPointRegeneration);
            _additionalHitPointEffect = EditorGUILayout.ObjectField("Hitpoint Effect", _additionalHitPointEffect, typeof(GameObject)) as GameObject;
            _dropChance = EditorGUILayout.FloatField("Drop %", _dropChance);
            _crackChance = EditorGUILayout.FloatField("Crack %", _crackChance);

            if(GUILayout.Button("CreateSO"))
            {
                CreateScriptableObjects();
                _window.Close();
            }
        }
        

        private void CreateScriptableObjects()
        {
            RunePropertyContainer asset = ScriptableObject.CreateInstance<RunePropertyContainer>();
            
            asset.RuneName = _selectedRuneSprite.name;
            asset.HealValue = _healValue;
            asset.HealMultiplyer = _healMultiplyer;
            asset.HealOverTime = _healOverTime;
            asset.AdditionalHealEffect = _additionalHealEffect;
            asset.AttackDamage = _attackDamage;
            asset.AttackMultiplyer = _attackMultiplyer;
            asset.AttackRadiusMultiplyer = _attackRadiusMultiplyer;
            asset.AttackDamageOverTime = _attackDamageOverTime;
            asset.AdditionalAttackEffect = _additionalAttackEffect;
            asset.HitPointBonus = _hitPointBonus;
            asset.HitPointMultiplyer = _hitPointMultiplyer;
            asset.HitPointRegeneration = _hitPointRegeneration;
            asset.AdditionalHealEffect = _additionalHealEffect;
            asset.DropChance = _dropChance;
            asset.CrackChance = _crackChance;
            
            string path = AssetDatabase.GetAssetPath(_selectedRuneSprite);
            path = path.Split('.')[0];
            path += "_Rune_Container";
            AssetDatabase.CreateAsset(asset, path + ".asset");
            
            AssetDatabase.SaveAssets();
        }
    }
}
#endif