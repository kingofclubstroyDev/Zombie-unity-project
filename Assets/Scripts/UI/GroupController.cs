using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupController : MonoBehaviour
{
    
    public void Clicked(int num) {
        // Debug.Log("CLICKED");
        GameEvents.instance.GroupSelected(num);
    }
}
