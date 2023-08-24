using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItem : MonoBehaviour
{
    [SerializeField] private ItemParameters[] m_AllItems;
    public ItemParameters[] allItems => m_AllItems;
}
