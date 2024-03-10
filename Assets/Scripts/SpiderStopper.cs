using System;
using System.Collections;
using UnityEngine;

public class SpiderStopper : MonoBehaviour
{
    [SerializeField] private float stepBackSpeed;
    [SerializeField] private Transform stepBackFinishPoint;
    [SerializeField] private PlayerController playerController;
    private bool spiderIsTriggered = true;
    [SerializeField] private Spider spider;
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager._manager.spiderIsBig)
        {
            spider.changeMultiplier = 2f;
            StartCoroutine(spider.ChangeScale());
            StartCoroutine(StepBack(other.transform));
        }
        else
        {
            spider.changeMultiplier = 0.2f;
            StartCoroutine(spider.ChangeScale());
        }
    }

    private IEnumerator StepBack(Transform playerTransform)
    {
        for (float elapsedTime = 0; elapsedTime <= 1; elapsedTime += Time.unscaledDeltaTime)
        {
            spiderIsTriggered = false;
            yield return playerTransform.position = new Vector3(transform.position.x, 16.9f, Mathf.Lerp(transform.position.z, stepBackFinishPoint.position.z, elapsedTime*stepBackSpeed));
        }
    }
}