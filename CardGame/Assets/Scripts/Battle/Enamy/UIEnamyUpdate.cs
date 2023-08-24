using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnamyUpdate : MonoBehaviour
{
    [SerializeField] private Image m_ImageHP;

    public void UpdateImageHP(float newHP, float newMaxHP)
    {
        m_ImageHP.fillAmount = newHP / newMaxHP;
    }
}
