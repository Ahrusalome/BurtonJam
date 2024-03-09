using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    public void Interract()
    {
        GameManager._manager.inspectItem.StartInspecting(gameObject, Vector3.one);
    }
}
