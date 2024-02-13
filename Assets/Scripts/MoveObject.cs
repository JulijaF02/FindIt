using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject correspondingObject; // The corresponding object to toggle visibility

    public void Move()
    {
        // Check if the corresponding object exists
        if (correspondingObject != null)
        {
            // Toggle visibility of this object
            gameObject.SetActive(false);

            // Toggle visibility of the corresponding object
            correspondingObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Corresponding object not assigned.");
        }
    }
}
