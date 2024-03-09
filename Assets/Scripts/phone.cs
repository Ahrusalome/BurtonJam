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
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        Debug.Log($"start");
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void done()
    {
        if (code == password) 
        {
            Debug.Log($"Unlock");
        }
    }
}
