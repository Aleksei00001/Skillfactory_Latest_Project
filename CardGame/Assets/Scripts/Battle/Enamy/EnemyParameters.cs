using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyParameters : ScriptableObject
{
    [SerializeField] private string m_EnemyName;
    public string enemyName => m_EnemyName;

    [SerializeField] private Sprite m_Sprite;
    public Sprite sprite => m_Sprite;

    [SerializeField] private float m_MaxHP;
    public float maxHP => m_MaxHP;

    [SerializeField] private float m_Damage;
    public float damage => m_Damage;
}
