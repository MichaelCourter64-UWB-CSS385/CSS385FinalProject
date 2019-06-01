using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatingProgressionChecker : ProgressChecker
{
    [SerializeField] ProgressionMarks markToLookAt;

    protected override void ReceiveProgressionUpdate()
    {
        if (dontDestroyRefs.ProgressionSystemInstance.IsCompleted(markToLookAt.ToString()))
        {
            gameObject.SetActive(false);
        }
    }
}
