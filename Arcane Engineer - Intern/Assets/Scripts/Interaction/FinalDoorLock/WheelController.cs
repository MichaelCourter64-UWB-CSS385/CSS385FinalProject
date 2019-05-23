using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : KeyDownInteractable {
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
		currentAngle = this.transform.eulerAngles.y;   // Axis may need to be readjusted on asset reimport
        inMotion = false;
        canInteract = true;
    }
	
    // Override method for interacting with this wheel object
    protected override void ForInteract()
    {
        if (canInteract)
        {
            this.transform.Rotate(0, 90, 0, Space.Self);
            // inMotion prevents spamming the interaction
            //inMotion = true;
            //StartCoroutine(RotateWheel());
            //inMotion = false;
            // Update the wheel position in the DialController
            currentPosition++;
            currentPosition = currentPosition % 4;
            Debug.Log("In WheelController - ForInteract() - currentPosition = " + currentPosition);
            Debug.Log("In WheelController - ForInteract() - parentname = " + this.transform.parent.transform.parent.name);
            this.transform.parent.transform.parent.GetComponent<DialController>().WheelPositions[wheelNumber - 1] = currentPosition;
            //Debug.Log("in interact");
        }
    }

    // Coroutine for moving the wheel
    //IEnumerator RotateWheel()
    //{
        
        //float targetAngle = currentAngle + rotationModifier;
        //float currentRotation = 0;

        //while (currentRotation < targetAngle)
        //{
        //    if (currentRotation + rotationSpeed < targetAngle)
        //        currentRotation += rotationSpeed;
        //    else
        //        currentRotation = targetAngle;
        //    //this.gameObject.transform.Rotate(0, currentRotation, 0, Space.Self);
        //    Debug.Log("in RotateWheel");
        //    //transform.eulerAngles = new Vector3( transform.eulerAngles.x, currentRotation, transform.eulerAngles.z);
        //    transform.Rotate(transform.eulerAngles.x, currentRotation, transform.eulerAngles.z, Space.Self);
        //    yield return new WaitForSeconds(.05f); // Possibly not the way we want this set up.
        //}
    //}

    public void Activate()
    {
        canInteract = true;
    }

    public void Deactivate()
    {
        canInteract = false;
    }
}
