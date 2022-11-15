using UnityEngine;

public class EventListener : MonoBehaviour {

    private void Start() {
        GameEvents.instance.onUnitDeath += onUnitDeath;
        GameEvents.instance.onUnitAttackTarget += onUnitAttackTarget;
    }

    private void onUnitDeath(GameObject obj) {

        print("EventListener: onUnitDeath: " + obj.name);

    }
    
    private void onUnitAttackTarget(GameObject obj) {
        print("EventListener: onUnitAttackTarget: " + obj.name);
    }

    private void OnDestroy() {
        GameEvents.instance.onUnitDeath -= onUnitDeath;
        GameEvents.instance.onUnitAttackTarget -= onUnitAttackTarget;
    }
    
}