using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLever : KeyDownInteractable
{
    [SerializeField] GameObject leverRotationPoint;
    [SerializeField] float onAngleDifference;
    [SerializeField] float rotationSpeed;

    float offAngle;
    float onAngle;
    bool isOn = false;

	// Use this for initialization
	void Start () {
        // Assumes that the lever rotates on the x-axis when being turned on/off
        offAngle = leverRotationPoint.transform.eulerAngles.x;
        onAngle = offAngle - onAngleDifference;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Interact();
        }
	}

    protected override void ForInteract()
    {
        StartCoroutine(ShiftLever(!isOn));
        isOn = !isOn;
    }

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
}
