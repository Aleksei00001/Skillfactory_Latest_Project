using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Information : MonoBehaviour
{
    [SerializeField] private GameObject enemyInformation;

    [SerializeField] private TextMeshProUGUI enemyHP;

    [SerializeField] private TextMeshProUGUI enemyDamage;

    [SerializeField] private TextMeshProUGUI enemyName;

    private Enemy enemy;

    public void OpenInformationEnemy(Enemy getEnamy)
    {
        enemyInformation.SetActive(true);
        enemyHP.text = getEnamy.HP + " / " + getEnamy.MaxHP;
        enemyDamage.text = getEnamy.damage.ToString();
        enemyName.text = getEnamy.enemyName;
    }

    public void CloseInformationEnemy()
    {
        enemyInformation.SetActive(false);
    }


    [SerializeField] private GameObject itemInformation;

    [SerializeField] private TextMeshProUGUI itemHP;

    [SerializeField] private TextMeshProUGUI itemName;

    [SerializeField] private TextMeshProUGUI itemCards;

    private Item item;

    public void OpenInformationItem(Item getItem)
    {
        itemInformation.SetActive(true);
        itemHP.text = getItem.bonusHP.ToString();
        itemName.text = getItem.itemName;
        itemCards.text = "";
        for (int i = 0; i < getItem.cardParameters.Length; i++)
        {
            itemCards.text += getItem.cardParameters[i].cardName + "\n";
        }
    }

    public void CloseInformationItem()
    {
        itemInformation.SetActive(false);
    }



    [SerializeField] private GameObject upgradeInformation;

    [SerializeField] private TextMeshProUGUI upgradeHP;

    [SerializeField] private TextMeshProUGUI upgradeName;

    [SerializeField] private TextMeshProUGUI upgradeCards;

    private Upgrade upgrade;

    public void OpenInformationUpgrade(Upgrade getUpgrade)
    {
        itemInformation.SetActive(true);
        itemHP.text = getUpgrade.upgradeParameters.HPBonus.ToString();
        itemName.text = getUpgrade.upgradeParameters.upgradeName;
        itemCards.text = "";
        for (int i = 0; i < getUpgrade.upgradeParameters.cardParameters.Count; i++)
        {
            itemCards.text += getUpgrade.upgradeParameters.cardParameters[i].cardName + "\n";
        }
    }

    public void CloseInformationUpgrade()
    {
        itemInformation.SetActive(false);
    }
}
