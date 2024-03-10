using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QTE : MonoBehaviour
{
    public CinemachineVirtualCamera qteCam;
    public GameObject monster;
    private bool enable = false;
    private int goal;
    private bool clickedLeft = false;
    private int _currentPoints;
    public int currentPoints { 
        get {return _currentPoints;}
        set {_currentPoints = value<0 ? 0 : value;}
    }
    private PlayerInput playerInput;
    [SerializeField] private Slider progressionBar;

    [SerializeField] private Canvas qteCanvas;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        LaunchQTE(100);
        progressionBar.maxValue = goal;
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            if (currentPoints >= goal) 
            {
                EndQTE();
            }
            progressionBar.value = currentPoints;
        }
    }

    private IEnumerable QTECoroutine()
    {
        currentPoints -=2;
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator DespawnMonster()
    {
        yield return new WaitForSeconds(2f);
        Destroy(monster);
    }

    void LaunchQTE(int goal)
    {
        this.goal = goal;
        this.currentPoints = 0;
        this.enable = true;
        progressionBar.gameObject.SetActive(true);
        StartCoroutine("QTECoroutine");
        playerInput.SwitchCurrentActionMap("QTE");
    }

    private void EndQTE()
    {
        this.enable = false;
        qteCanvas.enabled = false;
        playerInput.SwitchCurrentActionMap("Ground");
        // Start animation
        qteCam.Priority = 10;
        StartCoroutine(DespawnMonster());
    }

    public void OnLeft()
    {
        if (!clickedLeft)
        {
            clickedLeft = true;
            this.currentPoints+=3;
        }
    }
    public void OnRight()
    {
        if (clickedLeft)
        {
            clickedLeft = false;
            this.currentPoints+=3;
        }
    }
}
