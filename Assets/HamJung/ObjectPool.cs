using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectPool : MonoBehaviour
{
    // �̱���
    public static ObjectPool Instance = null;

    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }

    // Pool�� ���� �����̵Ǵ� ���ӿ�����Ʈ
    [SerializeField] private GameObject go_prefab_cube = null;

    // List, Array, Queue
    // Cube��� ������ ���� �� �ִ� Queue ����.
    // �ڷ� ���� �߿� Queue. Stack�� ����.
    // Queue�� ���Լ��� (���� ������ ���� ����)
    // Stack�� ���Լ��� (���߿� ������ ���� ����)
    [SerializeField] private Queue<Cube> cubePoolObject = new Queue<Cube>();

    // 1. �ʱ�ȭ : ó���� N���� ������Ʈ���� �̸� ������ ����
    public void Initialize(int count)
    {
        // Queue�� ���� ���� �� Enqueue
        // Queue�� ���� �� �� DeQueue
        for (int i = 0; i < count; i++)
        {
            cubePoolObject.Enqueue(CreateObjtct());
        }
    }

    // 1-1. ---------- ������Ʈ Instantiate
    private Cube CreateObjtct() // �Ǵ� InstantiateObject
    {
        // ������Ʈ�� Instantiate
        Cube cube = GameObject.Instantiate(go_prefab_cube).GetComponent<Cube>();

        // ������Ʈ�� ��Ȱ��ȭ�� ���·� �����
        cube.gameObject.SetActive(false);

        // ������ ������Ʈ�� ���� �ڽ� ������Ʈ��� �����
        cube.transform.SetParent(this.transform);

        return cube;
    }

    // 2. ������� �ʴ� ���� ������Ʈ ��������
    public Cube GetObject()
    {
        Cube cube;

        if (cubePoolObject.Count <= 0)
            cube = CreateObjtct();
        else
            cube = cubePoolObject.Dequeue();

        // ������Ʈ�� Ȱ��ȭ���·� �ٲ��ֱ�
        cube.gameObject.SetActive(true);

        // ������Ʈ�� �� �ڽĿ��� �������ֱ�
        cube.transform.SetParent(null);

        return cube;
    }

    // 3. ����� ���� ������Ʈ�� ��ȯ�ϱ�
    public void ResetForPool(Cube cube)
    {
        // ������Ʈ�� ��Ȱ��ȭ ��Ű��
        cube.gameObject.SetActive(false);
        // ������Ʈ�� �� �ڽ����� �����
        cube.transform.SetParent(this.transform);
        // ť�� ����
        cubePoolObject.Enqueue(cube);
    }
}