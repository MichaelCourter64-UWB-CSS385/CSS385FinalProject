using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MARK: Enum
public enum Element { Water, Earth, Fire, Air }

// MARK: - Class
public class ButtonHandler : MonoBehaviour {
	// MARK: Properties
	Element selectedElement;

	// MARK: Life Cycle
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// MARK: Private


	// MARK: Public Control Handlers
	// Determine the element and store
	public void pickElement(int elementId) {
		switch (elementId) {
		case 0:
			selectedElement = Element.Water;
			break;
		case 1:
			selectedElement = Element.Earth;
			break;
		case 2:
			selectedElement = Element.Fire;
			break;
		case 3:
			selectedElement = Element.Air;
			break;
		default:
			Debug.Log("Error: The ElementId of " + elementId + " is not a valid elementId");
			return;
		}

		Debug.Log("You've successfully selected: " + selectedElement);
	}

	// MARK: Public
	public Element getSelectedElement() {
		return selectedElement;
	}
}
