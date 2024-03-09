using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour
{
    private int hits;
    private int code;
    [SerializeField] private int password;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitButton(int number)
    {
        Debug.Log($"hit {number}");
        if (hits < 4)
        {
            code *=10;
            code += number;
        } else {
            if (code == password)
            {
                Debug.Log($"Unlock !!");
            }
        }
    }
}
