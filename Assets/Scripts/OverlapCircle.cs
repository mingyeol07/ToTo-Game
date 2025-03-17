// # Systems
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;


// # Unity
using UnityEngine;

public class OverlapCircle : Circle
{
    private List<Collider2D> checkedObejcts;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (Physics2D.OverlapCircle(transform.position, 1, mask))
        {
            if (checkedObejcts.Contains(Physics2D.OverlapCircle(transform.position, 1, mask))) return;
            checkedObejcts.Add(Physics2D.OverlapCircle(transform.position, 1, mask));
            CircleSpawner.instance.CollisionCheck();
        }
    }
}
