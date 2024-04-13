using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Ŭ�� ��ġ�� ť�긦 �����ϱ� ���ؼ�

    [SerializeField] private Camera uiCamera = null;

    private void Update()
    {
        // ���콺 Ŭ���� �Ͼ��
        if (Input.GetMouseButtonUp(0))
        {
            // ���콺�� Ŭ�� �� ��ġ��
            Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Raycast�� �������� �� ȣ��

                // ť�긦 ����
                Cube cube = ObjectPool.Instance.GetObject();

                // ť�긦 ���콺�� Ŭ���� ��ġ�� �ű��
                // Tip. ������Ʈ ũ�� y �� ���� ���� �����ָ� �̻ڰ� �ö�´�.
                cube.transform.position = hit.point + new Vector3(0, cube.transform.localScale.y * 0.5f, 0);

                // ť�긦 ������ �ڿ��� ���� �ð� �ڿ� ���µǵ��� ����
                cube.ResetAfterTime();
            }
            else
            {
                // Raycast�� �������� �� ȣ��
            }
        }
    }
}