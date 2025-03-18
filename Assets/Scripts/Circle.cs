// # Systems
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float speed = 10;

    protected virtual void FixedUpdate()
    {
        Vector2 dir = Vector2.right;

        transform.position += (Vector3)dir * speed * Time.fixedDeltaTime;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
