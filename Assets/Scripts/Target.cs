using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.targets.Add(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance.targets.Remove(this.gameObject);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
