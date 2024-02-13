using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    

    void Start()
    {
        
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToggleCameras();
        }
    }

    void ToggleCameras()
    {
        // Toggle the active camera
        mainCamera.enabled = !mainCamera.enabled;
        secondaryCamera.enabled = !secondaryCamera.enabled;
        
    }
}
