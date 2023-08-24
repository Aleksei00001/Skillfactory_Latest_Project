using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class LevelRule : ScriptableObject
{
    [SerializeField] private Sprite m_BackGround;
    public Sprite backGround => m_BackGround;

    [SerializeField] private int m_WaveCount;
    public int waveCount => m_WaveCount;

    [SerializeField] [HideInInspector] private int[] m_CountTypeEnemy;
    public int[] countTypeEnemy => m_CountTypeEnemy;

    //[SerializeField] private Wave m_Wave;
    //public Wave wave => m_Wave;

    [SerializeField] [HideInInspector] private EnemyParameters[] m_WaveContent;
    public EnemyParameters[] waveContent => m_WaveContent;

    [SerializeField] [HideInInspector] private int[] m_WaveSize;
    public int[] waveSize => m_WaveSize;

    [SerializeField] [HideInInspector] int[] tempCountTypeEnemy;
    //[SerializeField] private Wave1 m_Wave;
    //public Wave1 wave => m_Wave;

    
    //public class Wave1 : MonoBehaviour
    //{
    //    [SerializeField] public EnemyParameters m_EnemyParametrs;
    //    public EnemyParameters enemyParametrs => m_EnemyParametrs;
    //    [SerializeField] public int m_CountEnemy;
    //    public int countEnemy => m_CountEnemy;
    //}

#if UNITY_EDITOR

    [CustomEditor(typeof(LevelRule))]
    [SerializeField]
    [Serializable]
    public class LevelRuleEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelRule levelRule = (LevelRule)target;
            //LevelRule levelRule = new LevelRule();

            
            if (levelRule.m_CountTypeEnemy.Length != levelRule.m_WaveCount)
            {
                
                levelRule.m_CountTypeEnemy = new int[levelRule.m_WaveCount];
                for (int j = 0; j < levelRule.tempCountTypeEnemy.Length; j++)
                {
                    if (levelRule.m_CountTypeEnemy.Length > j)
                    {
                        levelRule.m_CountTypeEnemy[j] = levelRule.tempCountTypeEnemy[j];
                    }
                }






            }


            int allCountTypeEnemy = 0;
            for (int i = 0; i < levelRule.m_CountTypeEnemy.Length; i++)
            {
                allCountTypeEnemy += levelRule.m_CountTypeEnemy[i];
            }


            if (allCountTypeEnemy != levelRule.m_WaveContent.Length)
            {
                EnemyParameters[] tempWaveContent = levelRule.m_WaveContent;
                levelRule.m_WaveContent = new EnemyParameters[allCountTypeEnemy];
                int[] tempWaveSize = levelRule.m_WaveSize;
                levelRule.m_WaveSize = new int[allCountTypeEnemy];
                int newContentPosition = 0;
                int oldContentPosition = 0;
                for (int i = 0; i < levelRule.tempCountTypeEnemy.Length; i++)
                {
                    for (int j = 0; j < levelRule.tempCountTypeEnemy[i]; j++)
                    {
                        if (levelRule.m_CountTypeEnemy[i] > j)
                        {
                            levelRule.m_WaveContent[newContentPosition + j] = tempWaveContent[oldContentPosition + j];
                            levelRule.m_WaveSize[newContentPosition + j] = tempWaveSize[oldContentPosition + j];
                        }
                    }
                    newContentPosition += levelRule.m_CountTypeEnemy[i];
                    oldContentPosition += levelRule.tempCountTypeEnemy[i];
                }
                levelRule.tempCountTypeEnemy = levelRule.m_CountTypeEnemy;
                levelRule.tempCountTypeEnemy = new int[levelRule.m_WaveCount];
                for(int q = 0; q < levelRule.m_CountTypeEnemy.Length; q++)
                {
                    levelRule.tempCountTypeEnemy[q] = levelRule.m_CountTypeEnemy[q];
                }

            }
            
            //if (levelRule.m_WaveContent.Length < allCountTypeEnemy)
            //{
            //    //EnemyParameters[] tempWaveContent = levelRule.m_WaveContent;
            //    for (int j = 0; j < tempWaveContent.Length; j++)
            //    {
            //        if (levelRule.m_WaveContent.Length > j)
            //        {
            //            levelRule.m_WaveContent[j] = tempWaveContent[j];
            //        }
            //    }
            //    levelRule.m_WaveContent = new EnemyParameters[allCountTypeEnemy];
            //}

            //if (levelRule.m_WaveSize.Length < allCountTypeEnemy)
            //{

            //    levelRule.m_WaveSize = new int[allCountTypeEnemy];
            //}


            int numberWaveContent = 0;
            for (int j = 0; j < levelRule.waveCount; j++)
            {

                EditorGUILayout.LabelField("Wave " + (j + 1));
                //cardParameters.m_CardName = EditorGUILayout.TextField("Card Name", cardParameters.m_CardName);

                levelRule.m_CountTypeEnemy[j] = EditorGUILayout.IntField("Count Type Enemy", levelRule.m_CountTypeEnemy[j]);



                for (int i = 0; i < levelRule.m_CountTypeEnemy[j]; i++)
                {
                    if (numberWaveContent < levelRule.m_WaveContent.Length)
                    {
                        EditorGUILayout.BeginHorizontal();
                        levelRule.m_WaveContent[numberWaveContent] = EditorGUILayout.ObjectField("Enemy parameters", levelRule.m_WaveContent[numberWaveContent], typeof(EnemyParameters), true) as EnemyParameters;
                        levelRule.m_WaveSize[numberWaveContent] = EditorGUILayout.IntField("Enemy count", levelRule.m_WaveSize[numberWaveContent]);
                        EditorGUILayout.EndHorizontal();
                        numberWaveContent++;
                    }
                }
            }
        }

        //levelRule.m_Wave.m_CountEnemy = EditorGUILayout.IntField("Wave", levelRule.m_Wave.m_CountEnemy);

        //levelRule.m_Wave = EditorGUILayout.ObjectField("Wave", levelRule.wave, typeof(Wave), true) as Wave;

        //levelRule.m_Wave.m_CountEnemy = EditorGUILayout.IntField("Wave", levelRule.m_Wave.m_CountEnemy);

        //levelRule.m_Color = EditorGUILayout.ColorField("Color", levelRule.m_Color);





    }


#endif

}
