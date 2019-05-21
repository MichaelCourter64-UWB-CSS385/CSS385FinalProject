using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockActivationController : Interactable {
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
    void Start() {
        hasPower = false;
        inTimeout = false;
        isCheckingLock = false;
        isCorrect = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && hasPower && !inTimeout)
        {
            Interact();
        }
    }

    public override void Interact()
    {
        timeoutTimer = Time.time + timeoutDuration;
        inTimeout = true;
        isCheckingLock = !isCheckingLock;
        if (isCheckingLock == true)
            Activate();
        else
            Deactivate();
    }

    void Activate()
    {
        foreach(GameObject go in executionOrder1)
        {
            // Ugly, but seemingly the only way to get unity to allow this
            if (go.GetComponent<LightPanelController>() != null)
                go.GetComponent<LightPanelController>().Activate();
            if (go.GetComponent<DialController>() != null)
                go.GetComponent<DialController>().Activate();
        }
        if (validateLockCombo())
        {
            door.GetComponent<DoorController>().Open();
        }

    }

    void Deactivate()
    {
        foreach (GameObject go in executionOrder1)
        {
            // Ugly, but seemingly the only way to get unity to allow this
            if (go.GetComponent<LightPanelController>() != null)
                go.GetComponent<LightPanelController>().Deactivate();
            if (go.GetComponent<DialController>() != null)
                go.GetComponent<DialController>().Deactivate();
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
            int[] leftresultvals = executionOrder2[executionOrder2.Length - 1].GetComponent<LightPanelController>().PassValues();
            int[] righttargetvals = righttTarget.GetComponent<LightPanelController>().PassValues();
            int[] rightresultvals = executionOrder1[executionOrder1.Length - 1].GetComponent<LightPanelController>().PassValues();
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
