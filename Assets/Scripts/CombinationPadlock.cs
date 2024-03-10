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
        //if (currentCode[index] == 9)
        //    return;
        currentCode[index] = Wrap(currentCode[index] + 1, 0, 9);
        UpdateInputField(index);
        Check();
    }

    public void DecrementDigit(int index)
    {
        //if (currentCode[index] == 0)
        //    return;
        currentCode[index] = Wrap(currentCode[index] - 1, 0, 9);
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

    private int Wrap(int _initialValue, int _min, int _max)
    {
        if ((_initialValue) > _max) return _min;
        if ((_initialValue) < _min) return _max;
        return _initialValue;
    }
}
