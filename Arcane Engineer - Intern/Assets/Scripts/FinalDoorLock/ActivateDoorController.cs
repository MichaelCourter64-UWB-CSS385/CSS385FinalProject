using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockActivationController : Interactable {
    [Header("Activation Settings")]
    [SerializeField] float timeoutDuration;

    [Header("Lock Objects")]
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject startPoint1;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject startPoint2;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject dial1;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject dial2;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject midPoint1;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject midPoint2;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject endPoint1;
    [Tooltip("WARNING: Altering these object references is highly likely to break lock functionality!")]
    [SerializeField] GameObject endPoint2;

    [SerializeField] GameObject[] executionOrder1 = new GameObject[5];
    [SerializeField] GameObject[] executionOrder2 = new GameObject[5];

    bool hasPower;
    bool inTimeout;
    bool isOn;
    bool isCorrect;

    float timeoutTimer;

    // Use this for initialization
    void Start() {
        hasPower = false;
        inTimeout = false;
        isOn = false;
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
        isOn = !isOn;
        // StartCoroutine(CheckLock());
    }

    //IEnumerator CheckLock()
    //{
    //    while (Time.time < timeoutTimer)
    //    {

    //    }
    //}

}
