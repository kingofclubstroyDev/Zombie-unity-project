using UnityEngine;

public class EventListener : MonoBehaviour {

    private void Start() {
        GameEvents.instance.onUnitDeath += onUnitDeath;
    }

    private void onUnitDeath(GameObject obj) {

        print("unit died");

    }

    private void OnDestroy() {
        GameEvents.instance.onUnitDeath -= onUnitDeath;
    }
    
}