using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CardPlaybackArea cardPlaybackArea;

    private Player player;

    [SerializeField] private EnemyParameters enemyParameters;

    [SerializeField] private UIEnamyUpdate m_UIEnamyUpdate;

    [SerializeField] private string m_EnemyName;
    public string enemyName => m_EnemyName;

    [SerializeField] private Sprite m_Sprite;
    public Sprite sprite => m_Sprite;

    [SerializeField] private float m_MaxHP;
    public float MaxHP => m_MaxHP;
    [SerializeField] private float m_HP;
    public float HP => m_HP;

    [SerializeField] private float m_Damage;
    public float damage => m_Damage;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        SetParameters(enemyParameters);
        cardPlaybackArea = FindObjectOfType<CardPlaybackArea>().GetComponent<CardPlaybackArea>();
        player = FindObjectOfType<Player>().GetComponent<Player>();
        cardPlaybackArea.enemys.Add(this);
    }

    public void SetEnEnemyParameters(EnemyParameters enemyParameters)
    {
        this.enemyParameters = enemyParameters;
    }

    private void SetParameters(EnemyParameters enemyParametrs)
    {
        m_MaxHP = enemyParametrs.maxHP;
        m_HP = m_MaxHP;
        m_Damage = enemyParametrs.damage;
        m_EnemyName = enemyParametrs.enemyName;
        m_Sprite = enemyParametrs.sprite;
        spriteRenderer.sprite = m_Sprite;
    }

    public void GetDamage(float damage)
    {
        ChangeHP(-damage);
    }

    public void GetHeal(float heal)
    {
        ChangeHP(heal);
    }

    public void ChangeHP(float changeHP)
    {
        m_HP += changeHP;

        if (m_HP <= 0)
        {
            Destroy(this.gameObject);
        }

        if (m_HP > m_MaxHP)
        {
            m_HP = m_MaxHP;
        }

        m_UIEnamyUpdate.UpdateImageHP(m_HP, m_MaxHP);
    }

    public void Action()
    {
        player.GetDamage(damage);
    }

    private void OnDestroy()
    {
        cardPlaybackArea.enemys.Remove(this);
    }
}
