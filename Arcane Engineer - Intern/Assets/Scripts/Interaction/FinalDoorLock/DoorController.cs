using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationRange;

    private bool unlocked;

	// Use this for initialization
	void Awake () {
        unlocked = false;
        rotationRange = 90.0f;
	}
	
    public void Open()
    {
        unlocked = true;
        this.transform.Rotate(0, 90, 0, Space.Self);
        //StartCoroutine(swingOpen());
    }

    private IEnumerator swingOpen()
    {
        Quaternion current = this.transform.rotation;
        current.y += rotationSpeed;
        this.transform.rotation = current;
        yield return new WaitForEndOfFrame();
    }
}
