using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public GameObject[] livingRoomObjects;
    public GameObject[] bedroomObjects;
    public GameObject[] kitchenObjects;
    private HashSet<GameObject> objectsWithEvents = new HashSet<GameObject>();
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>(); // Store original positions
    private bool eventInProgress = false;
    private float timeSinceLastEvent = 0f;
    private float eventInterval = 3f; // Time interval between events (in seconds)
    private float initialDelay = 5f; // Initial delay before events start (in seconds)
    private bool initialDelayComplete = false;
    public int bedroomCounter = 0;
    public int kitchenCounter = 0;
    public int livingRoomCounter = 0;

    public bool gameIsOver = false; // Flag to track if the game is over


    void Start()
    {
        // Store original positions of living room objects
        foreach (GameObject obj in livingRoomObjects)
        {
            originalPositions[obj] = obj.transform.position;
        }
        // Store original positions of bedroom objects
        foreach (GameObject obj in bedroomObjects)
        {
            originalPositions[obj] = obj.transform.position;
        }
        // Store original positions of kitchen objects
        foreach (GameObject obj in kitchenObjects)
        {
            originalPositions[obj] = obj.transform.position;
        }
    }

    void Update()
    {
        if (!gameIsOver)
        {
            // Check if the initial delay has been completed
            if (!initialDelayComplete)
            {
                timeSinceLastEvent += Time.deltaTime;
                float timeLeftInitialDelay = Mathf.Max(initialDelay - timeSinceLastEvent, 0f);
                Debug.Log("Time left before events start: " + timeLeftInitialDelay.ToString("0.00") + " seconds");

                if (timeSinceLastEvent >= initialDelay)
                {
                    initialDelayComplete = true;
                    timeSinceLastEvent = 0f;
                }
            }
            else
            {
                // Check if an event is currently in progress
                if (!eventInProgress)
                {
                    timeSinceLastEvent += Time.deltaTime;
                    float timeLeftNextEvent = Mathf.Max(eventInterval - timeSinceLastEvent, 0f);
                    Debug.Log("Time left before next event: " + timeLeftNextEvent.ToString("0.00") + " seconds");

                    // If enough time has passed since the last event, trigger a new event
                    if (timeSinceLastEvent >= eventInterval)
                    {
                        TriggerRandomEvent();
                        timeSinceLastEvent = 0f;
                    }
                }
            }
        }
    }

    void TriggerRandomEvent()
    {
        // Randomly select an object that hasn't had an event yet
        GameObject obj = GetObjectWithoutEvent();

        if (obj != null)
        {

            // Trigger a random event on the selected object
            int randomEvent = Random.Range(0, 5);
            switch (randomEvent)
            {
                case 0:
                    if (obj.GetComponent<DisappearObjectt>() != null)
                        obj.GetComponent<DisappearObjectt>().Disappear();
                    break;
                case 1:
                    if (obj.GetComponent<MoveObject>() != null)
                        obj.GetComponent<MoveObject>().Move();
                    break;
                case 2:
                    if (obj.GetComponent<ChangeColorObject>() != null)
                        obj.GetComponent<ChangeColorObject>().ChangeColor();
                    break;
                case 3:
                    if (obj.GetComponent<SwitchObject>() != null)
                        obj.GetComponent<SwitchObject>().SwitchPlaces();
                    break;
                case 4:
                    if (obj.GetComponent<LampController>() != null)
                        obj.GetComponent<LampController>().ToggleSpotLight();
                    break;
            }

            // Add the object to the HashSet to mark that it has had an event triggered
            objectsWithEvents.Add(obj);

            // Update the counters for each room
            if (IsInRoom(obj, livingRoomObjects))
            {
                livingRoomCounter++;
                uiManager.IncrementCounter("Living Room"); // Call UIManager's IncrementCounter method
            }
            else if (IsInRoom(obj, bedroomObjects))
            {
                bedroomCounter++;
                uiManager.IncrementCounter("Bedroom"); // Call UIManager's IncrementCounter method
            }
            else if (IsInRoom(obj, kitchenObjects))
            {
                kitchenCounter++;
                uiManager.IncrementCounter("Kitchen"); // Call UIManager's IncrementCounter method
            }

            
        }

        // Mark that an event is now in progress
        eventInProgress = false;

        // Reset the event timer to start counting for the next event
        timeSinceLastEvent = 0f;
    }

    GameObject GetObjectWithoutEvent()
    {
        // Combine all objects from different rooms into one array
        GameObject[] allObjects = CombineArrays(livingRoomObjects, bedroomObjects, kitchenObjects);

        // Shuffle the array of objects to manage
        Shuffle(allObjects);

        // Iterate through the shuffled array to find an object without an event
        foreach (GameObject obj in allObjects)
        {
            if (!objectsWithEvents.Contains(obj))
            {
                return obj;
            }
        }

        // If all objects have had events, return null
        return null;
    }

    GameObject[] CombineArrays(params GameObject[][] arrays)
    {
        List<GameObject> combined = new List<GameObject>();
        foreach (GameObject[] array in arrays)
        {
            combined.AddRange(array);
        }
        return combined.ToArray();
    }

    void Shuffle(GameObject[] array)
    {
        // Fisher-Yates shuffle algorithm
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    bool IsInRoom(GameObject obj, GameObject[] roomObjects)
    {
        foreach (GameObject roomObj in roomObjects)
        {
            if (obj == roomObj)
            {
                return true;
            }
        }
        return false;
    }


    // Method to handle game over
    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameIsOver = true; 

        
    }



}
