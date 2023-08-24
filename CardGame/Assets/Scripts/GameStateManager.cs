using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Map,
    Battle
}

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_MenuObject;

    [SerializeField] private GameObject[] m_MapObject;

    [SerializeField] private GameObject[] m_BattleObject;

    [SerializeField] private GameObject[] m_Inventory;

    private bool inventoryStatus;

    [SerializeField] private GameObject[] m_StartBattle;
    //public GameObject[] startBattle => m_StartBattle;

    [SerializeField] private GameObject[] m_Reward;

    [SerializeField] private GameObject[] m_EndBattle;

    [SerializeField] private GameObject[] m_Upgrade;

    private bool m_UpgradeStatus;
    public bool upgradeStatus => m_UpgradeStatus;

    [SerializeField] private Camera camera;

    [SerializeField] private GameState m_GameState = GameState.MainMenu;
    public GameState gameState => m_GameState;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        { 
            OpenMainMenu();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            OpenMap();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenBattle();
        }
        if ((m_GameState == GameState.Map || m_GameState == GameState.Battle) && Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryStatus == true)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
        if ((m_GameState == GameState.Map || m_GameState == GameState.Battle) && Input.GetKeyDown(KeyCode.U))
        {
            if (m_UpgradeStatus == true)
            {
                CloseUpgrade();
            }
            else
            {
                OpenUpgrade();
            }
        }
    }

    public void OpenMainMenu()
    {
        ClossAll();
        for (int i = 0; i < m_MenuObject.Length; i++)
        {
            m_MenuObject[i].SetActive(true);
        }
        camera.transform.position = new Vector3(0, 0, camera.transform.position.z);
        m_GameState = GameState.MainMenu;
    }
    public void CloseMainMenu()
    {
        for (int i = 0; i < m_MenuObject.Length; i++)
        {
            m_MenuObject[i].SetActive(false);
        }
    }

    public void OpenMap()
    {
        ClossAll();
        for (int i = 0; i < m_MapObject.Length; i++)
        {
            m_MapObject[i].SetActive(true);
        }
        m_GameState = GameState.Map;
    }
    public void CloseMap()
    {
        for (int i = 0; i < m_MapObject.Length; i++)
        {
            m_MapObject[i].SetActive(false);
        }
    }

    public void OpenBattle()
    {
        ClossAll();
        for (int i = 0; i < m_BattleObject.Length; i++)
        {
            m_BattleObject[i].SetActive(true);
        }
        camera.transform.position = new Vector3(0, 0, camera.transform.position.z);
        m_GameState = GameState.Battle;
    }
    public void CloseBattle()
    {
        for (int i = 0; i < m_BattleObject.Length; i++)
        {
            m_BattleObject[i].SetActive(false);
        }
    }

    public void OpenInventory()
    {
        for (int i = 0; i < m_Inventory.Length; i++)
        {
            m_Inventory[i].SetActive(true);
        }
        inventoryStatus = true;
    }
    public void CloseInventory()
    {
        for (int i = 0; i < m_Inventory.Length; i++)
        {
            m_Inventory[i].SetActive(false);
        }
        inventoryStatus = false;
    }

    public void OpenStartBattle()
    {
        for (int i = 0; i < m_StartBattle.Length; i++)
        {
            m_StartBattle[i].SetActive(true);
        }
    }
    public void CloseStartBattle()
    {
        for (int i = 0; i < m_StartBattle.Length; i++)
        {
            m_StartBattle[i].SetActive(false);
        }
    }

    public void OpenReward()
    {
        for (int i = 0; i < m_Reward.Length; i++)
        {
            m_Reward[i].SetActive(true);
        }
    }
    public void CloseReward()
    {
        for (int i = 0; i < m_Reward.Length; i++)
        {
            m_Reward[i].SetActive(false);
        }
    }

    public void OpenEndBattle()
    {
        for (int i = 0; i < m_EndBattle.Length; i++)
        {
            m_EndBattle[i].SetActive(true);
        }
    }
    public void CloseEndBattle()
    {
        for (int i = 0; i < m_EndBattle.Length; i++)
        {
            m_EndBattle[i].SetActive(false);
        }
    }

    public void OpenUpgrade()
    {
        for (int i = 0; i < m_Upgrade.Length; i++)
        {
            m_Upgrade[i].SetActive(true);
        }
        m_UpgradeStatus = true;
    }
    public void CloseUpgrade()
    {
        for (int i = 0; i < m_Upgrade.Length; i++)
        {
            m_Upgrade[i].SetActive(false);
        }
        m_UpgradeStatus = false;
    }

    public void ClossAll()
    {
        CloseMainMenu();
        CloseMap();
        CloseBattle();
        CloseInventory();
        CloseStartBattle();
        CloseReward();
        CloseEndBattle();
        CloseUpgrade();
    }
}
