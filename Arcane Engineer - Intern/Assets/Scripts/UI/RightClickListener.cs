using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MARK: - Class
public class RightClickListener : MonoBehaviour {
	// MARK: Properites
	[SerializeField] GameObject selectionWheel;

	public bool isRightClicking = false;

	// MARK: Life Cycle
	void Update () {
   		if(Input.GetMouseButtonDown(1)) isRightClicking = true;
   		if(Input.GetMouseButtonUp(1)) isRightClicking = false;

   		if (isRightClicking) {
			// Show selection wheel
        	selectionWheel.SetActive(true);
        	Cursor.visible = true;
		} else {
			// Hide selection wheel
        	selectionWheel.SetActive(false);
        	Cursor.visible = false;
		}
	}
}
