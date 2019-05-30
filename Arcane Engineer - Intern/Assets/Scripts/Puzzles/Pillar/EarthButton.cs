using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthButton : PauseForInteractable {
	[SerializeField] GameObject blockToRotate;
	[SerializeField] GameObject pillarToLift;
	[SerializeField] int buttonId;

	private bool canLift = false;
	private bool canLower = false;
	private Vector3 correctRotation = new Vector3(90, 0, 0);

	// Update is called once per frame
	void Update () {
		bool canLiftMore = blockToRotate.transform.position.y <= 10.75f;
		bool canLowerMore =	blockToRotate.transform.position.y >= 1.25f;
		bool usesCorrectRotation = (blockToRotate.transform.eulerAngles == correctRotation);

		if (canLift && canLiftMore && !canLower) {
			pillarToLift.transform.position += Vector3.up * Time.deltaTime;
		} else if (!canLiftMore && usesCorrectRotation) {
			// Unlock wellspring
			canLift = false;
			return;
		} else if (!canLiftMore && !canLower) {
			canLower = true;
		} else if (canLowerMore && canLower) {
			// Lower the pillar back to the starting state
			pillarToLift.transform.position -= Vector3.up * Time.deltaTime;
		} else if (!canLowerMore) {
			canLower = false;
			canLift = false;
		}
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
			canLift = true;
			break;
		default:
			break;
		}


    }
}
