using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{

    [SerializeField] GameObject newZombie;

    public void infect(Vector3 position, Quaternion quaternion) {

        if(newZombie == null) {
            Debug.LogError("Infection: infect: new zombie is null");
        }

        Instantiate(newZombie, position, quaternion);

    }

}