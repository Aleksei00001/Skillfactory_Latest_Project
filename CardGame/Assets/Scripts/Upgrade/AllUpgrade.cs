using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllUpgrade : MonoBehaviour
{
    [SerializeField] private List<CardUI> m_CardUI;

    [SerializeField] private Player player;

    [SerializeField] private CardUI cardUIPrefab;

    [SerializeField] private GameObject cardContent;

    [SerializeField] private TextMeshProUGUI textCardsFromUpgrades;

    [SerializeField] private TextMeshProUGUI textUpgrades;

    [SerializeField] private Camera camera;

    public void AddCardUI(CardParameters cardParameters, float chanceGetCard)
    {
        CardUI newCardUI = Instantiate<CardUI>(cardUIPrefab);
        newCardUI.transform.SetParent(cardContent.transform);
        newCardUI.transform.localScale = new Vector3(1, 1, 1);
        m_CardUI.Add(newCardUI);
        m_CardUI[m_CardUI.Count - 1].SetCard(cardParameters, chanceGetCard);
    }

    public void SelectCard(CardUI cardUI)
    {
        
        if (cardUI.select == false)
        {
            if (player.maxCardsFromUpgrades > player.cardsFromUpgrades)
            {
                cardUI.SetSelect(true);
                player.AddCard(cardUI.cardParameters, cardUI.chanceGetCard);
                player.ChangeCardsFromUpgrades(1);
            }
        }
        else if (cardUI.select == true)
        {
            cardUI.SetSelect(false);
            player.RemoveCard(cardUI.cardParameters);
            player.ChangeCardsFromUpgrades(-1);
        }
    }

    private void Update()
    {
        for (int i = 0; i < m_CardUI.Count; i++)
        {
            m_CardUI[i].transform.position = new Vector3(2.5f + (i % 3) * 5 + cardContent.transform.position.x, - 5 - (i / 3) * 6 + cardContent.transform.position.y, 0);
        }
        cardContent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 720 * (((m_CardUI.Count - 1) / 3) + 1));
        textCardsFromUpgrades.text = player.cardsFromUpgrades + " / " + player.maxCardsFromUpgrades;
        textUpgrades.text = (player.maxUpgrades - player.upgrades).ToString();
        camera.transform.position = new Vector3(-99999, -99999, camera.transform.position.z);
    }


    //public void RemoveCardParameters(CardParameters cardParameters)
    //{
    //    m_CardUI.Remove( cardParameters);
    //}


}
