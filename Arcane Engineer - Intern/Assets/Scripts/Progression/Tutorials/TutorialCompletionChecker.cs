using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCompletionChecker : ProgressChecker, ProgressionUser
{
    [SerializeField] ProgressionMarks[] marksToMeet;
    [SerializeField] protected ProgressionMarks markToMarkWhenPreReqsMet;

    protected override void ReceiveProgressionUpdate()
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

            ProgressionSystem.ProgressionMarkMarked.RemoveListener(ReceiveProgressionUpdate);
        }
    }
}
