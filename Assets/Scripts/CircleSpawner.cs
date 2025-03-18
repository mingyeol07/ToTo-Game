using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CircleSpawner : MonoBehaviour
{
    public static CircleSpawner instance;

    [Header("Count")]
    [SerializeField] private Button btn_spawn1;
    [SerializeField] private Button btn_spawn10;
    [SerializeField] private Button btn_spawn100;

    [Header("Buttons")]
    [SerializeField] private StopCircle[] stopCircles;
    [SerializeField] private Button btn_colliderCircle;
    [SerializeField] private Button btn_overlapCircle;
    [SerializeField] private Button btn_aabbCircle;
    [SerializeField] private Button btn_raycastCircle;
    [SerializeField] private Button btn_clear;

    [Header("Speed")]
    [SerializeField] private Button btn_speed1;
    [SerializeField] private Button btn_speed10;
    [SerializeField] private Button btn_speed100;

    [Header("Text")]
    [SerializeField] private TMP_Text txt_spawnCount;
    [SerializeField] private TMP_Text txt_collisionCount;
    private int circleCount;
    private int collisionCount;

    [Header("Circles")]
    [SerializeField] private GameObject circlePrefab;
    //[SerializeField] private GameObject spatialPartitioningCirclePrefab;

    [Space(10)]
    [SerializeField] private CircleTransform circleTransform;

    private GameObject curPrefab;

    [SerializeField] private AABBSystem aabb;
    private bool isAABB;

    private float speed;

    private void Awake()
    {
        instance = this;

        btn_spawn1.onClick.AddListener(() => { Spawn(circlePrefab, 1); });
        btn_spawn10.onClick.AddListener(() => { Spawn(circlePrefab, 10); });
        btn_spawn100.onClick.AddListener(() => { Spawn(circlePrefab, 100); });

        btn_colliderCircle.onClick.AddListener(() =>
        {
            for (int i = 0; i < stopCircles.Length; i++)
            {
                stopCircles[i].SetCollider();
            }
        });
        btn_raycastCircle.onClick.AddListener(() =>
        {
            for (int i = 0; i < stopCircles.Length; i++)
            {
                stopCircles[i].SetRaycast();
            }
        });
        btn_overlapCircle.onClick.AddListener(() =>
        {
            for (int i = 0; i < stopCircles.Length; i++)
            {
                stopCircles[i].SetOverlap();
            }
        });
        btn_aabbCircle.onClick.AddListener(() =>
        {
            isAABB = !isAABB;
        });

        btn_clear.onClick.AddListener(() => 
        { 
            circleTransform.Clear();
            circleCount = 0; 
            collisionCount = 0;
            txt_spawnCount.text = circleCount.ToString();
            txt_collisionCount.text = collisionCount.ToString();
        });

        btn_speed1.onClick.AddListener(() => { speed = 10; });
        btn_speed10.onClick.AddListener(() => { speed  = 100; });
        btn_speed100.onClick.AddListener(() => { speed = 1000; });


    }
    private void Update()
    {
        if (isAABB)
        {
            aabb.CheckAABB();
        }
    }

    private void Spawn(GameObject prefab, int count)
    {
        circleCount += count;
        txt_spawnCount.text = circleCount.ToString();

        for (int i =0; i < count; i ++)
        {
            circleTransform.SpawnCircle(prefab, speed);
        }
    }

    public void CollisionCheck()
    {
        collisionCount += 1;
        txt_collisionCount.text = collisionCount.ToString();
    }
}
