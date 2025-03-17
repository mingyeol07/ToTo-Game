// # Systems
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class ColliderCircle : Circle
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            CircleSpawner.instance.CollisionCheck();
        }
    }
}
