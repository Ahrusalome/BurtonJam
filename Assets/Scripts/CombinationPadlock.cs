using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Cinemachine;

public class CombinationPadlock : MonoBehaviour, IInteractable
{
    public CinemachineVirtualCamera padlockCamera;
    [SerializeField] private int[] code;
    private int[] currentCode = new int[4];
    [SerializeField] private GameObject UI;

    public Text[] text;

    public UnityEvent CodeIsCorrect;
    void Start()
    {
        // Initialize digit values
        currentCode = new int[text.Length];
        for (int i = 0; i < currentCode.Length; i++)
        {
            currentCode[i] = 0;
            UpdateInputField(i);
        }
    }
    public void IncrementDigit(int index)
    {
        currentCode[index] += 1;
        UpdateInputField(index);
        Check();
    }

    public void DecrementDigit(int index)
    {
        currentCode[index] -= 1;
        UpdateInputField(index);
        Check();
    }

    void UpdateInputField(int index)
    {
        text[index].text = currentCode[index].ToString();
    }

    public void Interract()
    {
        UI.SetActive(true);
        padlockCamera.Priority = 12;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        UI.SetActive(false);
        padlockCamera.Priority = 10;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Check()
    {
        for (int i = 0; i < currentCode.Length; i++)
        {
            if (currentCode[i] != code[i]) return;
        }
        Close();
        CodeIsCorrect.Invoke();
    }
}
