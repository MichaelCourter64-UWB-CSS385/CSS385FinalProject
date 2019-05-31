using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterFillChecker : ProgressAffector, ProgressionUser
{
    [SerializeField] GameObject meterManagerHolder;
    [SerializeField] Elements elementToWatch;
    [SerializeField] float valueToReach;

    [SerializeField] ProgressionMarks markToMarkWhenPreReqsMet;

    MeterManager meterManager;
    bool wasTriggered = false;

    void Awake()
    {
        meterManager = meterManagerHolder.GetComponent<MeterManager>();
    }

    void Update()
    {
        if (!wasTriggered && meterManager.GetElementLevel(elementToWatch) >= valueToReach)
        {
            dontDestroyRefs.ProgressionSystemInstance.Completed(markToMarkWhenPreReqsMet.ToString());

            wasTriggered = true;
        }
    }
}
