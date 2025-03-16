using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircleTransform : MonoBehaviour
{
    private List<GameObject> circles = new List<GameObject>();

    public void SpawnCircle(GameObject circle)
    {
        circles.Add(Instantiate(circle, transform));
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

    public void TransMove()
    {
        for (int i = 0; i < circles.Count; i++)
        {
            circles[i].GetComponent<Circle>().TransMove();
        }
    }

    public void RigidMove()
    {
        for (int i = 0; i < circles.Count; i++)
        {
            circles[i].GetComponent<Circle>().RigidMove();
        }
    }
}
