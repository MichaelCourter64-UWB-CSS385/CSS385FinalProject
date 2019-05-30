using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableValveTurnPoint : KeyDownInteractable
{
    [SerializeField] float waterAmountToChangeBy;
    [SerializeField] bool isRotatingRight;
    [SerializeField] GameObject fountainPuzzleControllerHolder;
    [SerializeField] string animationTriggerName;

    FountainPuzzleController fountainPuzzleController;

    // Use this for initialization
    protected override void ForAwake () {
        fountainPuzzleController = fountainPuzzleControllerHolder.GetComponent<FountainPuzzleController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void ForInteract()
    {
        fountainPuzzleController.ChangeWaterLevel(waterAmountToChangeBy * (isRotatingRight ? 1 : -1));

        animator.SetBool(animationTriggerName, true);
    }
}
