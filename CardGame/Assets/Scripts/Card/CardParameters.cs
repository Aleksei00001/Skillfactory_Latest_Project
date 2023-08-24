using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class CardParameters : ScriptableObject
{
    [SerializeField]  private string m_CardName;
    public string cardName => m_CardName;

    [SerializeField] [HideInInspector] private string m_CardInfo;
    public string cardInfo => m_CardInfo;


    [SerializeField] [HideInInspector] private Color32 m_Color;
    public Color32 color => m_Color;

    [SerializeField] [HideInInspector] private bool m_IsAtack;
    public bool isAtack => m_IsAtack;

    [SerializeField] [HideInInspector] private AtackType m_AtackType;
    public AtackType atackType => m_AtackType;

    [SerializeField] [HideInInspector] private float m_Damage;
    public float damage => m_Damage;

    [SerializeField] [HideInInspector] private bool[] m_AreaAtack = new bool[81];
    public bool[] areaAtack => m_AreaAtack;

    [SerializeField] [HideInInspector] private float m_MPCost;
    public float MPCost => m_MPCost;

#if UNITY_EDITOR

    [CustomEditor(typeof(CardParameters))]
    [SerializeField] [Serializable] public class CardParametersEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CardParameters cardParameters = (CardParameters)target;


            //cardParameters.m_CardName = EditorGUILayout.TextField("Card Name", cardParameters.m_CardName);

            cardParameters.m_CardInfo = EditorGUILayout.TextField("Card Info", cardParameters.m_CardInfo);

            cardParameters.m_Color = EditorGUILayout.ColorField("Color", cardParameters.m_Color);

            cardParameters.m_MPCost = EditorGUILayout.FloatField("MP Cost", cardParameters.m_MPCost);


            cardParameters.m_IsAtack = EditorGUILayout.Toggle("Is Atack", cardParameters.m_IsAtack);

            if (cardParameters.m_IsAtack == true)
            {
                cardParameters.m_AtackType = (AtackType)EditorGUILayout.EnumPopup("Atack Type", cardParameters.m_AtackType);

                if (cardParameters.m_AtackType == AtackType.Target)
                {
                    cardParameters.m_Damage = EditorGUILayout.FloatField("Damage", cardParameters.m_Damage);
                }

                if (cardParameters.m_AtackType == AtackType.Area)
                {
                    cardParameters.m_Damage = EditorGUILayout.FloatField("Damage", cardParameters.m_Damage);

                    EditorGUILayout.LabelField("Area Atack");

                    for (int i = 8; i >= 0; i--)
                    {
                        EditorGUILayout.BeginHorizontal();
                        for (int j = 0; j < 9; j++)
                        {
                            cardParameters.m_AreaAtack[j + i * 9] = EditorGUILayout.Toggle(cardParameters.m_AreaAtack[j + i * 9], GUILayout.MaxWidth(15), GUILayout.MaxHeight(15)); 
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorUtility.SetDirty(cardParameters);


                    //string arrayValue = "";
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    for (int j = 0; j < 9; j++)
                    //    {
                    //        arrayValue += cardParameters.m_AreaAtack[i, j];
                    //    }
                    //}

                    //PlayerPrefs.SetString(this.name, arrayValue);

                    //arrayValue = PlayerPrefs.GetString(this.name);

                    //for (int i = 0; i < 9; i++)
                    //{
                    //    for (int j = 0; j < 9; j++)
                    //    {
                    //        if (arrayValue[i + j * 9] == 1)
                    //        {
                    //            cardParameters.m_AreaAtack[i, j] = true;
                    //        }
                    //        else
                    //        {
                    //            cardParameters.m_AreaAtack[i, j] = false;
                    //        }
                    //    }
                    //}

                }
            }
        }
    }

#endif
}
