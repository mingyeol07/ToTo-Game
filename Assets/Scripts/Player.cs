using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private GameObject bullet;
    private float bulletAngle;
    private Vector2 bulletDir;
    private Vector2 mousePos;

    [Header("Aim")]
    [SerializeField] private GameObject ray;
    [SerializeField] private Transform shotPosition;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    private Vector2 moveDir;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Aim();
        Shot();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(h , v).normalized * moveSpeed;

        rigid.velocity = moveDir;
    }

    private void Aim()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bulletDir = mousePos - (Vector2)transform.position;

        bulletAngle = Mathf.Atan2(bulletDir.x, bulletDir.y) * Mathf.Rad2Deg;
        ray.transform.rotation = Quaternion.AngleAxis(-bulletAngle, Vector3.forward);
    }

    private void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, shotPosition.position, ray.transform.rotation);
        }
    }
}
