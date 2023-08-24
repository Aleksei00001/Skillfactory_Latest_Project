using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleUI : MonoBehaviour
{
    [SerializeField] private Camera camera;
    void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
    }
}
