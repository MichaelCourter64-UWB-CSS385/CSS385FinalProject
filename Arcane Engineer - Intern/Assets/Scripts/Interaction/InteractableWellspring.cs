using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWellspring : Interactable, ProgressionUser
{
    [SerializeField] GameObject wellToTurnOn;
    [SerializeField] GameObject linkToDontDestroyHolder;
    [SerializeField] ProgressionMarks markToLookAt;
    [SerializeField] Elements elementToRestore;
    [SerializeField] GameObject meterManagerHolder;

    MeterManager meterManager;

    DontDestroyReferenceHolder dontDestroyRefs;

    void Awake()
    {
        ProgressionSystem.ProgressionMarkMarked.AddListener(ReceiveProgressionUpdate);

        meterManager = meterManagerHolder.GetComponent<MeterManager>();
    }

    void Start()
    {
        dontDestroyRefs = linkToDontDestroyHolder.GetComponent<LinkToDontDestroy>().DontDestroyReferences;
    }

    void OnDestroy()
    {
        ProgressionSystem.ProgressionMarkMarked.RemoveListener(ReceiveProgressionUpdate);
    }

    public void ReceiveProgressionUpdate()
    {
        // If the given progression mark is marked as completed, then:
        if (dontDestroyRefs.ProgressionSystemInstance.IsCompleted(markToLookAt.ToString()))
        {
            wellToTurnOn.gameObject.SetActive(true);
        }
    }

    protected override void ForInteract()
    {
        meterManager.RestoreElement(elementToRestore);
        // Do something like partical effects.
    }
}
