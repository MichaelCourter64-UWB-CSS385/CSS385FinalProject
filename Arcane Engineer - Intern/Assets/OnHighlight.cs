using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


// MARK: - Class
public class OnHighlight : MonoBehaviour, IPointerEnterHandler {
	// MARK: Properties
	[SerializeField] int elementId;

	ButtonHandler buttonHandler;

	// MARK: Life Cycle
	void Start () {
		buttonHandler = GameObject.FindGameObjectWithTag("ButtonHandler").GetComponent<ButtonHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData eventData) {
		buttonHandler.pickElement(elementId);
	}
}
