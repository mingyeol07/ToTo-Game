using System.Collections.Generic;
using UnityEngine;

public class AABBSystem : MonoBehaviour
{
    private HashSet<(GameObject, Transform)> collidedPairs = new(); // �̹� �浹�� ��ü �� ����

    [SerializeField] private CircleTransform circleTransform;
    [SerializeField] private Transform[] stopCircles;


    public void CheckAABB() {

        for (int i = 0; i < circleTransform.circles.Count; i++)
        {
            for (int j = i + 1; j < stopCircles.Length; j++) // �ߺ� �˻� ����
            {
                var pair = (circleTransform.circles[i], stopCircles[j]);

                if (!collidedPairs.Contains(pair) && IsCollision(circleTransform.circles[i].transform.position, stopCircles[j].position))
                {
                    stopCircles[j].GetComponent<StopCircle>().OnCollistion();
                    collidedPairs.Add(pair); // �浹�� ��ü �� ����
                }
            }
        }
    }

    private bool IsCollision(Vector2 pos1, Vector2 pos2)
    {
        float distance = Vector2.Distance(pos1, pos2);
        return distance < 1;
    }
}