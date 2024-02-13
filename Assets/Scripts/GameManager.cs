using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] objectsToManage; // Array of objects to manage
    private float timeSinceLastAction = 0f;
    private float actionInterval = 30f;

    void Update()
    {
        
        timeSinceLastAction += Time.deltaTime;

        
        if (timeSinceLastAction >= actionInterval)
        {

            timeSinceLastAction = 0f;
            RandomObjectAction();

            
            
        }

    }

    void RandomObjectAction()
    {
        
        
            int randomObjectIndex = Random.Range(0, objectsToManage.Length);
            GameObject objectToManage = objectsToManage[randomObjectIndex];

            // Randomly choose an action to perform
            int randomAction = Random.Range(0, 4);

            // Perform the selected action
            switch (randomAction)
            {
                case 0:
                    ChangeColorObject colorScript = objectToManage.GetComponent<ChangeColorObject>();
                    if (colorScript != null)
                    {
                        colorScript.ChangeColor();
                    }
                    break;
                case 1:
                    MoveObject moveScript = objectToManage.GetComponent<MoveObject>();
                    if (moveScript != null)
                    {
                        moveScript.Move();
                    }
                    break;
                case 2:
                    DisappearObjectt disappearScript = objectToManage.GetComponent<DisappearObjectt>();
                    if (disappearScript != null)
                    {
                        disappearScript.Disappear();
                    }
                    break;
                case 3:
                    SwitchObject switchScript = objectToManage.GetComponent<SwitchObject>();
                    if (switchScript != null)
                    {
                        switchScript.Swap();
                    }
                    break;
            }
        
       
    }



}
