using UnityEngine;

public class CameraCTRL : MonoBehaviour
{
    private Vector3 cameraOriginPoint;
    private Vector3 offset;
    private bool dragging;
    
     private void LateUpdate()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 
        (10f * Camera.main.orthographicSize * .1f), 2.5f, 50f) ;

        if (Input.GetMouseButton(2))
        {
            offset = ();
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
