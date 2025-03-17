using System.Collections.Generic;
using UnityEngine;

public class AABBSystem : MonoBehaviour
{
    private List<GameObject> circles = new();
    private HashSet<(GameObject, GameObject)> collidedPairs = new(); // 이미 충돌한 객체 쌍 저장

    private void Update()
    {
        for (int i = 0; i < circles.Count; i++)
        {
            for (int j = i + 1; j < circles.Count; j++) // 중복 검사 방지
            {
                if (circles[i].layer == circles[j].layer) continue;

                var pair = (circles[i], circles[j]);

                if (!collidedPairs.Contains(pair) && IsCollision(circles[i].transform.position, circles[j].transform.position))
                {
                    CircleSpawner.instance.CollisionCheck();
                    collidedPairs.Add(pair); // 충돌한 객체 쌍 저장
                }
            }
        }
    }

    private bool IsCollision(Vector2 pos1, Vector2 pos2)
    {
        float distance = Vector2.Distance(pos1, pos2);
        return distance < 1;
    }

    public void SetCircle(GameObject circle)
    {
        circles.Add(circle);
    }

    public void ResetCollisions()
    {
        collidedPairs.Clear(); // 충돌 기록 초기화
    }
}