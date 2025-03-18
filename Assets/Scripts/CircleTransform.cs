using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircleTransform : MonoBehaviour
{
    public List<GameObject> circles = new List<GameObject>();

    public void SpawnCircle(GameObject circle, float speed)
    {
        var go = Instantiate(circle, transform);
        go.GetComponent<Circle>().SetSpeed(speed);
        circles.Add(go);
    }

    public void SetSpeedCircles(float speed)
    {
        for(int i =0; i < circles.Count; i++)
        {
            circles[i].GetComponent<Circle>().SetSpeed(speed);
        }
    }

    public void Clear()
    {
        for (int i = 0; i < circles.Count; i++)
        {
            Destroy(circles[i]);
        }
        circles.Clear();
    }
}
