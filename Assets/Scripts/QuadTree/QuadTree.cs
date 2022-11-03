using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class QuadTree
{
    [SerializeField] int maxPoints;
    public static QuadTree instance;
    public bool initializedThisFrame;
    Quad rootQuad;

    

    private void initializeQuad(List<GameObject> gameObjects, float width) {

        if(initializedThisFrame) return;

        initializedThisFrame = true;

        if(rootQuad != null) {
            rootQuad.clear();
        }

        rootQuad = new Quad(new Vector3(0,0,0), width, maxPoints);
        int i = 0;
        foreach(GameObject obj in gameObjects) {
            //print(obj);
            //print(i);
            rootQuad.AddPoint(obj);

            i++;
        }

    }
    public List<GameObject> getNearbyObjects2(Vector2 position, float range) {
        if(! initializedThisFrame) {
            //TODO: make size dynamic and not enemy specific
            initializeQuad(EnemyTracker.getEnemies(), 1000);
        }
        return rootQuad.getNearbyGameobjects(position, range, new List<GameObject>());
    }

    internal List<GameObject> getNearbyObjects(Vector3 position, float range,  List<GameObject> objects) {
       

        List<GameObject> nearby = new List<GameObject>();

        foreach(GameObject obj in objects) {

            if(Vector3.Distance(position, obj.transform.position) <= range) {
                nearby.Add(obj);
            }

        }

        return nearby;

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
