using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // 클릭 위치에 큐브를 생성하기 위해서

    [SerializeField] private Camera uiCamera = null;

    private void Update()
    {
        // 마우스 클릭이 일어나면
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스를 클릭 한 위치에
            Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Raycast가 성공했을 때 호출

                // 큐브를 생성
                Cube cube = ObjectPool.Instance.GetObject();

                // 큐브를 마우스로 클릭한 위치에 옮기기
                // Tip. 오브젝트 크기 y 의 절반 값을 더해주면 이쁘게 올라온다.
                cube.transform.position = hit.point + new Vector3(0, cube.transform.localScale.y * 0.5f, 0);

                // 큐브를 생성한 뒤에는 일정 시간 뒤에 리셋되도록 설정
                cube.ResetAfterTime();
            }
            else
            {
                // Raycast가 실패했을 때 호출
            }
        }
    }
}