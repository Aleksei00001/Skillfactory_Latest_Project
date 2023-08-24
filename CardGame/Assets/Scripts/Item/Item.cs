using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeEquipment
{
    All,
    Weapons,
    Armor
}
public class Item : MonoBehaviour
{   
    [SerializeField] private AllItem allItem;


    [SerializeField] private string m_ItemName;
    public string itemName => m_ItemName;

    [SerializeField] private string m_ItemInfo;
    public string itemInfo => m_ItemInfo;

    [SerializeField] private Color32 m_Color;
    public Color32 color => m_Color;

    [SerializeField] private ItemParameters itemParameters;

    [SerializeField] private CardParameters[] m_CardParameters;
    public CardParameters[] cardParameters => m_CardParameters;

    [SerializeField] private float[] m_ChanceGetCard;
    public float[] chanceGetCard => m_ChanceGetCard;

    [SerializeField] private TypeEquipment m_TypeEquipment;
    public TypeEquipment typeEquipment => m_TypeEquipment;

    [SerializeField] private SpriteRenderer cardTexture;

    [SerializeField] private Sprite m_Sprite;
    public Sprite sprite => m_Sprite;

    [SerializeField] private float m_BonusHP;
    public float bonusHP => m_BonusHP;

    private void Start()
    {
        itemParameters = allItem.allItems[Random.Range(0, allItem.allItems.Length)];
        //SetItemParameters(itemParameters);
    }

    public void SetItemParameters(ItemParameters itemParameters)
    {
        m_ItemName = itemParameters.itemName;
        m_ItemInfo = itemParameters.itemInfo;
        m_Color = itemParameters.color;
        m_CardParameters = itemParameters.cardParameters;
        m_ChanceGetCard = itemParameters.chanceGetCard;
        m_TypeEquipment = itemParameters.typeEquipment;
        m_Sprite = itemParameters.sprite;
        m_BonusHP = itemParameters.bonusHP;

        cardTexture.sprite = m_Sprite;
        cardTexture.color = m_Color;
    }
}
