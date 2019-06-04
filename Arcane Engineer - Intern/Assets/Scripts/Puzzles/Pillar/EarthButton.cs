using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthButton : PauseForInteractable {
	[SerializeField] GameObject blockToRotate;
	[SerializeField] int buttonId;

	// Update is called once per frame
	void Update () {

	}

	protected override void ForPauseInteract() {
		switch (buttonId) {
		case 0:
			blockToRotate.transform.Rotate(new Vector3(0, 90f, 0));
			break;
		case 1:
			blockToRotate.transform.Rotate(new Vector3(0, 0, 90f));
			break;
		default:
			break;
		}
    }
}
