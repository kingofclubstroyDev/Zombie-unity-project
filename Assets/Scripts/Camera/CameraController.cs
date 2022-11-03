using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;
    private Camera theCam;
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float zoomSensitivity;
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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h != 0 || v != 0) {
        
            transform.Translate(new Vector3(h, v).normalized * moveSpeed);

        }

        float zoom = Input.mouseScrollDelta.y;

        if(zoom != 0) {
        
            targetZoom += zoom * zoomSensitivity;
            float newSize = Mathf.MoveTowards(theCam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
            theCam.orthographicSize = newSize;

        }
          
          
    }
}
