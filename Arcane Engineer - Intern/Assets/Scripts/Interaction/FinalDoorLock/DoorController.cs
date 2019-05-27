using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationRange;

    private bool unlocked;
    private bool isOpen;

	// Use this for initialization
	void Start () {
        //unlocked = false;
        //rotationRange = 90.0f;
	}
	
    public void Open()
    {
        unlocked = true;
        //this.transform.Rotate(0, 90, 0, Space.Self);
        isOpen = true;
        StartCoroutine(SwingOpen(true));
    }

    public void Close()
    {
        unlocked = false;
        //this.transform.Rotate(0, -90, 0, Space.Self);
        isOpen = false;
        StartCoroutine(SwingOpen(false));
    }

    IEnumerator SwingOpen(bool toOpen)
    {
        //float angleToReach = Mathf.Abs(onAngle - offAngle);
        float currentRotated = 0;
        int directionModifier = toOpen ? -1 : 1;

        while (currentRotated < rotationRange)
        {
            yield return new WaitForFixedUpdate();

            this.transform.eulerAngles += new Vector3(0, rotationSpeed * directionModifier, 0);
            currentRotated += rotationSpeed;
        }
    }

    private IEnumerator SwingShut()
    {
        Quaternion current = this.transform.rotation;
        current.y += rotationSpeed;
        this.transform.rotation = current;
        yield return new WaitForEndOfFrame();
    }
}
