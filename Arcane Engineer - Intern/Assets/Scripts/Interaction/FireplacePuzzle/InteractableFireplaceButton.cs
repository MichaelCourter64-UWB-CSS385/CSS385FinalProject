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

    protected override void ForAwake()
    {
        panelController = firePlacePanelControllerHolder.GetComponent<FireplacePuzzleController>();
        buttonAnimator = GetComponent<Animator>();
    }

    protected override void ForInteract()
    {
        panelController.ReceiveButtonPress(patternNumber);

        buttonAnimator.SetBool(buttonAnimationTriggerName, true);
    }
}
