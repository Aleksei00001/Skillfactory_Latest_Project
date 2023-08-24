using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoundStatus
{
    Units,
    Enamy,
    Player
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Reward reward;

    [SerializeField] private CardPlaybackArea cardPlaybackArea;

    [SerializeField] private NextRoundButton nextRoundButton;

    [SerializeField] private LevelRule levelRule;

    [SerializeField] private Hand hand;

    [SerializeField] private GameStateManager gameStateManager;

    [SerializeField] private Enemy prefabEnamy;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private int round;

    private int wave;

    private RoundStatus m_RoundStatus = RoundStatus.Player;
    public RoundStatus roundStatus => m_RoundStatus;

    private Node node;

    private bool endPosible = false;

    private bool win = false;

    private void Update()
    {
        CheckingLevelCompletion();
    }

    public void StartBattle(Node node)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = levelRule.backGround;
        this.node = node;
        levelRule = node.levelRule;
        round = 0;
        wave = 0;
        m_RoundStatus = RoundStatus.Player;
        gameStateManager.OpenBattle();
        hand.ClearHand();
    }

    public void NextRound()
    {
        if (m_RoundStatus == RoundStatus.Player)
        {
            PlayerMove();
        }
        else if (m_RoundStatus == RoundStatus.Enamy)
        {
            EnamyMove();
        }
        else if (m_RoundStatus == RoundStatus.Units)
        {
            UnitsMove();
        }
    }

    public void UnitsMove()
    {
        for (int i = 0; i < cardPlaybackArea.enemys.Count; i++)
        {
            cardPlaybackArea.enemys[i].Action();
        }
        m_RoundStatus = RoundStatus.Player;
    }

    public void PlayerMove()
    {
        m_RoundStatus = RoundStatus.Enamy;
        hand.AddCard();
        player.Regeneration();
        NextRound();
    }

    public void EnamyMove()
    {
        endPosible = true;
        if ((round % 3) == 0 && wave < levelRule.waveCount)
        {
            endPosible = false;
            //for (int i = 0; i < levelRule.waveSize[wave]; i++)
            //{

            int tempWavePosition = 0;
            if (wave != 0)
            {
                for (int e = 0; e < wave; e++)
                {
                    tempWavePosition += levelRule.countTypeEnemy[e];
                }
            }
            for (int w = 0; w < levelRule.countTypeEnemy[wave]; w++)
            {
                for (int q = 0; q < levelRule.waveSize[tempWavePosition + w]; q++)
                {
                    List<Cell> freeCell = new List<Cell>();
                    for (int j = 0; j < cardPlaybackArea.map.Count; j++)
                    {
                        if (cardPlaybackArea.map[j].enamy == null)
                        {
                            freeCell.Add(cardPlaybackArea.map[j]);
                        }
                    }
                    if (freeCell.Count > 0)
                    {
                        Enemy newEnamy = Instantiate<Enemy>(prefabEnamy);
                        newEnamy.SetEnEnemyParameters(levelRule.waveContent[tempWavePosition + w]);
                        freeCell[Random.Range(0, freeCell.Count)].AddEnemy(newEnamy);
                    }
                }
            }
            //}
            wave++;
        }
        round++;
        m_RoundStatus = RoundStatus.Units;
        NextRound();
    }

    public void CheckingLevelCompletion()
    {
        if (wave == levelRule.waveCount && cardPlaybackArea.enemys.Count == 0 && gameStateManager.gameState == GameState.Battle && endPosible == true)
        {
            win = true;
            gameStateManager.OpenEndBattle();
        }
        else if (player.HP <= 0 && gameStateManager.gameState == GameState.Battle)
        {
            win = false;
            gameStateManager.OpenEndBattle();
        }
    }

    public void EndBattle()
    {
        spriteRenderer.enabled = false;
        player.FullRegeneration();
        cardPlaybackArea.ClearEnemys();
        if (win == true)
        {
            gameStateManager.OpenMap();
            gameStateManager.OpenInventory();
            gameStateManager.OpenReward();
            gameStateManager.CloseEndBattle();
            reward.SetReward(node.rewardParameters);
            node.FreeNode();
        }
        else
        {
            gameStateManager.OpenMap();
            gameStateManager.CloseEndBattle();
            gameStateManager.OpenStartBattle();
        }
    }
}
