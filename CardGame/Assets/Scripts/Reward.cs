using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private List<SlotEquipment> m_SlotEquipment;

    [SerializeField] private List<Item> m_Item;

    [SerializeField] private Item itemPrefab;

    [SerializeField] private SlotEquipment slotEquipmentPrefab;

    //[SerializeField] private RewardParameters rewardParameters;

    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;

    private int listNumber = 0;

    private int maxListNumber;

    [SerializeField] private Camera camera;

    [SerializeField] private Player player;

    private void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
    }

    //public void SetRewardParameters(RewardParameters rewardParameters)
    //{
    //    this.rewardParameters = rewardParameters;
    //}

    public void SetReward(RewardParameters rewardParameters)
    {
        Item[] tempItem = GetComponentsInChildren<Item>();
        for (int i = 0; i < tempItem.Length; i++)
        {
            Destroy(tempItem[i].gameObject);
        }
        SlotEquipment[] tempSlotEquipment = GetComponentsInChildren<SlotEquipment>();
        for (int i = 0; i < tempSlotEquipment.Length; i++)
        {
            Destroy(tempSlotEquipment[i].gameObject);
        }
        m_SlotEquipment.Clear();
        m_Item.Clear();

        for (int i = 0; i < rewardParameters.countRewards; i++)
        {
            for (int j = 0; j < rewardParameters.maxCountGet[i]; j++)
            {
                if (Random.RandomRange(0f, 1f) < rewardParameters.chanceGet[i])
                {
                    Item newItem = Instantiate<Item>(itemPrefab);
                    newItem.transform.SetParent(transform);
                    newItem.SetItemParameters(rewardParameters.itemParameters[i]);
                    m_Item.Add(newItem);
                }

            }
        }

        for (int q = 0; q < m_Item.Count; q++)
        {
            SlotEquipment newSlotEquipment = Instantiate<SlotEquipment>(slotEquipmentPrefab);
            newSlotEquipment.transform.SetParent(transform);
            m_SlotEquipment.Add(newSlotEquipment);
            m_SlotEquipment[q].AddItem(m_Item[q]);
        }

        listNumber = 0;
        maxListNumber = (m_SlotEquipment.Count - 1) / 12;

        if (maxListNumber > 0)
        {
            left.SetActive(false);
            right.SetActive(true);
            DrawSlots(listNumber);
        }
        else
        {
            left.SetActive(false);
            right.SetActive(false);
            DrawSlots(listNumber);
        }

        player.GetXP(rewardParameters.XPRewards);
    }

    public void PressLeftButton()
    {
        listNumber--;
        if (listNumber == 0)
        {
            left.SetActive(false);
        }
        if (listNumber < maxListNumber)
        {
            right.SetActive(true);
        }
        DrawSlots(listNumber);
    }

    public void PressRightButton()
    {
        listNumber++;
        if (listNumber > 0)
        {
            left.SetActive(true);
        }
        if (listNumber == maxListNumber)
        {
            right.SetActive(false);
        }
        DrawSlots(listNumber);
    }

    public void DrawSlots(int listNumber)
    {
        for (int i = 0; i < m_SlotEquipment.Count; i++)
        {
            m_SlotEquipment[i].gameObject.SetActive(false);
        }

        if (m_SlotEquipment.Count < (listNumber + 1) * 12)
        {
            for (int i = listNumber * 12; i < m_SlotEquipment.Count; i++)
            {
                if (m_SlotEquipment[i] != null)
                {
                    m_SlotEquipment[i].transform.localPosition = new Vector3(((i - listNumber * 12) % 6) * 1.5f - 3.75f, -((i - listNumber * 12) / 6) * 1.5f + 0.5f, -6);
                    m_SlotEquipment[i].gameObject.SetActive(true);
                }
            }
        }
        else
        {
            for (int i = listNumber * 12; i < (listNumber + 1) * 12; i++)
            {
                if (m_SlotEquipment[i] != null)
                {
                    m_SlotEquipment[i].transform.localPosition = new Vector3(((i - listNumber * 12) % 6) * 1.5f - 3.75f, -((i - listNumber * 12) / 6) * 1.5f + 0.5f, -6);
                    m_SlotEquipment[i].gameObject.SetActive(true);
                }
            }
        }
    }

    //private void Start()
    //{

    //    //SetReward(rewardParameters);

    //    //DrawSlots(listNumber);
    //}
}
