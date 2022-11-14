using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    public List<GameObject> objects;

    public bool perceptionEnabled = true;
    [SerializeField] SphereCollider sphereCollider;

    private void Start() {
        objects = new List<GameObject>();
    }

    public void disablePerception() {

        sphereCollider.enabled = false;
        objects.Clear();
        perceptionEnabled = false;

    }

    public void enablePerception() {
        sphereCollider.enabled = true;
        perceptionEnabled = true;
    }

    public void setVisionRadius(float visionRadius) {
        sphereCollider.radius = visionRadius;
    }

    private void OnTriggerEnter(Collider other) {

        objects.Add(other.gameObject);
        
    }

    private void OnTriggerExit(Collider other) {

        objects.Remove(other.gameObject);
        
    }

    private void OnDestroy() {
        objects.Clear();
    }


}
