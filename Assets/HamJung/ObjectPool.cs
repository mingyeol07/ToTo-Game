using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectPool : MonoBehaviour
{
    // 싱글톤
    public static ObjectPool Instance = null;

    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }

    // Pool을 만들 기준이되는 게임오브젝트
    [SerializeField] private GameObject go_prefab_cube = null;

    // List, Array, Queue
    // Cube라는 형식을 담을 수 있는 Queue 선언.
    // 자료 구조 중에 Queue. Stack이 있음.
    // Queue는 선입선출 (먼저 넣은게 먼저 나옴)
    // Stack은 후입선출 (나중에 넣은게 먼저 나옴)
    [SerializeField] private Queue<Cube> cubePoolObject = new Queue<Cube>();

    // 1. 초기화 : 처음에 N개의 오브젝트들을 미리 생성해 놓음
    public void Initialize(int count)
    {
        // Queue에 값을 넣을 땐 Enqueue
        // Queue에 값을 뺄 땐 DeQueue
        for (int i = 0; i < count; i++)
        {
            cubePoolObject.Enqueue(CreateObjtct());
        }
    }

    // 1-1. ---------- 오브젝트 Instantiate
    private Cube CreateObjtct() // 또는 InstantiateObject
    {
        // 오브젝트를 Instantiate
        Cube cube = GameObject.Instantiate(go_prefab_cube).GetComponent<Cube>();

        // 오브젝트를 비활성화된 상태로 만들기
        cube.gameObject.SetActive(false);

        // 생성된 오브젝트를 나의 자식 오브젝트들로 만들기
        cube.transform.SetParent(this.transform);

        return cube;
    }

    // 2. 사용하지 않는 중인 오브젝트 가져오기
    public Cube GetObject()
    {
        Cube cube;

        if (cubePoolObject.Count <= 0)
            cube = CreateObjtct();
        else
            cube = cubePoolObject.Dequeue();

        // 오브젝트를 활성화상태로 바꿔주기
        cube.gameObject.SetActive(true);

        // 오브젝트를 내 자식에서 해제해주기
        cube.transform.SetParent(null);

        return cube;
    }

    // 3. 사용이 끝난 오브젝트를 반환하기
    public void ResetForPool(Cube cube)
    {
        // 오브젝트를 비활성화 시키기
        cube.gameObject.SetActive(false);
        // 오브젝트를 내 자식으로 만들기
        cube.transform.SetParent(this.transform);
        // 큐에 저장
        cubePoolObject.Enqueue(cube);
    }
}