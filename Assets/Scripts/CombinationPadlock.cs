using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CombinationPadlock : MonoBehaviour, IInteractable
{
    public GameObject mainCam;
    public GameObject padlockCamera;
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
        mainCam.SetActive(false);
        padlockCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        UI.SetActive(false);
        mainCam.SetActive(true);
        padlockCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Check()
    {
        for (int i = 0; i < currentCode.Length; i++)
        {
            Debug.Log(currentCode[i] == code[i]);
            if (currentCode[i] != code[i])
            {
                // If any element doesn't match, return false
                return;
            }
        }
        Close();
        CodeIsCorrect.Invoke();
    }
}
