using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    public int Hp { get { return hp; } set { if (value <= 0) Destroy(this.gameObject); else hp = value; } }
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
        if (collision.gameObject.CompareTag("Wall"))
        {
            rigid.velocity = Vector2.Reflect(velocity, collision.contacts[0].normal);
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg, transform.forward);
        }
        else if (collision.gameObject.CompareTag("Corner"))
        {
            rigid.velocity = Vector2.Reflect(velocity, collision.contacts[0].normal);
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg - 90, transform.forward);
        }
    }
}
