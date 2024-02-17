using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject duplicateObject;
    private bool originalState = true;

    public void Move()
    {
        if (!originalState)
        {
            gameObject.SetActive(false);
            duplicateObject.SetActive(true);
            originalState = false;
        }
    }

   
}
