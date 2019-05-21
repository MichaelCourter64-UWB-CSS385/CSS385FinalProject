using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : Interactable {
    // Used for "animation" of wheel rotation
    [SerializeField] float rotationSpeed;
    // Sets direction and angle of rotation in degrees (90 is standard)
    [SerializeField] float rotationModifier;
    // Field indicating which wheel this is (1 is outer-most, 4 is inner-most)
    [SerializeField] int wheelNumber;

    private int currentPosition;
    private float currentAngle;
    private bool inMotion;
    private bool canInteract;

	// Use this for initialization
	void Start () {
		currentAngle = this.transform.rotation.y;   // Axis may need to be readjusted on asset reimport
        inMotion = false;
        canInteract = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && canInteract && !inMotion)
        {
            Interact();
        }
    }

    // Override method for interacting with this wheel object
    public override void Interact()
    {
        if (canInteract)
        {
            // inMotion prevents spamming the interaction
            inMotion = true;
            StartCoroutine(RotateWheel());
            inMotion = false;
            // Update the wheel position in the DialController
            currentPosition = (currentPosition++) % 4;
            this.transform.parent.GetComponent<DialController>().WheelPositions[wheelNumber] = currentPosition;
        }
    }

    // Coroutine for moving the wheel
    IEnumerator RotateWheel()
    {
        float targetAngle = currentAngle + rotationModifier;
        float currentRotation = 0;

        while (currentRotation < targetAngle)
        {
            if (currentRotation + rotationSpeed < targetAngle)
                currentRotation += rotationSpeed;
            else
                currentRotation = targetAngle;
            this.gameObject.transform.Rotate(0, currentRotation, 0, Space.Self);
            yield return new WaitForFixedUpdate(); // Possibly not the way we want this set up.
        }
    }

    public void Activate()
    {
        canInteract = true;
    }

    public void Deactivate()
    {
        canInteract = false;
    }
}
