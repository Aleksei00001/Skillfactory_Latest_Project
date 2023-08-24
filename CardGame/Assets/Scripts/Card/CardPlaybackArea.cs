using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlaybackArea : MonoBehaviour
{
    [SerializeField] private List<Card> m_Cards;
    public List<Card> cards => m_Cards;


    [SerializeField] private List<Enemy> m_Enemys;
    public List<Enemy> enemys => m_Enemys;


    [SerializeField] private Cell prefabCell;

    [SerializeField] private List<Cell> m_Map;
    public List<Cell> map => m_Map;

    [SerializeField] private Vector3 startPosition;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.gameObject.GetComponent<Card>() != null)
        {
            m_Cards.Add(other.gameObject.GetComponent<Card>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Card>() != null)
        {
            other.gameObject.GetComponent<Card>().SetTargetCell(null);
            m_Cards.Remove(other.gameObject.GetComponent<Card>());
        }
        //if (other.gameObject.GetComponent<Card>() != null)
        //{
            
        //}
    }

    public void AllSpriteRendererOff()
    {
        for (int i = 0; i < 25; i++)
        {
            m_Map[i].SpriteRendererOff();
        }
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Cell newCell = Instantiate(prefabCell);
                newCell.transform.SetParent(this.transform);
                m_Map.Add(newCell);
                m_Map[i * 5 + j].SetPosition(j * prefabCell.transform.localScale.x + startPosition.x, i * prefabCell.transform.localScale.y + startPosition.y);
                m_Map[i * 5 + j].SetNumber(j, i);
            }
        }
    }

    private void Update()
    {   
        if (m_Cards.Count > 0)
        {
            for (int i = 0; i < m_Cards.Count; i++)
            {
                if (m_Cards[i] == null)
                {
                    m_Cards.Remove(m_Cards[i]);
                }
            }
            for (int i = 0; i < m_Cards.Count; i++)
            {
                float minDistance = Vector2.Distance(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), m_Map[0].transform.position);
                Cell minDistanceCell = m_Map[0];
                for (int j = 0; j < m_Map.Count; j++)
                {
                    if (Vector2.Distance(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), m_Map[j].transform.position) < minDistance)
                    {
                        minDistance = Vector2.Distance(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), m_Map[j].transform.position);
                        minDistanceCell = m_Map[j];
                    }
                }
                m_Cards[i].SetTargetCell(minDistanceCell);
            }
        }
    }

    public void ClearEnemys()
    {
        for (int i = 0; i < m_Enemys.Count; i++)
        {
            Destroy(m_Enemys[i].gameObject);
        }
        m_Enemys.Clear();
    }
}
