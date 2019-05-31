using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidGameInfo : ProgressAffector, ProgressionUser
{
    [SerializeField] GameObject infoUIToOpen;
    [SerializeField] GameObject[] objectsToTurnOffThenOn;
    [SerializeField] ProgressionMarks markToLookAt;

    bool wasTriggered = false;

	// Update is called once per frame
	void Update () {
        // If this wasn't triggered AND the mark to look at is marked, then:
        if (!wasTriggered && dontDestroyRefs.ProgressionSystemInstance.IsCompleted(markToLookAt.ToString()))
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
}
