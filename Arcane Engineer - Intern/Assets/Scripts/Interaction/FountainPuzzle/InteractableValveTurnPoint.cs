using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableValveTurnPoint : KeyDownInteractable {
    [SerializeField] float waterAmountToChangeBy;
    [SerializeField] bool isRotatingRight;
    [SerializeField] GameObject fountainPuzzleControllerHolder;

    FountainPuzzleController fountainPuzzleController;

    // Use this for initialization
    void Awake () {
        fountainPuzzleController = fountainPuzzleControllerHolder.GetComponent<FountainPuzzleController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void ForInteract()
    {
        fountainPuzzleController.ChangeWaterLevel(waterAmountToChangeBy * (isRotatingRight ? 1 : -1));
    }
}
