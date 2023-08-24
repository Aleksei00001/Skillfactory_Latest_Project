using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum PossibleNodeStates
{
    Free,
    Occupied,
    Unavailable
}
[ExecuteInEditMode]
public class Node : MonoBehaviour
{
    [SerializeField] private List<Node> m_NeighboringNodes;
    public List<Node> neighboringNodes => m_NeighboringNodes;

    [SerializeField] private PossibleNodeStates m_NodeState;
    public PossibleNodeStates nodeStates => m_NodeState;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private LevelRule m_LevelRule;
    public LevelRule levelRule => m_LevelRule;

    [SerializeField] private RewardParameters m_RewardParameters;
    public RewardParameters rewardParameters => m_RewardParameters;

    //[SerializeField] private Node addNode = null;

    //[SerializeField] private Node removeNode = null;


    private void Update()
    {
        lineRenderer.positionCount = m_NeighboringNodes.Count * 2;
        for (int i = 0; i < m_NeighboringNodes.Count; i++)
        {
            lineRenderer.SetPosition(i * 2, m_NeighboringNodes[i].transform.position);
            lineRenderer.SetPosition(i * 2 + 1, this.transform.position);

            //bool add = true;
            //for (int j = 0; j < m_NeighboringNodes[i].m_NeighboringNodes.Count; j++)
            //{
            //    if (m_NeighboringNodes[i].m_NeighboringNodes[j] = this)
            //    {
            //        add = false;
            //        break;
            //    }
            //}
            //if (add == true)
            //{
            //    m_NeighboringNodes[i].m_NeighboringNodes.Add(this);
            //}
        }

        UpdateColorNode();


        //if (addNode != null)
        //{
        //    m_NeighboringNodes.Add(addNode);
        //    addNode.m_NeighboringNodes.Add(this);
        //    addNode = null;
        //}
        //if (removeNode != null)
        //{
        //    removeNode.m_NeighboringNodes.Remove(this);
        //    m_NeighboringNodes.Remove(removeNode);
        //    removeNode = null;
        //}

    }

    private void OnMouseUpAsButton()
    {
        GetComponentInParent<Nodes>().playerInMap.MoveOnNode(this);
    }

    public void FreeNode()
    {
        m_NodeState = PossibleNodeStates.Free;
        for (int i = 0; i < m_NeighboringNodes.Count; i++)
        {
            if (m_NeighboringNodes[i].m_NodeState == PossibleNodeStates.Unavailable)
            {
                m_NeighboringNodes[i].m_NodeState = PossibleNodeStates.Occupied;
                m_NeighboringNodes[i].UpdateColorNode();
            }
        }
        UpdateColorNode();
    }

    public void UpdateColorNode()
    {
        if (m_NodeState == PossibleNodeStates.Free)
        {
            spriteRenderer.color = new Color32(0, 255, 0, 255);
        }
        else if (m_NodeState == PossibleNodeStates.Occupied)
        {
            spriteRenderer.color = new Color32(255, 255, 0, 255);
        }
        else if (m_NodeState == PossibleNodeStates.Unavailable)
        {
            spriteRenderer.color = new Color32(255, 00, 0, 255);
        }
    }


}
