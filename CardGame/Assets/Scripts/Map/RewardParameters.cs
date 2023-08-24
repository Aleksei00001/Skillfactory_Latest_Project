using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class RewardParameters : ScriptableObject
{
    [SerializeField] private int m_CountRewards;
    public int countRewards => m_CountRewards;

    [SerializeField] [HideInInspector] private ItemParameters[] m_ItemParameters;
    public ItemParameters[] itemParameters => m_ItemParameters;
    [SerializeField] [HideInInspector] private float[] m_ChanceGet;
    public float[] chanceGet => m_ChanceGet;
    [SerializeField] [HideInInspector] private int[] m_MaxCountGet;
    public int[] maxCountGet => m_MaxCountGet;

    [SerializeField] [HideInInspector] private float m_XPRewards;
    public float XPRewards => m_XPRewards;

#if UNITY_EDITOR

    [CustomEditor(typeof(RewardParameters))]
    [SerializeField]
    public class RewardParametersEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            RewardParameters reward = (RewardParameters)target;

            if (reward.m_CountRewards != reward.m_ItemParameters.Length)
            {
                ItemParameters[] tempItemParameters = reward.m_ItemParameters;
                reward.m_ItemParameters = new ItemParameters[reward.m_CountRewards];
                float[] tempChanceGet = reward.m_ChanceGet;
                reward.m_ChanceGet = new float[reward.m_CountRewards];
                int[] tempMaxCountGet = reward.m_MaxCountGet;
                reward.m_MaxCountGet = new int[reward.m_CountRewards];
                for (int i = 0; i < reward.m_CountRewards; i++)
                {
                    if (tempItemParameters.Length > i)
                    {
                        reward.m_ItemParameters[i] = tempItemParameters[i];
                        reward.m_ChanceGet[i] = tempChanceGet[i];
                        reward.m_MaxCountGet[i] = tempMaxCountGet[i];
                    }
                }
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Item parameters", GUILayout.MaxWidth(150));
            EditorGUILayout.LabelField("Chance Get", GUILayout.MaxWidth(150));
            EditorGUILayout.LabelField("Max count get", GUILayout.MaxWidth(150));
            EditorGUILayout.EndHorizontal();
            for (int i = 0; i < reward.m_CountRewards; i++)
            {


                EditorGUILayout.BeginHorizontal();
                reward.m_ItemParameters[i] = EditorGUILayout.ObjectField(reward.m_ItemParameters[i], typeof(ItemParameters), true, GUILayout.MaxWidth(150)) as ItemParameters;
                reward.m_ChanceGet[i] = EditorGUILayout.Slider(reward.m_ChanceGet[i], 0f, 1f, GUILayout.MaxWidth(150));
                reward.m_MaxCountGet[i] = EditorGUILayout.IntField(reward.m_MaxCountGet[i], GUILayout.MaxWidth(150));
                EditorGUILayout.EndHorizontal();
            }

            reward.m_XPRewards = EditorGUILayout.FloatField("XP rewards", reward.m_XPRewards);
        }
    }

#endif
}
