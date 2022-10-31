using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private void OnDestroy() {
        ZombieTracker.removeZombie(gameObject);
    }
}
