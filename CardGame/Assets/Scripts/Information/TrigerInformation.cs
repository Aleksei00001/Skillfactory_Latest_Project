using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum InformationTip
{
    Enemy,
    Item,
    Upgrade
}

public class TrigerInformation : MonoBehaviour
{
    [SerializeField] private InformationTip informationTip;

    [SerializeField] Enemy enemy;

    [SerializeField] Item item;

    [SerializeField] Upgrade upgrade;

    private Information information;

    private bool startInformationTimer;
    private float informationTimer;

    private void Start()
    {
        startInformationTimer = false;
        informationTimer = 0;
        information = FindObjectOfType<Information>().GetComponent<Information>();
    }

    private void OnMouseEnter()
    {
        startInformationTimer = true;
    }

    private void OnMouseExit()
    {
        startInformationTimer = false;
        informationTimer = 0;
        CloseInformation();
    }

    public void OpenInformation()
    {
        if (informationTip == InformationTip.Enemy)
        {
            information.OpenInformationEnemy(enemy);
        }
        else if (informationTip == InformationTip.Item)
        {
            information.OpenInformationItem(item);
        }
        else if (informationTip == InformationTip.Upgrade)
        {
            information.OpenInformationUpgrade(upgrade);
        }
    }

    public void CloseInformation()
    {
        if (informationTip == InformationTip.Enemy)
        {
            information.CloseInformationEnemy();
        }
        else if (informationTip == InformationTip.Item)
        {
            information.CloseInformationItem();
        }
        else if (informationTip == InformationTip.Upgrade)
        {
            information.CloseInformationUpgrade();
        }
    }
    private void Update()
    {
        if (startInformationTimer == true)
        {
            informationTimer += Time.deltaTime;
        }
        if (informationTimer >= 0.5f)
        {
            OpenInformation();
        }
    }
}
