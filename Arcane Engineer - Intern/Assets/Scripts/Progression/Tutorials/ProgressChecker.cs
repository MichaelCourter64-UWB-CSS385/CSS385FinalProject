using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProgressChecker : ProgressAffector
{
    // Use this for initialization
    void Awake()
    {
        ProgressionSystem.ProgressionMarkMarked.AddListener(ReceiveProgressionUpdate);

        ForAwake();
    }

    protected virtual void ForAwake() { }

    void OnDestroy()
    {
        ProgressionSystem.ProgressionMarkMarked.RemoveListener(ReceiveProgressionUpdate);
    }

    protected abstract void ReceiveProgressionUpdate();
}
