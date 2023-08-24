using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundButton : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private void OnMouseUpAsButton()
    {
        if (levelManager.roundStatus == RoundStatus.Player)
        {
            levelManager.NextRound();
        }
    }
}
