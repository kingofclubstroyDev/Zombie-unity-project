using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitConversion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onUnitInfected += convertUnit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void convertUnit(GameObject target, GameObject newUnit) {

        target.SetActive(false);

        Instantiate(newUnit, target.transform.position, target.transform.rotation);

        Destroy(target);

    }


}
