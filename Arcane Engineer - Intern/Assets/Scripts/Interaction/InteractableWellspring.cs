using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWellspring : Interactable, ProgressionSubscribed {
    [SerializeField] ProgressionMarks markToLookAt;
    [SerializeField] Elements elementToRestore;
    [SerializeField] GameObject meterManagerHolder;

    MeterManager meterManager;

    void Start()
    {
        meterManager = meterManagerHolder.GetComponent<MeterManager>();
    }

    public void ReceiveProgressionUpdate(ProgressionSystem theProgressionSystem)
    {
        // If the given progression mark is marked as completed, then:
        if (theProgressionSystem.IsCompleted(markToLookAt.ToString()))
        {
            gameObject.SetActive(true);
        }
    }

    public override void Interact()
    {
        meterManager.RestoreElement(elementToRestore);
        // Do something like partical effects.
    }
}
