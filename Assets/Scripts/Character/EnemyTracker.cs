using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{

    private static List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update

    private void OnDestroy() {
        removeEnemy(gameObject);
    }

     public static void removeEnemy(GameObject enemy) {
        enemies.Remove(enemy);
    }

    public static void addEnemy(GameObject enemy) {
        enemies.Add(enemy);
    }

    public static List<GameObject> getEnemies() {
        return enemies;
    }

}
