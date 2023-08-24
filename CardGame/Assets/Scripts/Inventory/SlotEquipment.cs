using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotEquipment : MonoBehaviour
{
    [SerializeField] private TypeEquipment m_TypeEquipment;
    public TypeEquipment typeEquipment => m_TypeEquipment;

    [SerializeField] private Item m_Item;
    public Item item => m_Item;

    [SerializeField] private bool m_IsSelect;
    public bool isSelect => m_IsSelect;

    private SpriteRenderer spriteRenderer;
    private Inventory inventory;

    public UnityAction<SlotEquipment> Equipment;
    public UnityAction<SlotEquipment> UnEquipment;

    public void AddItem(Item item)
    {
        RemoveItem();
        m_Item = item;
        m_Item.transform.SetParent(transform);
        Equipment?.Invoke(this);
    }

    public void RemoveItem()
    {
        UnEquipment?.Invoke(this);
        m_Item = null;
    }

    public void EquipItemOnPlayer(Player player)
    {
        if (m_Item != null)
        {
            if (m_Item.cardParameters.Length > 0)
            {
                for (int i = 0; i < m_Item.cardParameters.Length; i++)
                {
                    player.AddCard(m_Item.cardParameters[i], m_Item.chanceGetCard[i]);
                }
            }
            player.ChangeMaxHP(m_Item.bonusHP);
            player.ChangeHP(0);
        }
    }
    public void UnEquipItemOnPlayer(Player player)
    {
        if (m_Item != null)
        {
            if (m_Item.cardParameters.Length > 0)
            {
                for (int i = 0; i < m_Item.cardParameters.Length; i++)
                {
                    player.RemoveCard(m_Item.cardParameters[i]);
                }
            }
            player.ChangeMaxHP(-m_Item.bonusHP);
            player.ChangeHP(0);
        }
    }



    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        Equipment?.Invoke(this);
    }

    private void Update()
    {
        if (m_Item != null)
        {
            m_Item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
        }
    }

    private void OnMouseUpAsButton()
    {
        if (m_IsSelect == true)
        {
            UnSelect();
        }
        else
        {
            Select();
        }
    }

    
    public void Select()
    {
        m_IsSelect = true;
        spriteRenderer.color = new Color32(100, 200, 100, 200);
        inventory.AddSwap(this);
    }
    public void UnSelect()
    {
        m_IsSelect = false;
        spriteRenderer.color = new Color32(255, 255, 255, 255);
        inventory.RemoveSwap(this);
    }
}
