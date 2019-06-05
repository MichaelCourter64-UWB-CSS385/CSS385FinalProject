using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : WindMachine {

    RaycastHit hit;
    GameObject currentHit = null;
    GameObject lastHit = null;

    [SerializeField] bool isActivated = false;
    [SerializeField] bool hasPower = false;

    [SerializeField] GameObject windBeam;
    [SerializeField] GameObject fanSupportChassis;

    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationMin;
    [SerializeField] float rotationMax;

    [SerializeField] float heightAdjustSpeed;
    [SerializeField] float heightMin;
    [SerializeField] float heightMax;

    Animator fanAnimator;

    //Old Version
    float rotationRange = 30;

    void Awake()
    {
        windBeam.GetComponent<MeshRenderer>().enabled = false;
        fanAnimator = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        // If the fan is running, perform raycast logic for windcurrent
        if (isActivated)
        {
            // Probably a more efficient way to do this only once when it is moved, butfor now this works.
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
                currentHit = hit.collider.gameObject;
                if (hit.distance != 0 && hit.distance != Mathf.Infinity)
                    windBeam.transform.localScale = new Vector3(1, hit.distance, 1); 

                // Check to see if fan is currently hitting a turbine, and if so, 
                // check if the turbine is running, and if it is not, activate it.
                if (currentHit.GetComponent<TurbineController>() != null)
                {
                    if (currentHit.GetComponent<TurbineController>().CheckIfRunning() == false)
                        currentHit.GetComponent<TurbineController>().Activate();
                }

                // Set lastHit if this is the first time (it is null)
                if (lastHit == null) 
                    lastHit = hit.collider.gameObject;

                // If fan has changed direction and new object is being hit,
                // check to see if previous object was a turbine, and if so,
                // deactivate it since wind is no longer hitting it.
                if (lastHit != currentHit)
                {
                    if (lastHit.GetComponent<TurbineController>() != null)
                        lastHit.GetComponent<TurbineController>().Deactivate();
                    lastHit = currentHit;
                }
            }
        }
	}

    public override void Activate()
    {
        if (hasPower && !isActivated)
        {
            isActivated = true;
            windBeam.GetComponent<MeshRenderer>().enabled = true;
            fanAnimator.SetBool("isOn", true);
        }
    }

    public override void Deactivate()
    {
        if (currentHit != null)
        {
            if (currentHit.GetComponent<TurbineController>() != null)
            {
                currentHit.GetComponent<TurbineController>().Deactivate();
            }
        }
        fanAnimator.SetBool("isOn", false);
        isActivated = false;
    }

    // GetActivatedState()
    // returns the current state of this object (true for active, false for inactive)
    public bool GetActivatedState()
    {
        return isActivated;
    }

    // SetPowerState()
    // Public method for telling this object whether it has power.
    // bool on is passed as true if power is being supplied and false if not.
    public void SetPowerState(bool on)
    {
        hasPower = on;
    }

    // Rotate()
    // Public method used by the control panel to change the direction of the fan.
    // bool clockwise is true for clockwise, false for counterclockwise.
    public void newRotate(bool clockwise)
    {
        float currentRotated = fanSupportChassis.transform.eulerAngles.y;
        int directionModifier = clockwise ? 1 : -1;
        float adjust = rotationSpeed * directionModifier;
        if ((currentRotated + adjust) <= rotationMax && (currentRotated + adjust) >= rotationMin)
        {
            fanSupportChassis.transform.eulerAngles += new Vector3(0, adjust, 0);
        }
    }

    public void MoveVertical(bool up)
    {
        float currentHeight = fanSupportChassis.transform.position.y;
        int directionModifier = up ? 1 : -1;
        float adjust = heightAdjustSpeed * directionModifier;
        if ((currentHeight + adjust) <= heightMax && (currentHeight + adjust) >= heightMin)
        {
            fanSupportChassis.transform.position += new Vector3(0, adjust, 0);
        }

        // Old Version
        //StartCoroutine(RotateFan(clockwise));
    }


    // Old Versions

    public void Rotate(bool clockwise)
    {
        StartCoroutine(RotateFan(clockwise));
    }


    public void SetFanHeight(float newHeight)
    {
        Debug.Log("In SetFanHeight");
        StartCoroutine(AdjustFanHeight(newHeight));
    }

   IEnumerator RotateFan(bool direction)
    {
        float currentRotated = 0;
        int directionModifier = direction ? 1 : -1;

        while (currentRotated < rotationRange)
        {
            yield return new WaitForFixedUpdate();
            fanSupportChassis.transform.eulerAngles += new Vector3(0, rotationSpeed * directionModifier, 0);
            currentRotated += rotationSpeed;
        }
    }

    IEnumerator AdjustFanHeight(float targetHeight)
    {
        Debug.Log("In AdjustFanHeight");
        float currentHeight = fanSupportChassis.transform.position.y;
        int directionModifier = (currentHeight < targetHeight) ? -1 : 1;
        Vector3 pos = fanSupportChassis.transform.position;
        while (currentHeight != targetHeight)
        {
            yield return new WaitForFixedUpdate();
            pos.y += (heightAdjustSpeed * directionModifier);
            fanSupportChassis.transform.position = pos;
            Debug.Log("In AdjustFanHeight");
        }
    }
}
