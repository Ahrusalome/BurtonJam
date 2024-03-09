using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    public UnityEvent onInterract;
    private Vector3 originalPositon;

    private void Start()
    {
        originalPositon = transform.position;
    }
    public void Interract()
    {
        GameManager._manager.StartInspecting();
        //onInterract.Invoke();
    }

    public void test(string _test)
    {
        //Debug.Log(_test);
    }
}
