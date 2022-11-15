using UnityEngine;
public class UnitController : MonoBehaviour
{
    private void OnDestroy() {
        GameEvents.instance.UnitDeath(gameObject);
    }
}
