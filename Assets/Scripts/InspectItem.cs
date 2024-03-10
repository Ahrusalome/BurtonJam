using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InspectItem : MonoBehaviour
{
    public CinemachineVirtualCamera inspectCam;
    
    private GameObject _currentInspectObject;

    private Vector3 inspectDirection;
    private bool canRotate;
    private bool isInspect;
    private float zoomLevel = 3;

    public void StartInspecting(GameObject inspectObject, Vector3 scale, bool _canRotate = true)
    {
        Cursor.lockState = CursorLockMode.None;
        canRotate = _canRotate;
        GameManager._manager.state = PlayerState.inspect;
        inspectCam.Priority = 12;
        _currentInspectObject = Instantiate(inspectObject, inspectCam.transform.position + (transform.forward * 3), Quaternion.identity);
    }

    public void Update() 
    {
        if (GameManager._manager.state != PlayerState.inspect) return;
        if (canRotate && isInspect)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _currentInspectObject.transform.Rotate(Vector3.up, -inspectDirection.x * Time.deltaTime * 50);
            _currentInspectObject.transform.Rotate(Vector3.right, inspectDirection.y * Time.deltaTime * 50);
        }
        else Cursor.lockState = CursorLockMode.None;
        _currentInspectObject.transform.position = inspectCam.transform.position + (transform.forward * zoomLevel);
    }

    public void StopInspeting()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameManager._manager.state = PlayerState.move;
        inspectCam.Priority = 10;
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
    public void OnStartInspect(InputValue value) => isInspect = value.isPressed;

    public void OnZoom(InputValue value)
    {
        float zoom = value.Get<float>();
        zoomLevel += zoom * Time.deltaTime;
        zoomLevel = Mathf.Clamp(zoomLevel, 1.5f, 3);
    }
}
