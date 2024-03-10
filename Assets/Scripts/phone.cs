using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class phone : MonoBehaviour
{
    private int hits;
    private string code;
    [SerializeField] private string password;
    [SerializeField] private TMP_Text passwordDidplay;
    [SerializeField] private GameObject PhoneMenu;
    [SerializeField] private BoxCollider phoneCollider;
    [SerializeField] private GameObject MessageMenu;
    [SerializeField] private GameObject Message;
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
        MessageMenu.SetActive(false);
        PhoneMenu.SetActive(false);
        phoneCollider.enabled = true;
    }
    public void Done()
    {
        if (code == password)
        {
            StartCoroutine("SendMessage");            
        }
    }

    private IEnumerator SendMessage()
    {
        PhoneMenu.SetActive(false);
        MessageMenu.SetActive(true);
        yield return new WaitForSeconds(1f);
        Message.SetActive(true);
    }
}
