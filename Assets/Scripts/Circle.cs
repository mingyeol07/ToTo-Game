// # Systems
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody2D rigid;

    private bool isRigidMove;
    private bool isTransMove;

    private Vector3 spawnPos;

    [SerializeField] protected LayerMask mask;

    private void Awake()
    {
        rigid =GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
    }

    protected virtual void FixedUpdate()
    {
        Vector2 dir = Vector2.right;

        if (isRigidMove)
        {
            rigid.AddForce(dir * speed, ForceMode2D.Force);
        }
        else if (isTransMove)
        {
            transform.position += (Vector3)dir * speed * Time.fixedDeltaTime;
        }
        else
        {
            transform.position = spawnPos;
        }
    }

    public void TransMove()
    {
        isRigidMove = false;
        isTransMove = true;
    }

    public void RigidMove()
    {
        isRigidMove = true;
        isTransMove = false;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
