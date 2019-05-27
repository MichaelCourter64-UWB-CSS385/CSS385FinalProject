using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] float cameraCrouchOffset;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 0.5f, 0);
    [SerializeField] string horizontalName;
    [SerializeField] string verticalName;

    [SerializeField] KeyCode crouchKey;
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
    [SerializeField] float interactionBoxTravelDistance;
    [SerializeField] LayerMask interactionlayer;
    [SerializeField] GameObject interactionIndicatorUIHolder;
    [SerializeField] GameObject interactionIndicatorToolTipHolder;
    [SerializeField] float indicatorBaseSize;
    [SerializeField] float indicatorFoundInteractSize;

	// Element casting.
    [SerializeField] KeyCode elementUseKey = KeyCode.Mouse0;
    [SerializeField] GameObject elementManagerHolder;
    [SerializeField] GameObject waterStream;
    [SerializeField] GameObject earthStream;
    [SerializeField] GameObject fireStream;
    [SerializeField] GameObject airStream;

    bool isCrouching = false;

    Rigidbody playersRigidBody;

    Image interactionIndicatorUI;
    Text interactionIndicatorToolTip;

    float xDirection = 0;

	// Pull this from the select code
	ElementManager elementManager;
    Elements currentElement;

    // Use this for initialization
    void Start () {
        playersRigidBody = GetComponent<Rigidbody>();
        interactionIndicatorUI = interactionIndicatorUIHolder.GetComponent<Image>();
        interactionIndicatorToolTip = interactionIndicatorToolTipHolder.GetComponent<Text>();
		elementManager = elementManagerHolder.GetComponent<ElementManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		// Check if we're selecting an element
		RightClickListener rightClickListener = GameObject.FindGameObjectWithTag("RightClickListener").GetComponent<RightClickListener>();
		if (rightClickListener.isRightClicking) {
			return;
		}

        UpdateMovement();
        UpdateGameObjectRotation();
        CheckForInteraction();
        CheckForElementUse();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isCrouching)
        {
            cameraHolder.transform.position = transform.position + cameraOffset + new Vector3(0, cameraCrouchOffset, 0);
        }
        else
        {
            cameraHolder.transform.position = transform.position + cameraOffset;
        }
        

        UpdateCameraRotation();
    }

    void UpdateMovement()
    {
        float horizontalValue = Input.GetAxis(horizontalName);
        float verticalValue = Input.GetAxis(verticalName);

        if (Input.GetKeyDown(crouchKey))
        {
            isCrouching = !isCrouching;
        }

        if (horizontalValue != 0 || verticalValue != 0)
        {
            playersRigidBody.AddForce(transform.TransformDirection(new Vector3(horizontalValue * speed * Time.deltaTime, 0, verticalValue * speed * Time.deltaTime)));
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
		// Check if we're selecting an element
		RightClickListener rightClickListener = GameObject.FindGameObjectWithTag("RightClickListener").GetComponent<RightClickListener>();

		if (rightClickListener.isRightClicking) {
			return;
		}

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
        RaycastHit foundInteractable;
        Physics.Raycast(cameraHolder.transform.position, cameraHolder.transform.TransformDirection(Vector3.forward), out foundInteractable, interactionBoxTravelDistance, interactionlayer.value);

        if(foundInteractable.transform != null)
        {
            //Debug.Log(foundInteractable.transform.name);
            interactionIndicatorUIHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(indicatorFoundInteractSize, indicatorFoundInteractSize);
            interactionIndicatorToolTip.text = foundInteractable.transform.GetComponent<Interactable>().InteractionToolTip;
            interactionIndicatorToolTipHolder.SetActive(true);
        }
        else
        {
            interactionIndicatorUIHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(indicatorBaseSize, indicatorBaseSize);
            interactionIndicatorToolTipHolder.SetActive(false);
        }

        if (Input.GetKey(interactKey))
        {
            
            if (foundInteractable.transform != null)
            {
                foundInteractable.transform.GetComponent<Interactable>().Interact();
            }
        }
    }

    void CheckForElementUse()
    {
        if (Input.GetKey(elementUseKey))
        {
        	currentElement = elementManager.getSelectedElement();
			MeterManager meterManager = GameObject.FindGameObjectWithTag("MeterManager").GetComponent<MeterManager>();

            if (currentElement == Elements.Water)
            {
                waterStream.SetActive(true);

                // Decrease water resource
                meterManager.waterMeter.value -= 0.001f;
            }
            else if (currentElement == Elements.Earth)
            {
				earthStream.SetActive(true);

                // Decrease earth resource
                meterManager.earthMeter.value -= 0.001f;
			}
			else if (currentElement == Elements.Fire)
            {
				fireStream.SetActive(true);

                // Decrease fire resource
                meterManager.fireMeter.value -= 0.001f;
			}
			else if (currentElement == Elements.Air)
            {
				airStream.SetActive(true);

                // Decrease air resource
                meterManager.airMeter.value -= 0.001f;
			}
        }
        else
        {
            waterStream.SetActive(false);
            earthStream.SetActive(false);
            fireStream.SetActive(false);
            airStream.SetActive(false);
        }
    }
}
