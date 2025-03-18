using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopCircle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private bool isCollider = true;
    private bool isRayCast;
    private bool isAABB;
    private bool isOverlap;

    private float curColorValue;

    private List<Collider2D> checkedObejcts;
    [SerializeField] private LayerMask mask;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(curColorValue < 1)
        {
            curColorValue += Time.deltaTime;
            float t = curColorValue / 1;
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, t);
        }
    }

    private void FixedUpdate()
    {
        if(isOverlap)
        {
            if (Physics2D.OverlapCircle(transform.position, 1, mask))
            {
                if (checkedObejcts.Contains(Physics2D.OverlapCircle(transform.position, 1, mask))) return;
                checkedObejcts.Add(Physics2D.OverlapCircle(transform.position, 1, mask));


                OnCollistion();
            }

        }
        else if(isRayCast)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, 0.5f, mask))
            {
                OnCollistion();
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollider) return;

        OnCollistion();
    }

    public void OnCollistion()
    {
        if (curColorValue < 1) return;
        spriteRenderer.color = Color.red;
        curColorValue = 0;
        CircleSpawner.instance.CollisionCheck();
    }

    public void SetCollider()
    {
        isCollider = true;
        isOverlap = false;
        isRayCast = false;
        isAABB = false;
    }
    public void SetRaycast()
    {
        isCollider = false;
        isOverlap = false;
        isRayCast = true;
        isAABB = false;
    }
    public void SetOverlap()
    {
        isCollider = false;
        isOverlap = true;
        isRayCast = false;
        isAABB = false;
    }
    public void SetAABB()
    {
        isCollider = false;
        isOverlap = false;
        isRayCast = false;
        isAABB = true;
    }
}
