using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class phone : MonoBehaviour
{
    private int hits;
    private string code;
    [SerializeField] private string password;
    [SerializeField] private TMP_Text passwordDidplay;

    [SerializeField] private GameObject phoneCanvas;
    [SerializeField] private BoxCollider phoneCollider;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        Debug.Log($"start");
    }
    

    private void UpdatePassword()
    {
        passwordDidplay.text = new string('●', code.Length);
    }

    public void hitButton(string letter)
    {
        code+=letter;
        UpdatePassword();
    }

    public void delete()
    {
        code = code.Remove(code.Length-1);
        UpdatePassword();
    }

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        phoneCanvas.SetActive(false);
        phoneCollider.enabled = true;
    }
    public void done()
    {
        if (code == password)
        {
            Debug.Log($"Unlock");
        }
    }
}
