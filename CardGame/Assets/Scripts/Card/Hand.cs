using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private List<Card> m_Cards;
    public List<Card> cards => m_Cards;

    [SerializeField] private Card prefabCard;

    [SerializeField] private Vector2 startPointPosition;
    [SerializeField] private float widthHand;

    [SerializeField] private Line line;

    Vector3 point1;
    Vector3 point2;


    private bool m_HaveIsSelect;
    public bool haveIsSelect => m_HaveIsSelect;

    private Player player;
    [SerializeField] private AllCards allCards;

    public void ClearHand()
    {
        for (int i = m_Cards.Count - 1; i >= 0; i--)
        {
            Destroy(m_Cards[i].gameObject);
        }
        m_Cards.Clear();
    }

    public void SetHaveIsSelect(bool isSelect)
    {
        m_HaveIsSelect = isSelect;
        if (isSelect == false)
        {
            line.gameObject.active = false;
        }
    }

    public void AddCard()
    {
        int countAddCard = 0;
        if (player.cardParameters.Count != 0)
        {
            for (int i = 0; i < player.cardParameters.Count; i++)
            {
                if (player.chanceGetCard[i] >= Random.Range(0f, 1f))
                {
                    countAddCard++;
                    Card newCard = Instantiate<Card>(prefabCard);
                    newCard.transform.SetParent(this.transform);
                    newCard.SetCardParameters(player.cardParameters[i]);
                    m_Cards.Add(newCard);
                }
            }
        }
        if (countAddCard == 0)
        {
            Card newCard = Instantiate<Card>(prefabCard);
            newCard.transform.SetParent(this.transform);
            newCard.SetCardParameters(allCards.allCards[0]);
            m_Cards.Add(newCard);
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private void Update()
    {
        for (int i = 0; i < m_Cards.Count; i++)
        {
            m_Cards[i].boxCollider.size = new Vector3(1, 1, 1);
            if (m_Cards[i].isSelect == true)
            {
                if (m_Cards[i].isPressed == true)
                {
                    m_Cards[i].boxCollider.size = new Vector3(0.01f, 0.01f, 0.01f);

                    m_Cards[i].transform.position = new Vector3(startPointPosition.x + (float)(i - (float)(m_Cards.Count - 1) / 2) * (widthHand / m_Cards.Count) + Camera.main.ScreenToWorldPoint(Input.mousePosition).x - m_Cards[i].startMousePositionOnPressed.x,
                        startPointPosition.y + Camera.main.ScreenToWorldPoint(Input.mousePosition).y - m_Cards[i].startMousePositionOnPressed.y, -1 - (float)i / 1000);
                    m_Cards[i].transform.localScale = new Vector3(3, 4.5f, 1);
                    m_Cards[i].visual.transform.position = new Vector3(startPointPosition.x + (float)(i - (float)(m_Cards.Count - 1) / 2) * (widthHand / m_Cards.Count), startPointPosition.y, -2 - (float)i / 1000);

                    line.gameObject.active = true;
                    if (m_Cards[i].targetCell != null)
                    {
                        line.Rotate(m_Cards[i].visual.transform.position, m_Cards[i].targetCell.transform.position);
                        line.DraweLine(m_Cards[i].visual.transform.position, m_Cards[i].targetCell.transform.position);
                        line.transform.position = new Vector3(m_Cards[i].targetCell.transform.position.x, m_Cards[i].targetCell.transform.position.y, -2);

                        point1 = m_Cards[i].visual.transform.position;
                        point2 = m_Cards[i].targetCell.transform.position;
                    }
                    else
                    {
                        line.Rotate(m_Cards[i].visual.transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0));
                        line.DraweLine(m_Cards[i].visual.transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0));
                        line.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -2);

                        point1 = m_Cards[i].visual.transform.position;
                        point2 = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                    }
                    
                }
                else
                {
                    m_Cards[i].transform.position = new Vector3(startPointPosition.x + (float)(i - (float)(m_Cards.Count - 1) / 2) * (widthHand / m_Cards.Count), startPointPosition.y, -1 - (float)i / 1000);
                    m_Cards[i].transform.localScale = new Vector3(3, 4.5f, 1);
                    m_Cards[i].visual.transform.position = new Vector3(startPointPosition.x + (float)(i - (float)(m_Cards.Count - 1) / 2) * (widthHand / m_Cards.Count), startPointPosition.y, -2 - (float)i / 1000);

                    line.gameObject.active = false;
                }


            }
            else
            {
                m_Cards[i].transform.position = new Vector3(startPointPosition.x + (float)(i - (float)(m_Cards.Count - 1) / 2) * (widthHand / m_Cards.Count), startPointPosition.y, 0 - (float)i / 1000);
                m_Cards[i].transform.localScale = new Vector3(2, 3f, 1);
                m_Cards[i].visual.transform.position = new Vector3(startPointPosition.x + (float)(i - (float)(m_Cards.Count - 1) / 2) * (widthHand / m_Cards.Count), startPointPosition.y, -1 - (float)i / 1000);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(point1, point2);
    }
}
