using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// MARK: - Class
public class OnHighlight : MonoBehaviour
{
    // MARK: Properties
    [SerializeField] GameObject canvasHolder;
	[SerializeField] int elementId;
	[SerializeField] GameObject backgroundImage;

    GraphicRaycaster graphicRayCaster;
    EventSystem eventSystem;

    ElementManager elementManager;

	// MARK: Life Cycle
	void Awake () {
        //Fetch the Raycaster from the GameObject (the Canvas)
        graphicRayCaster = canvasHolder.GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        eventSystem = canvasHolder.GetComponent<EventSystem>();

        elementManager = GameObject.FindGameObjectWithTag("ElementManager").GetComponent<ElementManager>();
	}
	
	// Update is called once per frame
	public void CheckElementSelection ()
    {
        //Set up the new Pointer Event
        PointerEventData m_PointerEventData = new PointerEventData(eventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        graphicRayCaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            OnHighlight possibleElementButton = result.gameObject.GetComponent<OnHighlight>();

            if (result.gameObject == gameObject)
            {
                elementManager.PickElement(elementId);
            }
        }
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
}
