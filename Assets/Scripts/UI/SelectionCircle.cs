using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCircle : MonoBehaviour
{
    private bool isHidden;
    
    // Start is called before the first frame update
    void Start()
    {
        isHidden = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowHide() {
    
        if(isHidden == true) {
            gameObject.SetActive(true);
            isHidden = false;
        } else {
            gameObject.SetActive(false);
            isHidden = true;
        }
    
    }
}
