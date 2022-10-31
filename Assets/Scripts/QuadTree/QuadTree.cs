using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class QuadTree : MonoBehaviour
{
    [SerializeField] int maxPoints;
    public static QuadTree instance;
    public bool initializedThisFrame;
    Quad rootQuad;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update() {

        initializedThisFrame = false;

    }

    private void initializeQuad(List<GameObject> gameObjects, float width) {

        if(initializedThisFrame) return;

        initializedThisFrame = true;

        if(rootQuad != null) {
            rootQuad.clear();
        }

        rootQuad = new Quad(new Vector3(0,0,0), width, maxPoints);

        foreach(GameObject obj in gameObjects) {
            rootQuad.AddPoint(obj);
        }

    }
    public List<GameObject> getNearbyObjects(Vector2 position, float range) {
        if(! initializedThisFrame) {
            initializeQuad(EnemyTracker.getEnemies(), 1000);
        }
        return rootQuad.getNearbyGameobjects(position, range, new List<GameObject>());
    }

    public static bool checkOverlap(float R, float Xc, float Yc,
                                    float X1, float Y1,
                                    float X2, float Y2)
    {
        float Xn = Mathf.Max(X1,
                Mathf.Min(Xc, X2));
        float Yn = Mathf.Max(Y1,
                Mathf.Min(Yc, Y2));
        
        float Dx = Xn - Xc;
        float Dy = Yn - Yc;
        return (Dx * Dx + Dy * Dy) <= R * R;
    }

}
