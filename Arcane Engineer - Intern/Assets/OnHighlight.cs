using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// MARK: - Class
public class OnHighlight : MonoBehaviour, IPointerEnterHandler {
	// MARK: Properties
	[SerializeField] int elementId;
	[SerializeField] GameObject backgroundImage;

	ElementManager elementManager;

	// MARK: Life Cycle
	void Start () {
		elementManager = GameObject.FindGameObjectWithTag("ElementManager").GetComponent<ElementManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// MARK: Private
	private Color pickColor() {
		Color bgColor = new Color();

		switch(elementId) {
		case 0: // Water 0	72	255
			bgColor.r = 0;
			bgColor.g =	72;
			bgColor.b =	255;
			bgColor.a = 0.25f;
			break;
		case 1: // Earth 93	49	0
			bgColor.r = 93;
			bgColor.g =	49;
			bgColor.b =	0;
			bgColor.a = 0.25f;
			break;
		case 2: // Fire 231	23	0
			bgColor.r = 231;
			bgColor.g =	23;
			bgColor.b =	0;
			bgColor.a = 0.25f;
			break;
		case 3: // Air
			bgColor.r = 255;
			bgColor.g =	255;
			bgColor.b =	255;
			bgColor.a = 0.25f;
			break;
		default:
			// Should not happen.
			bgColor = Color.black;
			bgColor.a = 0.75f;
			break;
		}

		return bgColor;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		elementManager.pickElement(elementId);

		// Set the color on the Panel
		//Color bgColor = pickColor();

		//backgroundImage.GetComponent<Image>().color = bgColor;
	}
}
