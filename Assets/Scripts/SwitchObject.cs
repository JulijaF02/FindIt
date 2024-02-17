using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour
{
    public GameObject otherObject;
   
    private bool hasSwitchedPlaces = false;

   

    public void SwitchPlaces()
    {
        if (!hasSwitchedPlaces)
        {
            Vector3 tempPosition = transform.position;
            transform.position = otherObject.transform.position;
            otherObject.transform.position = tempPosition;
            hasSwitchedPlaces = true;
        }
    }

    
}
