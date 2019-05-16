using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 0.5f, 0);
    [SerializeField] string horizontalName;
    [SerializeField] string verticalName;
    [SerializeField] float speed;
    [SerializeField] string mouseXName;
    [SerializeField] float horizontalSensitivity;
    [SerializeField] string mouseYName;
    [SerializeField] float verticalSensitivity = 1;
    // Upper vertical angle limit.
    [SerializeField] float upperVerticalAngleLimit = 0.15f;
    // Lower vertical angle limit.
    [SerializeField] float lowerVerticalAngleLimit = -0.15f;

    [SerializeField] KeyCode interactKey = KeyCode.E;
    [SerializeField] Vector3 interactionBoxHalfs;
    [SerializeField] float interactionBoxTravelDistance;
    [SerializeField] LayerMask interactionlayer;

    [SerializeField] KeyCode elementUseKey = KeyCode.Mouse0;

    Rigidbody playersRigidBody;

    float xDirection = 0;

    // Use this for initialization
    void Start () {
        playersRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMovement();
        UpdateGameObjectRotation();
        CheckForInteraction();

        if (Input.GetKey(elementUseKey))
        {

        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraHolder.transform.position = transform.position + cameraOffset;

        UpdateCameraRotation();
    }

    void UpdateMovement()
    {
        float horizontalValue = Input.GetAxis(horizontalName);
        float verticalValue = Input.GetAxis(verticalName);

        if (horizontalValue != 0 || verticalValue != 0)
        {
            playersRigidBody.AddForce(transform.TransformPoint(new Vector3(horizontalValue * speed * Time.deltaTime, 0, verticalValue * speed * Time.deltaTime)));
        }
    }

    void UpdateGameObjectRotation()
    {
        // Adds the look input to the rotation of the Gameobject.
        Vector3 torque = new Vector3(0, Input.GetAxis(mouseXName) * horizontalSensitivity, 0);

        playersRigidBody.MoveRotation(playersRigidBody.rotation * Quaternion.Euler(torque * Time.deltaTime));
    }

    void UpdateCameraRotation()
    {
        const short ANALOG_TO_DEGREES = 360;

        // Adds the look input to the rotation of the camera.
        xDirection += -Input.GetAxis(mouseYName) * verticalSensitivity * Time.deltaTime;

        // If the absolute value of the x-axis rotation is greater than or equal to 1
        if (Mathf.Abs(xDirection) >= 1)
        {
            // Set the ones place value of the value to 0 to loop the rotation.
            xDirection = xDirection % 1;
        }

        // Limits the rotation in the x-axis to the given lower and upper limits.
        xDirection = Mathf.Clamp(xDirection, lowerVerticalAngleLimit, upperVerticalAngleLimit);

        cameraHolder.transform.eulerAngles = new Vector3(xDirection * ANALOG_TO_DEGREES, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void CheckForInteraction()
    {
        if (Input.GetKeyDown(interactKey))
        {
            RaycastHit foundInteractable;
            Physics.BoxCast(cameraHolder.transform.position, interactionBoxHalfs, cameraHolder.transform.TransformDirection(Vector3.forward), out foundInteractable, Quaternion.Euler(Vector3.forward), interactionBoxTravelDistance, interactionlayer.value);

            if (foundInteractable.transform != null)
            {
                foundInteractable.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}
