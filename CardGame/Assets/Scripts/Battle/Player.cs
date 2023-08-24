using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UITextPlayerUpdate m_UITextPlayerUpdate;

    [SerializeField] private float m_MaxHP;
    public float MaxHP => m_MaxHP;
    [SerializeField] private float m_HP;
    public float HP => m_HP;
    [SerializeField] private float m_HPRegeneration;
    public float HPRegeneration => m_HPRegeneration;

    [SerializeField] private float m_MaxMP;
    public float MaxMP => m_MaxMP;
    [SerializeField] private float m_MP;
    public float MP => m_MP;
    [SerializeField] private float m_MPRegeneration;
    public float MPRegeneration => m_MPRegeneration;

    [SerializeField] private int m_MaxCardsFromUpgrades;
    public int maxCardsFromUpgrades => m_MaxCardsFromUpgrades;

    [SerializeField] private int m_CardsFromUpgrades;
    public int cardsFromUpgrades => m_CardsFromUpgrades;

    [SerializeField] private int m_Level;
    public int level => m_Level;

    [SerializeField] private float m_MaxXP;
    [SerializeField] private float m_XP;

    [SerializeField] private SlotEquipment[] m_SlotEquipment;
    public SlotEquipment[] slotEquipment => m_SlotEquipment;

    [SerializeField] private List<CardParameters> m_CardParameters;
    public List<CardParameters> cardParameters => m_CardParameters;

    [SerializeField] private List<float> m_ChanceGetCard;
    public List<float> chanceGetCard => m_ChanceGetCard;

    [SerializeField] private int m_MaxUpgrades;
    public int maxUpgrades => m_MaxUpgrades;

    [SerializeField] private int m_Upgrades;
    public int upgrades => m_Upgrades;

    private void Start()
    {
        for (int i = 0; i < m_SlotEquipment.Length; i++)
        {
            m_SlotEquipment[i].Equipment += Equipment;
            m_SlotEquipment[i].UnEquipment += UnEquipment;
        }

        m_UITextPlayerUpdate.UpdateTextHP(m_HP, m_MaxHP);
        m_UITextPlayerUpdate.UpdateTextLevel(m_Level);
        m_UITextPlayerUpdate.UpdateTextXP(m_XP, m_MaxXP);
        m_UITextPlayerUpdate.UpdateTextMP(m_MP, m_MaxMP);
        m_UITextPlayerUpdate.UpdateTextHPRegeneration(m_HPRegeneration);
        m_UITextPlayerUpdate.UpdateTextMPRegeneration(m_MPRegeneration);
    }

    public void Equipment(SlotEquipment slotEquipment)
    {
        slotEquipment.EquipItemOnPlayer(this);
    }
    public void UnEquipment(SlotEquipment slotEquipment)
    {
        slotEquipment.UnEquipItemOnPlayer(this);
    }

    public void AddCard(CardParameters cardParameters, float chanceGetCard)
    {
        m_CardParameters.Add(cardParameters);
        m_ChanceGetCard.Add(chanceGetCard);
    }
    public void RemoveCard(CardParameters cardParameters)
    {
        int deleteIndex = m_CardParameters.IndexOf(cardParameters);
        m_CardParameters.RemoveAt(deleteIndex);
        m_ChanceGetCard.RemoveAt(deleteIndex);
    }

    public void ChangeMaxHP(float changeMaxHP)
    {
        m_MaxHP += changeMaxHP;
        if (m_HP > m_MaxHP)
        {
            m_HP = m_MaxHP;
        }
        FullRegeneration();
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
            m_HP = 0;
        }

        if (m_HP > m_MaxHP)
        {
            m_HP = m_MaxHP;
        }

        m_UITextPlayerUpdate.UpdateTextHP(m_HP, m_MaxHP);
    }

    public void ChangeMP(float changeMP)
    {
        m_MP += changeMP;

        if (m_MP <= 0)
        {
            m_MP = 0;
        }

        if (m_MP > m_MaxMP)
        {
            m_MP = m_MaxMP;
        }

        m_UITextPlayerUpdate.UpdateTextMP(m_MP, m_MaxMP);
    }

    public void LevelUP()
    {
        m_XP -= m_MaxXP;
        m_Level += 1;
        m_MaxUpgrades += 1;
        if (m_XP >= m_MaxXP)
        {
            LevelUP();
        }
        m_UITextPlayerUpdate.UpdateTextLevel(m_Level);
    }

    public void GetXP(float XP)
    {
        m_XP += XP;
        if(m_XP >= m_MaxXP)
        {
            LevelUP();
        }
        m_UITextPlayerUpdate.UpdateTextXP(m_XP, m_MaxXP);
    }

    private void Update()
    {
        //ChangeHP(0);   
    }

    public void ChangeCardsFromUpgrades(int change)
    {
        m_CardsFromUpgrades += change;
    }

    public void ChangeUpgrades(int change)
    {
        m_Upgrades += change;
    }

    public void Regeneration()
    {
        ChangeHP(m_HPRegeneration);
        ChangeMP(m_MPRegeneration);
    }

    public void FullRegeneration()
    {
        ChangeHP(m_MaxHP);
        ChangeMP(m_MaxMP);
    }
}
