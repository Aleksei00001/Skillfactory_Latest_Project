using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item prefabItem;
    [SerializeField] private SlotEquipment prefabSlotEquipment;

    [SerializeField] private List<SlotEquipment> m_Content;
    public List<SlotEquipment> content => m_Content;

    [SerializeField] private List<SlotEquipment> m_SwapList;
    public List<SlotEquipment> swapList => m_SwapList;

    [SerializeField] private Camera camera;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            AddSlot();
        }
    }

    private void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
        for (int i = 0; i < m_Content.Count; i++)
        {
            if (m_Content[i] != null)
            {
                m_Content[i].transform.localPosition = new Vector3((i % 5) * 1.5f + 8, -(i / 5) * 1.5f + 7, -5);
            }
        }
    }

    public void AddItem()
    {
        Item newItem = Instantiate<Item>(prefabItem);
        newItem.transform.SetParent(this.transform);
        for (int i = 0; i < m_Content.Count; i++)
        {
            if (m_Content[i].item == null)
            {
                m_Content[i].AddItem(newItem);
                break;
            }
        }
    }
    public void AddSlot()
    {
        SlotEquipment newSlotEquipment = Instantiate<SlotEquipment>(prefabSlotEquipment);
        newSlotEquipment.transform.SetParent(this.transform);
        m_Content.Add(newSlotEquipment);
    }

    public void AddSwap(SlotEquipment slotEquipment)
    {
        m_SwapList.Add(slotEquipment);

        for (int i = m_SwapList.Count - 1; i >= 0; i--)
        {
            if (m_SwapList[i] == null)
            {
                m_SwapList.Remove(m_SwapList[i]);
            }
        }

        if (m_SwapList.Count >= 2)
        {
            if (m_SwapList[0].item == null && m_SwapList[1].item == null)
            {
            }
            else if (m_SwapList[0].item == null)
            {
                if (m_SwapList[1].item.typeEquipment == m_SwapList[0].typeEquipment || TypeEquipment.All == m_SwapList[0].typeEquipment)
                {
                    m_SwapList[0].AddItem(m_SwapList[1].item);
                    m_SwapList[1].RemoveItem();
                }
            }
            else if (m_SwapList[1].item == null)
            {
                if (m_SwapList[0].item.typeEquipment == m_SwapList[1].typeEquipment || TypeEquipment.All == m_SwapList[1].typeEquipment)
                {
                    m_SwapList[1].AddItem(m_SwapList[0].item);
                    m_SwapList[0].RemoveItem();
                }
            }
            else if (((m_SwapList[0].item.typeEquipment == m_SwapList[1].typeEquipment || TypeEquipment.All == m_SwapList[0].typeEquipment) && (m_SwapList[1].item.typeEquipment == m_SwapList[0].typeEquipment || TypeEquipment.All == m_SwapList[1].typeEquipment)))
            {
                Item tempItem = m_SwapList[0].item;
                m_SwapList[0].AddItem(m_SwapList[1].item);
                m_SwapList[1].AddItem(tempItem);
            }
            m_SwapList[1].UnSelect();
            m_SwapList[0].UnSelect();

        }
    }

    public void RemoveSwap(SlotEquipment slotEquipment)
    {
        m_SwapList.Remove(slotEquipment);
    }
}
