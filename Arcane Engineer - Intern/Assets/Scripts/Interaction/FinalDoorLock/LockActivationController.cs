using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockActivationController : KeyDownInteractable {
    [Header("Activation Settings")]
    [SerializeField] float timeoutDuration;

    [Header("Lock Objects")]
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject[] executionOrder1 = new GameObject[5];
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject[] executionOrder2 = new GameObject[5];
    // Note: In order to work correctly, objects in the execution order arrays should be indexed
    // in the order of their sequence starting with the object following the powerbox.
    // i.e. executionOrder1[0] = lightPanelA
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject leftTarget;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject righttTarget;
    [SerializeField] GameObject door;

    public bool hasPower;
    bool inTimeout;
    bool isCheckingLock;
    bool isCorrect;

    float timeoutTimer;

    // Use this for initialization
    void Awake() {
        hasPower = false;
        inTimeout = false;
        isCheckingLock = false;
        isCorrect = false;
        // Debug.Log("In Lock Activation - Start");
    }
	
    protected override void ForInteract()
    {
        //Debug.Log("In Lock Activation - ForInteract");
        //timeoutTimer = Time.time + timeoutDuration;
        //inTimeout = true;
        isCheckingLock = !isCheckingLock;
        if (isCheckingLock == true)
        {
            Activate();
            // Debug.Log("In Lock Activation - interact - activate");
        }
        else
        {
            Deactivate();
            // Debug.Log("In Lock Activation - interact - dectivate");
        }
            
    }

    void Activate()
    {
        foreach(GameObject go in executionOrder1)
        {
            // Ugly, but seemingly the only way to get unity to allow this
            if (go.GetComponent<LightPanelController>() != null)
            {
                go.GetComponent<LightPanelController>().Activate();
                // Debug.Log("In Lock Activation - Activate() - ExecutionOrder1 - LightPanelController");
            }
            if (go.GetComponent<DialController>() != null)
            {
                go.GetComponent<DialController>().Activate();
                // Debug.Log("In Lock Activation - Activate() - ExecutionOrder1 - DialController");
            }

        }
        foreach (GameObject go in executionOrder2)
        {
            // Ugly, but seemingly the only way to get unity to allow this
            if (go.GetComponent<LightPanelController>() != null)
            {
                go.GetComponent<LightPanelController>().Activate();
                // Debug.Log("In Lock Activation - Activate() - ExecutionOrder2 - LightPanelController");
            }
            if (go.GetComponent<DialController>() != null)
            {
                go.GetComponent<DialController>().Activate();
                // Debug.Log("In Lock Activation - Activate() - ExecutionOrder2 - DialController");
            }
        }
        if (validateLockCombo())
        {
            door.GetComponent<DoorController>().Open();
        }

    }

    void Deactivate()
    {
        for (int i = 1; i < executionOrder1.Length; i++)
        {
            // Ugly, but seemingly the only way to get unity to allow this
            if (executionOrder1[i].GetComponent<LightPanelController>() != null)
                executionOrder1[i].GetComponent<LightPanelController>().Deactivate();
            if (executionOrder1[i].GetComponent<DialController>() != null)
                executionOrder1[i].GetComponent<DialController>().Deactivate();
            if (executionOrder2[i].GetComponent<LightPanelController>() != null)
                executionOrder2[i].GetComponent<LightPanelController>().Deactivate();
            if (executionOrder2[i].GetComponent<DialController>() != null)
                executionOrder2[i].GetComponent<DialController>().Deactivate();
        }
    }


    public bool validateLockCombo()
    {
        if (leftTarget.GetComponent<LightPanelController>() != null
            && righttTarget.GetComponent<LightPanelController>() != null
            && executionOrder1[executionOrder1.Length - 1].GetComponent<LightPanelController>() != null
            && executionOrder2[executionOrder2.Length - 1].GetComponent<LightPanelController>() != null)
        {
            int[] lefttargetvals = leftTarget.GetComponent<LightPanelController>().PassValues();
            // Debug.Log("In Lock Activation - ValidateLockCombo() - lefttargetvals: ");
            foreach (int i in lefttargetvals)
            {
                // Debug.Log(i);
            }

            int[] leftresultvals = executionOrder2[executionOrder2.Length - 1].GetComponent<LightPanelController>().PassValues();
            // Debug.Log("In Lock Activation - ValidateLockCombo() - leftresultvals: ");
            foreach (int i in leftresultvals)
            {
                // Debug.Log(i);
            }

            int[] righttargetvals = righttTarget.GetComponent<LightPanelController>().PassValues();
            // Debug.Log("In Lock Activation - ValidateLockCombo() - righttargetvals: ");
            foreach (int i in righttargetvals)
            {
                // Debug.Log(i);
            }

            int[] rightresultvals = executionOrder1[executionOrder1.Length - 1].GetComponent<LightPanelController>().PassValues();
            // Debug.Log("In Lock Activation - ValidateLockCombo() - rightresultvals: ");
            foreach (int i in rightresultvals)
            {
                // Debug.Log(i);
            }

            for (int i = 0; i < leftresultvals.Length; i++)
            {
                if (lefttargetvals[i] != leftresultvals[i] || righttargetvals[i] != rightresultvals[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}
