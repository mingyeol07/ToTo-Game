// # Systems
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class RaycastCircle : Circle 
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(Physics2D.Raycast(transform.position, Vector2.right, 1, mask))
        {
            CircleSpawner.instance.CollisionCheck();
        }
    }
}
