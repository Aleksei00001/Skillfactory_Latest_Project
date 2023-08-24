using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextPlayerUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextHP;
    [SerializeField] private TextMeshProUGUI m_TextXP;
    [SerializeField] private TextMeshProUGUI m_TextHPRegeneration;
    [SerializeField] private TextMeshProUGUI m_TextMPRegeneration;
    [SerializeField] private TextMeshProUGUI m_TextLevel;
    [SerializeField] private TextMeshProUGUI m_TextMP;

    public void UpdateTextHP(float newHP, float newMaxHP)
    {
        m_TextHP.text = newHP + "/" + newMaxHP;
    }
    public void UpdateTextXP(float newXP, float newMaxXP)
    {
        m_TextXP.text = newXP + "/" + newMaxXP;
    }
    public void UpdateTextLevel(int newLevel)
    {
        m_TextLevel.text = newLevel.ToString();
    }
    public void UpdateTextMP(float newMP, float newMaxMP)
    {
        m_TextMP.text = newMP + "/" + newMaxMP;
    }
    public void UpdateTextHPRegeneration(float newHPRegeneration)
    {
        m_TextHPRegeneration.text = newHPRegeneration.ToString();
    }
    public void UpdateTextMPRegeneration(float newMPRegeneration)
    {
        m_TextMPRegeneration.text = newMPRegeneration.ToString();
    }
}
