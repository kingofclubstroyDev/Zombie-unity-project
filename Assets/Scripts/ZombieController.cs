using UnityEngine;

public class ZombieController : MonoBehaviour
{

    void Start()
    {
        ZombieTracker.addZombie(gameObject);
    }

    private void OnDestroy() {
        ZombieTracker.removeZombie(gameObject);
    }
}
