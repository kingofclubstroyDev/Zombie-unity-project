using UnityEngine;
public class EnemyController : MonoBehaviour
{
    void Start()
    {
        EnemyTracker.addEnemy(gameObject);
    }
    private void OnDestroy() {
        EnemyTracker.removeEnemy(gameObject);
    }
}
