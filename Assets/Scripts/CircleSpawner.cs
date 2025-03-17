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
    [SerializeField] private Button btn_spawn100;
    [SerializeField] private Button btn_spawn1000;
    [SerializeField] private Button btn_spawn10000;

    [Header("Buttons")]
    [SerializeField] private Button btn_colliderCircle;
    [SerializeField] private Button btn_overlapCircle;
    [SerializeField] private Button btn_aabbCircle;
    [SerializeField] private Button btn_raycastCircle;
    //[SerializeField] private Button btn_spatialPartitionCircle;
    [SerializeField] private Button btn_clear;
    [SerializeField] private Button btn_rigidStart;
    [SerializeField] private Button btn_transStart;

    [Header("Speed")]
    [SerializeField] private Button btn_speed10;
    [SerializeField] private Button btn_speed100;
    [SerializeField] private Button btn_speed1000;

    [Header("Text")]
    [SerializeField] private TMP_Text txt_spawnCount;
    [SerializeField] private TMP_Text txt_collisionCount;
    private int circleCount;
    private int collisionCount;

    [Header("Circles")]
    [SerializeField] private GameObject colliderCirclePrefab;
    [SerializeField] private GameObject overlapCirclePrefab;
    [SerializeField] private GameObject aabbCirclePrefab;
    [SerializeField] private GameObject raycastCirclePrefab;
    //[SerializeField] private GameObject spatialPartitioningCirclePrefab;

    [Space(10)]
    [SerializeField] private CircleTransform circleTransform1;

    private GameObject curPrefab;

    [SerializeField] private AABBSystem aabb;

    private void Awake()
    {
        instance = this;

        btn_spawn100.onClick.AddListener(() => { Spawn(curPrefab, 10); });
        btn_spawn1000.onClick.AddListener(() => { Spawn(curPrefab, 100); });
        btn_spawn10000.onClick.AddListener(() => { Spawn(curPrefab, 1000); });

        btn_colliderCircle.onClick.AddListener(() => { curPrefab = colliderCirclePrefab; });
        btn_raycastCircle.onClick.AddListener(() => { curPrefab = raycastCirclePrefab; });
        btn_overlapCircle.onClick.AddListener(() => { curPrefab = overlapCirclePrefab; });
        btn_aabbCircle.onClick.AddListener(() => { curPrefab = aabbCirclePrefab; });

        btn_clear.onClick.AddListener(() => { circleTransform1.Clear(); circleCount = 0; collisionCount = 0; });

        btn_rigidStart.onClick.AddListener(() => { circleTransform1.RigidMove();  });
        btn_transStart.onClick.AddListener(() => { circleTransform1.TransMove();  });

        btn_speed10.onClick.AddListener(() => { circleTransform1.SetSpeedCircles(10); });
        btn_speed100.onClick.AddListener(() => { circleTransform1.SetSpeedCircles(100); });
        btn_speed1000.onClick.AddListener(() => { circleTransform1.SetSpeedCircles(1000); });


    }

    private void Spawn(GameObject prefab, int count)
    {
        circleCount += count;
        txt_spawnCount.text = circleCount.ToString();

        for (int i =0; i < count; i ++)
        {
            circleTransform1.SpawnCircle(prefab);
        }

        aabb.SetCircle(prefab);
    }

    public void CollisionCheck()
    {
        collisionCount += 1;
        txt_collisionCount.text = collisionCount.ToString();
    }
}
