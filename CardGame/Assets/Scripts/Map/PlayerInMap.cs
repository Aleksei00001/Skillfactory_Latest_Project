using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMap : MonoBehaviour
{
    [SerializeField] private Node node;

    private Node nextNode;

    [SerializeField] private Camera camera;

    [SerializeField] private LevelManager levelManager;

    [SerializeField] private float spead;

    [SerializeField] private GameStateManager gameStateManager;

    private void Start()
    {
        nextNode = node;
        transform.position = node.transform.position;
    }

    private void Update()
    {
        //transform.position = node.transform.position;
        
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);

        

    }

    private void FixedUpdate()
    {
        if (Vector3.Magnitude(transform.position - nextNode.transform.position) > spead * Time.fixedDeltaTime)
        {
            //if (gameStateManager.startBattle[0].active == true)
            //{
            //    gameStateManager.CloseStartBattle();
            //}
            transform.position = Vector3.MoveTowards(transform.position, nextNode.transform.position, spead);
        }
        else if (node != nextNode)
        {
            transform.position = nextNode.transform.position;
            node = nextNode;
            if (node.nodeStates == PossibleNodeStates.Occupied)
            {
                gameStateManager.OpenStartBattle();
            }
        }
    }

    public void MoveOnNode(Node nextNode)
    {
        if (nextNode.nodeStates != PossibleNodeStates.Unavailable)
        {
            for (int i = 0; i < node.neighboringNodes.Count; i++)
            {
                if (node.neighboringNodes[i] == nextNode)
                {
                    this.nextNode = nextNode;
                    gameStateManager.CloseStartBattle();
                    break;
                }
            }
        }
        
        //if (nextNode.nodeStates == PossibleNodeStates.Occupied)
        //{
        //    StartBattle();
        //}
    }

    public void StartBattle()
    {
        levelManager.StartBattle(node);
    }
}
