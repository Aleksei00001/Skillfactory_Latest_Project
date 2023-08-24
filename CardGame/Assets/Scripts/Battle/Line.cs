using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    //[SerializeField] Vector3 v1;
    //[SerializeField] Vector3 v2;

    [SerializeField] private GameObject arrow;

    [SerializeField] private LineRenderer lineRenderer;

    public void Rotate(Vector3 startPoint, Vector3 targetPoint)
    {
        if (transform.position.y > startPoint.y)
        {
            arrow.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(new Vector2(startPoint.x, startPoint.y) - new Vector2(targetPoint.x, targetPoint.y), new Vector2(-1, 0)));
        }
        else
        {
            arrow.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(new Vector2(startPoint.x, startPoint.y) - new Vector2(targetPoint.x, targetPoint.y), new Vector2(1, 0)));
        }
    }
        
    public void DraweLine(Vector3 startPoint, Vector3 targetPoint)
    {
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, targetPoint);
    }

    //private void Update()
    //{
    //    //Rotate(point1, point2);
    //    Debug.Log(Vector2.Angle(v1, v2));
    //}
}
