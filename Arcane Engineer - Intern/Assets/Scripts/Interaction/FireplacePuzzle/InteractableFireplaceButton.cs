using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFireplaceButton : KeyDownInteractable
{
    [SerializeField] GameObject firePlacePanelControllerHolder;
    [SerializeField] int patternNumber = 0;
    [SerializeField] string buttonAnimationTriggerName;

    FireplacePuzzleController panelController;
    Animator buttonAnimator;

    protected override void ForKeyDownAwake()
    {
        panelController = firePlacePanelControllerHolder.GetComponent<FireplacePuzzleController>();
        buttonAnimator = GetComponent<Animator>();
    }

    protected override void ForKeyDownInteract()
    {
        panelController.ReceiveButtonPress(patternNumber);

        buttonAnimator.SetBool(buttonAnimationTriggerName, true);
    }
}
