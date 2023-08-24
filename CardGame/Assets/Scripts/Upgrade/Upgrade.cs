using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum UpgradeState
{
    active,
    unActive,
    close
}
[ExecuteInEditMode]
public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradeParameters m_UpgradeParameters;
    public UpgradeParameters upgradeParameters => m_UpgradeParameters;

    [SerializeField] private UpgradeState upgradeState;

    [SerializeField] private List<Upgrade> nextUpgrades;

    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private Image image;

    private Player player;

    private AllUpgrade allUpgrade;

    //[SerializeField] private Upgrade addUpgrade = null;

    //[SerializeField] private Upgrade removeUpgrade = null;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        allUpgrade = FindObjectOfType<AllUpgrade>();
    }

    private void Update()
    {

        lineRenderer.positionCount = nextUpgrades.Count * 2;
        for (int i = 0; i < nextUpgrades.Count; i++)
        {
            lineRenderer.SetPosition(i * 2, nextUpgrades[i].transform.position);
            lineRenderer.SetPosition(i * 2 + 1, this.transform.position);

            //bool add = true;
            //for (int j = 0; j < nextUpgrades[i].nextUpgrades.Count; j++)
            //{
            //    if (nextUpgrades[i].nextUpgrades[j] = this)
            //    {
            //        add = false;
            //        break;
            //    }
            //}
            //if (add == true)
            //{
            //    nextUpgrades[i].nextUpgrades.Add(this);
            //}
        }

        //if (addUpgrade != null)
        //{
        //    nextUpgrades.Add(addUpgrade);
        //    addUpgrade.nextUpgrades.Add(this);
        //    addUpgrade = null;
        //}
        //if (removeUpgrade != null)
        //{
        //    removeUpgrade.nextUpgrades.Remove(this);
        //    nextUpgrades.Remove(removeUpgrade);
        //    removeUpgrade = null;
        //}

        UpdateColor();
    }   

    public void SetActive()
    {
        if (upgradeState == UpgradeState.unActive && player.maxUpgrades > player.upgrades)
        {
            player.ChangeMaxHP(m_UpgradeParameters.HPBonus);
            for (int i = 0; i < m_UpgradeParameters.cardParameters.Count; i++)
            {
                allUpgrade.AddCardUI(m_UpgradeParameters.cardParameters[i], m_UpgradeParameters.chanceGetCard[i]);
            }
            upgradeState = UpgradeState.active;
            for (int i = 0; i < nextUpgrades.Count; i++)
            {
                nextUpgrades[i].OpenUnActive();
            }
            player.ChangeUpgrades(1);
        }
    }

    public void OpenUnActive()
    {
        if (upgradeState == UpgradeState.close)
        {
            upgradeState = UpgradeState.unActive;
        }
    }

    public void UpdateColor()
    {
        if (upgradeState == UpgradeState.active)
        {
            image.color = new Color32(0, 255, 0, 255);
        }
        else if (upgradeState == UpgradeState.unActive)
        {
            image.color = new Color32(255, 255, 0, 255);
        }
        else if (upgradeState == UpgradeState.close)
        {
            image.color = new Color32(255, 0, 0, 255);
        }
    }
}
