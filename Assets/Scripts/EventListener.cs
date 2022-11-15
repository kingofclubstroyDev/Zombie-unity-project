using UnityEngine;

public class EventListener : MonoBehaviour {

    private void Start() {
        GameEvents.instance.onUnitDeath += onUnitDeath;
    }

    private void onUnitDeath(GameObject obj) {

        print("EventListener: onUnitDeath: " + obj.name);

    }

    private void OnDestroy() {
        GameEvents.instance.onUnitDeath -= onUnitDeath;
    }
    
}