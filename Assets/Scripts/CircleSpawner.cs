using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CircleSpawner : MonoBehaviour
{
    [Header("Count")]
    [SerializeField] private Button btn_spawn100;
    [SerializeField] private Button btn_spawn1000;
    [SerializeField] private Button btn_spawn10000;

    [Header("Buttons")]
    [SerializeField] private Button btn_colliderCircle;
    [SerializeField] private Button btn_overlapCircle;
    [SerializeField] private Button btn_aabbCircle;
    [SerializeField] private Button btn_raycastCircle;
    [SerializeField] private Button btn_spatialPartitionCircle;
    [SerializeField] private Button btn_clear;

    [Header("Text")]
    [SerializeField] private TMP_Text txt_spawnCount;
    [SerializeField] private TMP_Text txt_collisionCount;

    [Header("Circles")]
    [SerializeField] private GameObject colliderCirclePrefab;
    [SerializeField] private GameObject overlapCirclePrefab;
    [SerializeField] private GameObject aabbCirclePrefab;
    [SerializeField] private GameObject raycastCirclePrefab;
    [SerializeField] private GameObject spatialPartitioningCirclePrefab;

    [Space(10)]
    [SerializeField] private CircleTransform moveCircleTransform;
    [SerializeField] private CircleTransform stopCircleTransform;

    private GameObject curPrefab;
    
    private void Awake()
    {
        btn_spawn100.onClick.AddListener(() => { });
    }

    private void Spawn(GameObject prefab, int count)
    {
        int c = count / 2;

        for(int i =0; i < c; i ++)
        {

        }
        for (int i = 0; i < c; i++)
        {

        }
    }
}
