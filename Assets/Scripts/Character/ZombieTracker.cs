using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTracker : MonoBehaviour
{

    private static List<GameObject> zombies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        zombies.Add(gameObject);
    }

    private void Update() {
        
    }

    private void OnDestroy() {
        removeZombie(gameObject);
    }

    public static void ClearZombies() {
        zombies.Clear();
    }

    public static void removeZombie(GameObject zombie) {
        zombies.Remove(zombie);
    }

    public static void addZombie(GameObject zombie) {
        zombies.Add(zombie);
    }

    public static List<GameObject> getZombies() {
        return zombies;
    }

}
