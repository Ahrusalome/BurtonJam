using System;
using System.Collections;
using UnityEngine;

public class SpiderStopper : MonoBehaviour
{
    [SerializeField] private float stepBackSpeed;
    [SerializeField] private Transform stepBackFinishPoint;
    [SerializeField] private PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager._manager.spiderIsBig)
            return;
        StartCoroutine(StepBack(other.transform));
    }

    private IEnumerator StepBack(Transform playerTransform)
    {
        for (float elapsedTime = 0; elapsedTime <= 1; elapsedTime += Time.unscaledDeltaTime)
        {
            playerController.HandleHeadBob();
            yield return playerTransform.position = new Vector3(transform.position.x, 16.7f, Mathf.Lerp(transform.position.z, stepBackFinishPoint.position.z, elapsedTime*stepBackSpeed));
        }
    }
}