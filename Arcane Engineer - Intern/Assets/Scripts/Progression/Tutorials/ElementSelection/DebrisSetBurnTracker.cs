using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSetBurnTracker : ProgressAffector
{
    [SerializeField] GameObject[] debris;
    [SerializeField] ProgressionMarks markToMarkWhenPreReqsMet;

    // Update is called once per frame
    void Update()
    {
        bool isCleared = true;

        for (int i = 0; isCleared && i < debris.Length; i++)
        {
            if (debris[i].activeSelf)
            {
                isCleared = false;
                break;
            }
        }

        if (isCleared)
        {
            dontDestroyRefs.ProgressionSystemInstance.Completed(markToMarkWhenPreReqsMet.ToString());

            enabled = false;
        }
    }
}
