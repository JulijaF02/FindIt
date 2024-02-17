using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorObject : MonoBehaviour
{
    private Renderer rend;

    private bool hasChangedColor = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
     
    }

    public void ChangeColor()
    {
        if (!hasChangedColor)
        {
            rend.material.color = Random.ColorHSV(); // Change to a random color
            hasChangedColor = true;
        }
    }

    
}
