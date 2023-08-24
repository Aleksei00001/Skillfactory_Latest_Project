using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum AtackType
{
    Target,
    Area
}

public class Card : MonoBehaviour
{
    private Hand hand;
    private CardPlaybackArea cardPlaybackArea;
    private Player player;
    [SerializeField] private GameObject m_Visual;
    public GameObject visual => m_Visual;

    [SerializeField] private BoxCollider m_BoxCollider;
    public BoxCollider boxCollider => m_BoxCollider;

    [SerializeField] private AllCards m_Allcards;

    [SerializeField] private CardParameters m_CardParameters;
    public CardParameters cardParameters => m_CardParameters;

    [SerializeField] private bool m_IsSelect;
    public bool isSelect => m_IsSelect;

    //[SerializeField] private Vector3 m_TargetPosition;
    //public Vector3 targetPosition => m_TargetPosition;

    [SerializeField] private SpriteRenderer cardTexture;


    [SerializeField] private float m_MPCost;

    [SerializeField] private bool m_IsAtack;

    [SerializeField] private AtackType m_AtackType;

    [SerializeField] private float m_Damage;

    [SerializeField] private bool[,] m_AreaAtack = new bool[9, 9];


    private bool m_IsPressed;
    public bool isPressed => m_IsPressed;

    private Vector3 m_StartMousePositionOnPressed;
    public Vector3 startMousePositionOnPressed => m_StartMousePositionOnPressed;


    private Cell m_TargetCell;
    public Cell targetCell => m_TargetCell;


    [SerializeField] private Term m_TermsOfUse;
    public Term termsOfUse => m_TermsOfUse;


    [SerializeField] private TextMeshPro m_TextMeshCardName;
    [SerializeField] private TextMeshPro m_TextMeshCardInfo;
    [SerializeField] private TextMeshPro m_TextMeshCardMPCost;


    //[SerializeField] private List<PossibleActions> m_PossibleActions;
    //[SerializeField][Serializable] private class PossibleActions
    //{
    //    [SerializeField] int a = 1;
    //    [SerializeField][Serializable] private enum qwe
    //    {
    //        aq=0,
    //        sfe=1
    //    }
    //    [SerializeField] private qwe asdsad;
    //}
    public void SetCardParameters(CardParameters cardParameters)
    {
        m_CardParameters = cardParameters;
    }

    public void SetTargetCell(Cell targetCell)
    {
        if (m_TargetCell != null)
        {
            if (m_IsAtack == true)
            {
                if (m_AtackType == AtackType.Target)
                {
                    m_TargetCell.SpriteRendererOff();
                }
                else if (m_AtackType == AtackType.Area)
                {
                    for (int i = 4 - m_TargetCell.numberX; i < 9 - m_TargetCell.numberX; i++)
                    {
                        for (int j = 4 - m_TargetCell.numberY; j < 9 - m_TargetCell.numberY; j++)
                        {
                            if (m_AreaAtack[i, j] == true)
                            {
                                int mapID = i - (4 - m_TargetCell.numberX) + (j - (4 - m_TargetCell.numberY)) * 5;
                                cardPlaybackArea.map[mapID].SpriteRendererOff();
                            }
                        }
                    }
                }
            }
        }

        m_TargetCell = targetCell;

        if (m_TargetCell != null)
        {
            if (m_IsAtack == true)
            {
                if (m_AtackType == AtackType.Target)
                {
                    m_TargetCell.SpriteRendererOn();
                }
                else if (m_AtackType == AtackType.Area)
                {
                    for (int i = 4 - m_TargetCell.numberX; i < 9 - m_TargetCell.numberX; i++)
                    {
                        for (int j = 4 - m_TargetCell.numberY; j < 9 - m_TargetCell.numberY; j++)
                        {
                            if (m_AreaAtack[i, j] == true)
                            {
                                int mapID = i - (4 - m_TargetCell.numberX) + (j - (4 - m_TargetCell.numberY)) * 5;
                                cardPlaybackArea.map[mapID].SpriteRendererOn();
                            }
                        }
                    }
                }
            }
        }
    }

    private void Start()
    {
        hand = FindObjectOfType<Hand>().GetComponent<Hand>();
        cardPlaybackArea = FindObjectOfType<CardPlaybackArea>().GetComponent<CardPlaybackArea>();
        player = FindObjectOfType<Player>().GetComponent<Player>();
        //cardTexture.color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255);
        //cardParameters = m_Allcards.allCards[UnityEngine.Random.Range(2, 3)];
        if (m_CardParameters == null)
        {
            m_CardParameters = m_Allcards.allCards[0];
        }
        SetStartCardSetting(m_CardParameters);
    }

    private void Update()
    {
        
    }

    public void SetStartCardSetting(CardParameters cardParameters)
    {
        //for (int i = 0; i < cardParameters.termsOfUse.Length; i++)
        //{
        //    for (int j = 0; j < this.termsOfUse.allTerms.Count; j++)
        //    {
        //        if(this.termsOfUse.allTerms[j].termName == cardParameters.termsOfUse[i])
        //        {
        //            this.termsOfUse.allTerms[j].SetTermCheck(true);
        //        }
        //    }
        //}


        //for (int i = 0; i < cardParameters.termsOfUse.Length; i++)
        //{
        //    this.termsOfUse.AddTerm(cardParameters.termsOfUse[i]);
        //}

        m_TextMeshCardName.text = cardParameters.cardName;
        m_TextMeshCardInfo.text = cardParameters.cardInfo;
        m_MPCost = cardParameters.MPCost;
        m_TextMeshCardMPCost.text = m_MPCost.ToString();
        m_IsAtack = cardParameters.isAtack;
        m_AtackType = cardParameters.atackType;
        m_Damage = cardParameters.damage;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                m_AreaAtack[i, j] = cardParameters.areaAtack[i + 9 * j];
            }
        }


        if (m_IsAtack == true) this.termsOfUse.AddTerm("Atack");
        if (m_AtackType == AtackType.Area) this.termsOfUse.AddTerm("Area");

        this.cardTexture.color = cardParameters.color;

    }

    private void OnMouseOver()
    {
        if (hand.haveIsSelect == false)
        {
            m_IsSelect = true;
            hand.SetHaveIsSelect(true);
        }
    }

    private void OnMouseExit()
    {
        if (m_IsPressed == false)
        {
            if (m_IsSelect == true)
            {
                hand.SetHaveIsSelect(false);
                m_IsSelect = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (m_IsSelect == true)
        {
            m_IsPressed = true;
            m_StartMousePositionOnPressed = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (cardPlaybackArea.cards.Contains(this))
        {
            if (CheckingTermsOfUse(this, m_TargetCell) == true)
            {
                PlayCard();
            }
        }
        m_IsPressed = false;
    }

    public bool CheckingTermsOfUse(Card card, Cell cell)
    {
        //for (int i = 0; i < card.termsOfUse.allTerms.Count; i++)
        //{
        //    for (int j = 0; j < cell.termsOfUse.allTerms.Count; j++)   
        //    {
        //        if ((card.termsOfUse.allTerms[i] == cell.termsOfUse.allTerms[j]))
        //        {
        //            return true;
        //        }
        //    }
        //}
        //return false;

        if (card.termsOfUse.allTerms.Contains("Atack") && cell.termsOfUse.allTerms.Contains("Enemy")) return true;
        if (card.termsOfUse.allTerms.Contains("Area") && cell.termsOfUse.allTerms.Contains("Cell")) return true;
        return false;
    }

    private void PlayCard()
    {
        ActivateCard();
        //if (m_IsAtack == true)
        //{
        //    if (cardPlaybackArea.enemys.Count > 0)
        //    {
        //        if (m_TermsOfUse.allTerms.Contains("Enemy"))
        //        {
        //            ActivateCard();
        //        }
        //        if (m_TermsOfUse.allTerms.Contains("Cell"))
        //        {
        //            ActivateCard();
        //        }
        //    }
        //}
    }


    private void ActivateCard()
    {
        if (player.MP >= m_MPCost)
        {
            player.ChangeMP(-m_MPCost);
            if (m_IsAtack == true)
            {
                if (m_AtackType == AtackType.Target)
                {
                    m_TargetCell.enamy.GetDamage(m_Damage);
                }
                else if (m_AtackType == AtackType.Area)
                {
                    for (int i = 4 - m_TargetCell.numberX; i < 9 - m_TargetCell.numberX; i++)
                    {
                        for (int j = 4 - m_TargetCell.numberY; j < 9 - m_TargetCell.numberY; j++)
                        {
                            if (m_AreaAtack[i, j] == true)
                            {
                                int mapID = i - (4 - m_TargetCell.numberX) + (j - (4 - m_TargetCell.numberY)) * 5;
                                if (cardPlaybackArea.map[mapID].enamy != null)
                                {
                                    cardPlaybackArea.map[mapID].enamy.GetDamage(m_Damage);
                                }
                            }

                            //    int mapID = (i - 4 + m_TargetCell.numberX) + (j - 4 + m_TargetCell.numberY) * 5;
                            //Debug.Log(i + "-" + j + "    " + mapID + "   " + m_AreaAtack[i, j]);
                            //if (m_AreaAtack[i, j] == true)
                            //{

                            //    if (mapID < 25 && mapID >= 0)
                            //    {
                            //        if (cardPlaybackArea.map[mapID].enamy != null)
                            //        {
                            //            cardPlaybackArea.map[mapID].enamy.GetDamage(m_Damage);
                            //        }
                            //    }
                            //}
                        }
                    }
                }
            }

            hand.SetHaveIsSelect(false);
            hand.cards.Remove(this);
            Destroy(this.gameObject);


        }
        //cardPlaybackArea.enemys[UnityEngine.Random.Range(0, cardPlaybackArea.enemys.Count)].GetDamage(1);
    }

    private void OnDestroy()
    {
        if (m_IsSelect == true)
        {
            hand.SetHaveIsSelect(false);
        }

        cardPlaybackArea.AllSpriteRendererOff();
    }

    private void OnDrawGizmos()
    {
        if (targetCell != null)
        {
            Gizmos.DrawLine(this.transform.position, targetCell.transform.position);
        }
    }
}
