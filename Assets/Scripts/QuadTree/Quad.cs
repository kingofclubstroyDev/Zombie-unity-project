using System.Collections.Generic;
using UnityEngine;

public class Quad {
    List<GameObject> points = new List<GameObject>();
    List<Quad> children = new List<Quad>();
    Vector3 location;
    float width;
    int maxPoints;

    public Quad(Vector3 _location, float _width, int _maxPoints) {
        maxPoints = _maxPoints;
        location = _location;
        width = _width;
    }

    public void clear() {
        points?.Clear();
        for (int i = 0; i < children.Count; i++) {
            if (children[i] != null) {
                children[i].clear();
                children[i] = null;
            }
        }
    }

    public void AddPoint(GameObject obj) {
        if(children.Count > 0) {
            addToChildren(obj);
            return;
        }
        points.Add(obj);
        if(points.Count == maxPoints) {
            SplitQuad();
        }
    }

    private void addToChildren(GameObject obj) {
        children[getChildIndex(obj.transform.position)].AddPoint(obj);
    }

    private int getChildIndex(Vector3 pos) {

        float newWidth = width/2;

        if(pos.x <= location.x + newWidth) {
            if(pos.z <= location.z + newWidth) {
                return 0;
            }
            return 1;
        }
        if(pos.z <= location.z + newWidth) {
            return 2;
        }
        return 3;
    }


    private void SplitQuad() {

        float newWidth = width/2;

        children.Add(new Quad(location, newWidth, maxPoints));

        children.Add(new Quad(new Vector2(location.x, location.z + newWidth), newWidth, maxPoints));

        children.Add(new Quad(new Vector2(location.x + newWidth, location.z), newWidth, maxPoints));

        children.Add(new Quad(new Vector2(location.x + newWidth, location.z + newWidth), newWidth, maxPoints));

        foreach(GameObject obj in points) {
            children[getChildIndex(obj.transform.position)].AddPoint(obj);
        }

        points.Clear();

    }

    public List<GameObject> getNearbyGameobjects(Vector3 pos, float range, List<GameObject> objects) {

        if(QuadTree.checkOverlap(range, pos.x, pos.z, location.x, location.z, location.x + width, location.z + width) == false) return objects;

        if(points.Count > 0) {
            objects.AddRange(points);
            return objects;
        }

        foreach(Quad quad in children) {
            objects = quad.getNearbyGameobjects(pos, range, objects);
        }
       
        return objects;
    }
}