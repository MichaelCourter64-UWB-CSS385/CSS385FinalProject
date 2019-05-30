using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockActivationController : PauseForInteractable
{

    // ----- Added From Interactable Lever -----
    // Had to includes the interactable lever code in this file because
    // there can only be one script on any given game object that extends
    // the interactable abstract class.
    [SerializeField] GameObject leverRotationPoint;
    [SerializeField] float onAngleDifference;
    [SerializeField] float rotationSpeed;

    float offAngle;
    float onAngle;
    bool isOn = false;

    // ----- Variables for Lock Activation Controller -----
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
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
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
        // ----- From Interactable Lever -----
        offAngle = leverRotationPoint.transform.eulerAngles.x;
        onAngle = offAngle - onAngleDifference;
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
        // ----- From Interactable Lever -----
        StartCoroutine(ShiftLever(!isOn));
        isOn = !isOn;
        // ----- End Interactable Lever -----

        foreach (GameObject go in executionOrder1)
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
        // ----- From Interactable Lever -----
        StartCoroutine(ShiftLever(!isOn));
        isOn = !isOn;
        // ----- End Interactable Lever -----

        // If door is already open, shut it
        if (door.GetComponent<DoorController>().isOpen == true)
            door.GetComponent<DoorController>().Close();

        // Deactivate light panels
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

    // ----- From Interactable Lever -----
    IEnumerator ShiftLever(bool toOn)
    {
        float angleToReach = Mathf.Abs(onAngle - offAngle);
        float currentRotated = 0;
        int directionModifier = toOn ? -1 : 1;

        while (currentRotated < angleToReach)
        {
            yield return new WaitForFixedUpdate();

            leverRotationPoint.transform.eulerAngles += new Vector3(rotationSpeed * directionModifier, 0, 0);
            currentRotated += rotationSpeed;
        }
    }
    // ----- End Interactable Lever -----
}
