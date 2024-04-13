using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float livingTime = 3.0f;

    public void ResetAfterTime()
    {
        StartCoroutine(Co_ResetAfterTime(livingTime));
    }

    private IEnumerator Co_ResetAfterTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ObjectPool.Instance.ResetForPool(this);
    }
}