using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTutorialButton : KeyDownInteractable
{
    [SerializeField] GameObject puzzleControllerHolder;
    [SerializeField] string buttonAnimationTriggerName;

    BasicButtonsController puzzleController;

    protected override void ForKeyDownAwake()
    {
        puzzleController = puzzleControllerHolder.GetComponent<BasicButtonsController>();
    }

    protected override void ForKeyDownInteract()
    {
        puzzleController.pressedAButton();

        animator.SetBool(buttonAnimationTriggerName, true);
    }
}
