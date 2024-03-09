using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    move,
    inspect,
    cinematic
}
public class GameManager : MonoBehaviour
{
    public static GameManager _manager;
    public PlayerState state;
    
    void Start()
    {
        GameManager._manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInspecting()
    {
        state = PlayerState.inspect;
        
    }

    public void StopInspeting()
    {
        state = PlayerState.move;
    }
}
