using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObjectt : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        // Get the MeshRenderer component attached to the object
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            // If MeshRenderer component is not found, log an error
            Debug.LogError("MeshRenderer component not found on object: " + gameObject.name);
        }
    }

    public void Disappear()
    {
        // Toggle the visibility of the MeshRenderer component
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false; // Disable the MeshRenderer to make the object disappear
        }
    }
}
