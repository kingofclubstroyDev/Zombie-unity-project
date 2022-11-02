using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;
    private Camera theCam;
    public float moveSpeed;
    public float zoomSpeed;
    public float zoomSensitivity;
    float targetZoom;
    
    public void Awake() 
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        theCam = GetComponent<Camera>();
        targetZoom = theCam.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {   
    
        
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed);
        
        targetZoom += Input.mouseScrollDelta.y * zoomSensitivity;
        float newSize = Mathf.MoveTowards(theCam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
        theCam.orthographicSize = newSize;
          
          
    }
}
