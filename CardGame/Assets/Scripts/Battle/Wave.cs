using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class Wave : MonoBehaviour
{
    [SerializeField] public EnemyParameters m_EnemyParametrs;
    public EnemyParameters enemyParametrs => m_EnemyParametrs;
    [SerializeField] public int m_CountEnemy;
    public int countEnemy => m_CountEnemy;


#if UNITY_EDITOR

    [CustomEditor(typeof(Wave))]
    public class WaveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Wave wave = (Wave)target;


            //cardParameters.m_CardName = EditorGUILayout.TextField("Card Name", cardParameters.m_CardName);

            //wave.m_EnemyParametrs = EditorGUILayout.PropertyField("Card Info", wave.m_EnemyParametrs);

            //levelRule.m_Color = EditorGUILayout.ColorField("Color", levelRule.m_Color);


        }
    }



#endif


}
