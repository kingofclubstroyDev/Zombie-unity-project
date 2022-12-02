using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Clicked() {
    
        if(isPaused == true) {
        
            Time.timeScale = 1;
            isPaused = false;
        
        } else {
        
            Time.timeScale = 0;
            isPaused = true;
        
        }
        
    }
    
}
