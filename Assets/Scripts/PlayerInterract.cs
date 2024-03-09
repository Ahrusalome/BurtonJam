using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInterract : MonoBehaviour
{
    public Camera m_Camera;
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(m_Camera.transform.position, m_Camera.transform.forward * 4);
    }

    public void OnInterract(InputValue value)
    {
        RaycastHit hit;
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, 4f))
        {
            if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
            {
                Debug.Log("test");
                hit.transform.GetComponent<IInteractable>().Interract();
            }
        }
    }
}