using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionSystem : MonoBehaviour {
    [SerializeField] GameObject[] subscribedGameObjects;

    // The progress checks of a scene and whether they are completed or not.
    Dictionary<string, bool> progressCheck = new Dictionary<string, bool>();
    // The number progress checks completed.
    int numberCompleted = 0;
    // Indicates whether every progress check is completed or not.
    bool isComplete = false;
    public bool IsComplete { get { return isComplete; } }
    ProgressionSubscribed[] subscribed;

    // Class Constructor: adds a progress check for each name passed.
    // Parameters:
    //      string[] toCopy = the names to use as keys for progress checks
    //
    void Awake()
    {
        string[] enumsAsStrings = System.Enum.GetNames(typeof(ProgressionMarks));

        for (int i = 0; i < enumsAsStrings.Length; i++)
        {
            progressCheck.Add(enumsAsStrings[i], false);
        }

        subscribed = new ProgressionSubscribed[subscribedGameObjects.Length];

        for (int i = 0; i < subscribedGameObjects.Length; i++)
        {
            subscribed[i] = subscribedGameObjects[i].GetComponent<ProgressionSubscribed>();
        }
    }

    // Marks the progress check with the passed name as completed.
    // Parameter:
    //      string name = the name of the progress check to mark
    //
    public void Completed(string name)
    {
        // If the progress check exists, then:
        if (!progressCheck[name])
        {
            // Mark the progress check as completed.
            progressCheck[name] = true;
            // Increment the counter keeping track of progression checks completed.
            numberCompleted++;
            // If the number of progress checks completed is greater than or
            //     equal to the total number of progress checks, then:
            if (numberCompleted >= progressCheck.Count)
            {
                // Mark the scene as completed.
                isComplete = true;
            }

            foreach(ProgressionSubscribed subscriber in subscribed)
            {
                subscriber.ReceiveProgressionUpdate(this);
            }
        }
    }

    // Returns whether the progress check with the passed name is completed or not.
    // Paramters:
    //      string name = the name of the progress check to check
    //
    public bool IsCompleted(string name)
    {
        return progressCheck[name];
    }
}
