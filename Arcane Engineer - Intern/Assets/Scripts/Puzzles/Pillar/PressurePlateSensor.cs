using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MARK: - Class
public class PressurePlateSensor : MonoBehaviour {
	// MARK: Properties
	[SerializeField] GameObject eastPillar;
	[SerializeField] GameObject westPillar;
	[SerializeField] GameObject eastConnectionPiece;
	[SerializeField] GameObject westConnectionPiece;
	[SerializeField] GameObject earthWellspring;
	[SerializeField] Material pressedMaterial;
	[SerializeField] Material liftedMaterial;

	bool shouldSlideTogether = false;
	bool canMove = false;

	private Vector3 eastStartingPosition;
	private Vector3 westStartingPosition;
	private Vector3 centerPosition = new Vector3(0, 4.3f, 0);
	// private Vector3 correctRotation = new Vector3(0, 180, 270);

	// MARK: Life Cycle
	void Start () {
		eastStartingPosition = eastPillar.transform.position;
		westStartingPosition = westPillar.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove) { return; }

		if (shouldSlideTogether) {
			// Slide pillars together
			eastPillar.transform.position = Vector3.MoveTowards(eastPillar.transform.position, centerPosition, 2f * Time.deltaTime);
			westPillar.transform.position = Vector3.MoveTowards(westPillar.transform.position, centerPosition, 2f * Time.deltaTime);

			assertValidConnection();
		} else {
			// Slide pillars to origins
			eastPillar.transform.position = Vector3.MoveTowards(eastPillar.transform.position, eastStartingPosition, 2f * Time.deltaTime);
			westPillar.transform.position = Vector3.MoveTowards(westPillar.transform.position, westStartingPosition, 2f * Time.deltaTime);
		}
	}

	private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
			// Assign Material
			GetComponent<Renderer>().material = pressedMaterial;

            shouldSlideTogether = true;
            canMove = true;
        }
    }

     private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
			// Assign Material
			GetComponent<Renderer>().material = liftedMaterial;

            shouldSlideTogether = false;
        }
    }

    // MARK: Private
	private void assertValidConnection() {
		// Assert connection
		bool hasEastArrived = (Vector3.Distance(eastPillar.transform.position, centerPosition) < 0.001f);
		bool hasWestArrived = (Vector3.Distance(westPillar.transform.position, centerPosition) < 0.001f);
		if (hasEastArrived && hasWestArrived) {
			Vector3 actualWestRotation = westConnectionPiece.transform.rotation.eulerAngles;
			Vector3 actualEastRotation = eastConnectionPiece.transform.rotation.eulerAngles;

			Vector3 expectedEastRotation = actualWestRotation += new Vector3(0, -90, 180);

			//Debug.Log("actual  east rotation: " + actualEastRotation);
			//Debug.Log("expected east rotation: " + expectedEastRotation);

			// Check if rotation is correct
			if (actualEastRotation == expectedEastRotation) {
				canMove = false;
				earthWellspring.SetActive(true);
			}
		}
	}
}
