using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MARK: - Class
public class RightClickListener : MonoBehaviour {
	// MARK: Properites
	Image backgroundImage;
	GameObject selectionWheel;

	bool isRightClicking = false;

	// MARK: Life Cycle
	void Start () {
		if (GameObject.FindGameObjectWithTag ("BackgroundPanel")) { backgroundImage = GameObject.FindGameObjectWithTag("BackgroundPanel").GetComponent<Image>(); }
		if (GameObject.FindGameObjectWithTag ("SelectionWheel")) { selectionWheel = GameObject.FindGameObjectWithTag("SelectionWheel"); }
	}

	void Update () {
   		if(Input.GetMouseButtonDown(1)) isRightClicking = true;
   		if(Input.GetMouseButtonUp(1)) isRightClicking = false;

   		if (isRightClicking) {
			// Show selection wheel
			Color c = backgroundImage.color;
        	c.a = 0.75f;
        	backgroundImage.color = c;
        	selectionWheel.SetActive(true);
		} else {
			// Hide selection wheel
			Color c = backgroundImage.color;
        	c.a = 0f;
        	backgroundImage.color = c;
        	selectionWheel.SetActive(false);
		}
	}
}
