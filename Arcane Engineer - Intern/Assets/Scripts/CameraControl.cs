using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    [SerializeField] GameObject playerCharacterHolder;
    [SerializeField] Vector3 cameraOffset;
    // Serial vert and hori sensitivity
    [SerializeField] float horizontalSensitivity;
    [SerializeField] float verticalSensitivity;
    // Upper vertical angle limit.
    [SerializeField] float upperVerticalAngleLimit;
    // Lower vertical angle limit.
    [SerializeField] float lowerVerticalAngleLimit;

    float xDirection = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = playerCharacterHolder.transform.position + cameraOffset;

        UpdateRotation();
    }

    void UpdateRotation()
    {
        const short ANALOG_TO_DEGREES = 360;

        // Adds the look input to the rotation of the camera.
        xDirection += -Input.GetAxis("Mouse Y") * verticalSensitivity * Time.deltaTime;

        // If the absolute value of the x-axis rotation is greater than or equal to 1
        if (Mathf.Abs(xDirection) >= 1)
        {
            // Set the ones place value of the value to 0 to loop the rotation.
            xDirection = xDirection % 1;
        }

        // Limits the rotation in the x-axis to the given lower and upper limits.
        xDirection = Mathf.Clamp(xDirection, lowerVerticalAngleLimit, upperVerticalAngleLimit);

        transform.eulerAngles = new Vector3(xDirection * ANALOG_TO_DEGREES, playerCharacterHolder.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
