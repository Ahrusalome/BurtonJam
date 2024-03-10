using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInterract : MonoBehaviour
{
    public GameObject interactText;
    public Camera m_Camera;
    void Start()
    {
        m_Camera = Camera.main;
    }

    private void Update()
    {
        if (GameManager._manager.state == PlayerState.inspect)
        {
            interactText.SetActive(false);
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, 4f))
        {
            if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
            {
                interactText.SetActive(true);
            }
            else interactText.SetActive(false);
        }
        else interactText.SetActive(false);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawRay(m_Camera.transform.position, m_Camera.transform.forward * 4);
    //}

    public void OnInterract(InputValue value)
    {
        if (GameManager._manager.state == PlayerState.inspect) return;

        RaycastHit hit;
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, 4f))
        {
            if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
            {
                hit.transform.GetComponent<IInteractable>().Interract();
                interactText.SetActive(false);
            }
        }
    }
}