using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour
{
    public GameObject objectToSwapWith;

    public void Swap()
    {
        Vector3 tempPosition = transform.position;
        transform.position = objectToSwapWith.transform.position;
        objectToSwapWith.transform.position = tempPosition;
    }
}
