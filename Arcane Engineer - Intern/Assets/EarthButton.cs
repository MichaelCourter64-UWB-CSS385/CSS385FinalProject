using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthButton : KeyDownInteractable {
	[SerializeField] GameObject blockToRotate;
	[SerializeField] int buttonId;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void ForInteract() {
		switch (buttonId) {
		case 0:
			blockToRotate.transform.eulerAngles += new Vector3(0, 90, 0);
			break;
		case 1:
			blockToRotate.transform.eulerAngles += new Vector3(90, 0, 0);
			break;
		case 2:
			blockToRotate.transform.eulerAngles += new Vector3(0, 0, 90);
			break;
		case 3:
			print("submit");
			break;
		default:
			break;
		}


    }
}
