using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidGameInfo : ProgressAffector, ProgressionUser
{
    [SerializeField] GameObject infoUIToOpen;
    [SerializeField] GameObject[] objectsToTurnOffThenOn;
    [SerializeField] ProgressionMarks[] marksToLookAt;

    bool wasTriggered = false;

	// Update is called once per frame
	void Update () {
        // If this wasn't triggered AND the marks to look at are marked, then:
        if (!wasTriggered && CheckTheMarks())
        {
            infoUIToOpen.SetActive(true);

            foreach (GameObject thing in objectsToTurnOffThenOn)
            {
                thing.SetActive(false);
            }

            wasTriggered = true;
        }
        // Else if this was triggered AND there was key input, then:
        else if (wasTriggered && Input.anyKeyDown)
        {
            infoUIToOpen.SetActive(false);

            foreach (GameObject thing in objectsToTurnOffThenOn)
            {
                thing.SetActive(true);
            }

            enabled = false;
        }
    }

    bool CheckTheMarks()
    {
        bool areAllMarked = true;

        for (int i = 0; i < marksToLookAt.Length; i++)
        {
            if (!dontDestroyRefs.ProgressionSystemInstance.IsCompleted(marksToLookAt[i].ToString()))
            {
                areAllMarked = false;
                break;
            }
        }

        return areAllMarked;
    }
}
