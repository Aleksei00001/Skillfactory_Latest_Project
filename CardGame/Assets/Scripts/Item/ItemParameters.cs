using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class ItemParameters : ScriptableObject
{
    [SerializeField] private string m_ItemName;
    public string itemName => m_ItemName;

    [SerializeField] private string m_ItemInfo;
    public string itemInfo => m_ItemInfo;

    [SerializeField] private Color32 m_Color;
    public Color32 color => m_Color;

    [SerializeField] [HideInInspector] private int m_CountCards;

    [SerializeField] [HideInInspector] private CardParameters[] m_CardParameters;
    public CardParameters[] cardParameters => m_CardParameters;

    [SerializeField] [HideInInspector] private float[] m_ChanceGetCard;
    public float[] chanceGetCard => m_ChanceGetCard;

    [SerializeField] private TypeEquipment m_TypeEquipment;
    public TypeEquipment typeEquipment => m_TypeEquipment;

    [SerializeField] private Sprite m_Sprite;
    public Sprite sprite => m_Sprite;

    [SerializeField] private float m_BonusHP;
    public float bonusHP => m_BonusHP;

#if UNITY_EDITOR

    [CustomEditor(typeof(ItemParameters))]
    public class ItemParametersEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ItemParameters Item = (ItemParameters)target;

            Item.m_CountCards = EditorGUILayout.IntField("Count cards", Item.m_CountCards);

            if (Item.m_CountCards != Item.m_CardParameters.Length)
            {
                CardParameters[] tempCardParameters = Item.m_CardParameters;
                Item.m_CardParameters = new CardParameters[Item.m_CountCards];
                float[] tempChanceGetCard = Item.m_ChanceGetCard;
                Item.m_ChanceGetCard = new float[Item.m_CountCards];
                for (int i = 0; i < Item.m_CountCards; i++)
                {
                    if (tempCardParameters.Length > i)
                    {
                        Item.m_CardParameters[i] = tempCardParameters[i];
                        Item.m_ChanceGetCard[i] = tempChanceGetCard[i];
                    }
                }
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Card parameters", GUILayout.MaxWidth(250));
            EditorGUILayout.LabelField("Chance get", GUILayout.MaxWidth(250));
            EditorGUILayout.EndHorizontal();
            for (int i = 0; i < Item.m_CountCards; i++)
            {
                EditorGUILayout.BeginHorizontal();
                Item.m_CardParameters[i] = EditorGUILayout.ObjectField(Item.m_CardParameters[i], typeof(CardParameters), true, GUILayout.MaxWidth(250)) as CardParameters;
                Item.m_ChanceGetCard[i] = EditorGUILayout.Slider(Item.m_ChanceGetCard[i], 0f, 1f, GUILayout.MaxWidth(250));
                EditorGUILayout.EndHorizontal();
            }
        }
    }

#endif
}
