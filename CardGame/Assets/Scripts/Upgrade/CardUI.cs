using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    private CardParameters m_CardParameters;
    public CardParameters cardParameters => m_CardParameters;

    private float m_ChanceGetCard;
    public float chanceGetCard => m_ChanceGetCard;

    private bool m_Select;
    public bool select => m_Select;

    private AllUpgrade allUpgrade;

    [SerializeField] private TextMeshProUGUI m_TextMeshCardName;

    [SerializeField] private TextMeshProUGUI m_TextMeshCardInfo;

    [SerializeField] private TextMeshProUGUI m_TextMeshMPCost;

    [SerializeField] private Image cardTexture;

    [SerializeField] private Image cardSelectTexture;

    private void Start()
    {
        allUpgrade = GetComponentInParent<AllUpgrade>();
        SetStartCardSetting(cardParameters);
    }

    public void SetCard(CardParameters cardParameters, float chanceGetCard)
    {
        m_CardParameters = cardParameters;
        m_ChanceGetCard = chanceGetCard;
    }

    public void SetSelect(bool select)
    {
        m_Select = select;
        if (m_Select == true)
        {
            cardSelectTexture.color = new Color32(0, 255, 0, 255);
        }
        else if (m_Select == false)
        {
            cardSelectTexture.color = new Color32(255, 255, 255, 255);
        }
    }

    public void SelectCard()
    {
        allUpgrade.SelectCard(this);
    }

    public void SetStartCardSetting(CardParameters cardParameters)
    {
        m_TextMeshCardName.text = cardParameters.cardName;
        m_TextMeshCardInfo.text = cardParameters.cardInfo;
        m_TextMeshMPCost.text = cardParameters.MPCost.ToString();

        this.cardTexture.color = cardParameters.color;

    }
}
