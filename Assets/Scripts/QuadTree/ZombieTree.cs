using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZombieTree : MonoBehaviour
{

    QuadTree quadTree;
    public static ZombieTree instance;

    public List<GameObject> getNearbyObjects(Vector3 position, float range) {

        return quadTree.getNearbyObjects(position, range, ZombieTracker.getZombies());
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        quadTree = new QuadTree();

    }

    void Update() {

        quadTree.initializedThisFrame = false;

    }

}