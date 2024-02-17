using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObjectt : MonoBehaviour
{
    private MeshRenderer meshRenderer;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
  
    }

    public void Disappear()
    {
        // If the object has not already disappeared
        if (meshRenderer.enabled)
        {
            // Disable the mesh renderer to make the object disappear
            meshRenderer.enabled = false;
        }
    }

  
}
