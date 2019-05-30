using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCompletionChecker : MonoBehaviour
{
    [SerializeField] GameObject linkToDontDestroyHolder;
    [SerializeField] ProgressionMarks[] marksToMeet;
    [SerializeField] ProgressionMarks markToMarkWhenPreReqsMet;

    DontDestroyReferenceHolder dontDestroyRefs;

    // Use this for initialization
    void Awake () {
        ProgressionSystem.ProgressionMarkMarked.AddListener(CheckCompletion);
	}

    void Start()
    {
        dontDestroyRefs = linkToDontDestroyHolder.GetComponent<LinkToDontDestroy>().DontDestroyReferences;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnDestroy()
    {
        ProgressionSystem.ProgressionMarkMarked.RemoveListener(CheckCompletion);
    }

    void CheckCompletion()
    {
        int markedCount = 0;

        for(int i = 0; i < marksToMeet.Length; i++)
        {
            // If the progression mark is marked, then:
            if (dontDestroyRefs.ProgressionSystemInstance.IsCompleted(marksToMeet[i].ToString()))
            {
                markedCount++;
            }
            else
            {
                break;
            }
        }

        // If all the progression marks are marked, then:
        if (markedCount == marksToMeet.Length)
        {
            dontDestroyRefs.ProgressionSystemInstance.Completed(markToMarkWhenPreReqsMet.ToString());

            ProgressionSystem.ProgressionMarkMarked.RemoveListener(CheckCompletion);
        }
    }
}
