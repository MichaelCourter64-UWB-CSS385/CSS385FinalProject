using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


// MARK: - Class
public class OnHighlight : MonoBehaviour, IPointerEnterHandler {
	// MARK: Properties
	[SerializeField] int elementId;

	ElementManager elementManager;

	// MARK: Life Cycle
	void Start () {
		elementManager = GameObject.FindGameObjectWithTag("ElementManager").GetComponent<ElementManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData eventData) {
		elementManager.pickElement(elementId);
	}
}
