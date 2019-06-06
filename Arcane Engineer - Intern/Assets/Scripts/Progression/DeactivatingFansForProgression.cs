using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatingFansForProgression : ProgressChecker
{
    [SerializeField] ProgressionMarks markToLookAt;

    protected override void ReceiveProgressionUpdate()
    {
        if (dontDestroyRefs.ProgressionSystemInstance.IsCompleted(markToLookAt.ToString()))
        {
            gameObject.GetComponent<FanController>().enabled = false;
        }
    }
}
