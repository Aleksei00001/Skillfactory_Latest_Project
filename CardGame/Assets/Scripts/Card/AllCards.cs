using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCards : MonoBehaviour
{
    [SerializeField] private CardParameters[] m_AllCards;
    public CardParameters[] allCards => m_AllCards;
}
