using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MARK: - Class
public class RightClickListener : MonoBehaviour {
	// MARK: Properites
	[SerializeField] GameObject selectionWheel;

	bool isRightClicking = false;

	// MARK: Life Cycle
	void Start () {

	}

	void Update () {
   		if(Input.GetMouseButtonDown(1)) isRightClicking = true;
   		if(Input.GetMouseButtonUp(1)) isRightClicking = false;

   		if (isRightClicking) {
			// Show selection wheel
        	selectionWheel.SetActive(true);
		} else {
			// Hide selection wheel
        	selectionWheel.SetActive(false);
		}
	}
}
