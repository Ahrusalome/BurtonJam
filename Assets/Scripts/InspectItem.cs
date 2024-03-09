using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InspectItem : MonoBehaviour
{
    public GameObject inspectCam;
    public GameObject mainCam;
    
    private GameObject _currentInspectObject;

    private Vector3 inspectDirection;

    public void StartInspecting(GameObject inspectObject)
    {
        GameManager._manager.state = PlayerState.inspect;
        inspectCam.SetActive(true);
        mainCam.SetActive(false);
        _currentInspectObject = Instantiate(inspectObject, inspectCam.transform.position + (transform.forward * 3), Quaternion.identity);
    }

    public void Update() 
    {
        if (GameManager._manager.state == PlayerState.inspect)
        {
            _currentInspectObject.transform.Rotate(Vector3.up, inspectDirection.x * Time.deltaTime * 50);
            _currentInspectObject.transform.Rotate(Vector3.right, inspectDirection.y * Time.deltaTime * 50);
        }
    }

    public void StopInspeting()
    {
        GameManager._manager.state = PlayerState.move;
        inspectCam.SetActive(false);
        mainCam.SetActive(true);
        Destroy(_currentInspectObject);
        _currentInspectObject = null;
    }

    public void OnStopInspect(InputValue value)
    {
        if (GameManager._manager.state == PlayerState.inspect)
        {
            StopInspeting();
        }
    }

    public void OnInspect(InputValue value) => inspectDirection = value.Get<Vector2>();
}
