using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MARK: - Class
public class ElementManager : MonoBehaviour {
	// MARK: Properties

	Elements selectedElement;

	// MARK: Life Cycle
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// MARK: Private


	// MARK: Public Control Handlers
	// Determine the element and store
	public void PickElement(int elementId) {
		switch (elementId) {
		case 0:
			selectedElement = Elements.Water;
			break;
		case 1:
			selectedElement = Elements.Earth;
			break;
		case 2:
			selectedElement = Elements.Fire;
			break;
		case 3:
			selectedElement = Elements.Air;
			break;
		default:
			Debug.Log("Error: The ElementId of " + elementId + " is not a valid elementId");
			return;
		}

		Debug.Log("You've successfully selected: " + selectedElement);
	}

	// MARK: Public
	public Elements getSelectedElement() {
		return selectedElement;
	}
}
