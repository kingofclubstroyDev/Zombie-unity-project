using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieUI : MonoBehaviour
{
    
    private GameObject selectionCircle;
    public int groupNum;
    private SpriteRenderer SR; 
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onGroupSelected += ShowHide;
        
        selectionCircle = this.gameObject.transform.GetChild(1).gameObject;
        
        SR = selectionCircle.GetComponent<SpriteRenderer>();
        
        if(groupNum == 1) {
        
            SR.color = Color.blue;
            
        } else if(groupNum == 2) {
        
            SR.color = Color.red;
            
        } else if(groupNum == 3) {
        
            SR.color = Color.yellow;
            
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnDestroy() {
        GameEvents.instance.onGroupSelected -= ShowHide;
    }
    
    public void ShowHide(int num) {
        
        if(groupNum == num) {
        
            if(selectionCircle.activeSelf == true) {
            
                selectionCircle.SetActive(false);
            
            } else {
            
                selectionCircle.SetActive(true);
                
            }
        }
        
    
    }
}
