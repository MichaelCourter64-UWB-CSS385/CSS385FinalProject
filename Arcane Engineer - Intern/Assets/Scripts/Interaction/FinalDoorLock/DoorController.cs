using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationRange;

    public bool isOpen = false;

	// Use this for initialization
	void Start () {
        //unlocked = false;
        //rotationRange = 90.0f;
	}
	
    public void Open()
    {
        isOpen = true;
        //this.transform.Rotate(0, 90, 0, Space.Self);
        StartCoroutine(SwingOpen(false));
    }

    public void Close()
    {
        isOpen = false;
        //this.transform.Rotate(0, -90, 0, Space.Self);
        StartCoroutine(SwingOpen(false));
    }

    IEnumerator SwingOpen(bool toOpen)
    {
        float currentRotated = 0;
        int directionModifier = toOpen ? -1 : 1;

        while (currentRotated < rotationRange)
        {
            yield return new WaitForFixedUpdate();

            this.transform.eulerAngles += new Vector3(0, rotationSpeed * directionModifier, 0);
            currentRotated += rotationSpeed;
        }
    }
}
