using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rigid;
    Vector2 velocity;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.up * speed;
    }

    private void Update()
    {
        velocity = rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigid.velocity = Reflact(velocity, collision.contacts[0].normal);
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg, transform.forward);
    }

    private Vector2 Reflact(Vector2 dir, Vector2 normalVector)
    {
        Vector2 reflectDir = Vector2.Reflect(dir, -normalVector);
        return reflectDir;
    }
}
