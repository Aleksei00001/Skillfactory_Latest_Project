using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class UpgradeParameters : ScriptableObject
{
    [SerializeField] private string m_UpgradeName;
    public string upgradeName => m_UpgradeName;

    [SerializeField] private float m_HPBonus;
    public float HPBonus => m_HPBonus;

    [SerializeField] private int m_Count;

    [SerializeField][HideInInspector] private List<CardParameters> m_CardParameters;
    public List<CardParameters> cardParameters => m_CardParameters;

    [SerializeField][HideInInspector] private List<float> m_ChanceGetCard;
    public List<float> chanceGetCard => m_ChanceGetCard;



#if UNITY_EDITOR

    [CustomEditor(typeof(UpgradeParameters))]
    [SerializeField]
    public class UpgradeParametersEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            UpgradeParameters upgrade = (UpgradeParameters)target;

            while (upgrade.m_CardParameters.Count != upgrade.m_Count)
            {
                if (upgrade.m_CardParameters.Count < upgrade.m_Count)
                {
                    upgrade.m_CardParameters.Add(new CardParameters());
                }
                else if (upgrade.m_CardParameters.Count > upgrade.m_Count)
                {
                    upgrade.m_CardParameters.Remove(upgrade.m_CardParameters[upgrade.m_CardParameters.Count - 1]);
                }
            }
            while (upgrade.m_ChanceGetCard.Count != upgrade.m_Count)
            {
                if (upgrade.m_ChanceGetCard.Count < upgrade.m_Count)
                {
                    upgrade.m_ChanceGetCard.Add(new float());
                }
                else if (upgrade.m_ChanceGetCard.Count > upgrade.m_Count)
                {
                    upgrade.m_ChanceGetCard.Remove(upgrade.m_ChanceGetCard[upgrade.m_ChanceGetCard.Count - 1]);
                }
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Card parameters", GUILayout.MaxWidth(150));
            EditorGUILayout.LabelField("Chance Get", GUILayout.MaxWidth(150));
            EditorGUILayout.EndHorizontal();
            for (int i = 0; i < upgrade.m_CardParameters.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                upgrade.m_CardParameters[i] = EditorGUILayout.ObjectField(upgrade.m_CardParameters[i], typeof(CardParameters), true, GUILayout.MaxWidth(150)) as CardParameters;
                upgrade.m_ChanceGetCard[i] = EditorGUILayout.Slider(upgrade.m_ChanceGetCard[i], 0f, 1f, GUILayout.MaxWidth(150));
                EditorGUILayout.EndHorizontal();
            }
        }
    }

#endif

}
