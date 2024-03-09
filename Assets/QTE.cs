using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    private bool enable = false;
    private int goal;
    private int _currentPoints;
    public int currentPoints { 
        get {return _currentPoints;}
        set {_currentPoints = value<0 ? 0 : value;}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            if (currentPoints >= goal) 
            {
                EndQTE();
            } else {
                currentPoints--;
            }
        }
    }

    void LaunchQTE(int goal)
    {
        this.goal = goal;
        this.currentPoints = 0;
        this.enable = true;
    }

    private void EndQTE()
    {
        this.enable = false;
        // Start animation
    }


}
