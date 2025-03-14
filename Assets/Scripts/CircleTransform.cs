using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircleTransform : MonoBehaviour
{
    [SerializeField] private TMP_Text circleCount;
    private List<GameObject> circles = new List<GameObject>();

    public void SpawnCircle(GameObject circle)
    {
        circles.Add(Instantiate(circle, transform));
    }
}
