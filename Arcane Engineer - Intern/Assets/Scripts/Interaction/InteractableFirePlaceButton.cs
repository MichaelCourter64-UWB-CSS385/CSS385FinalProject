using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFireplaceButton : Interactable {
    [SerializeField] GameObject firePlacePanelControllerHolder;
    [SerializeField] int patternNumber = 0;
    [SerializeField] string buttonAnimationTriggerName;

    FirePlacePuzzleController panelController;
    Animator buttonAnimator;

    void Start()
    {
        panelController = firePlacePanelControllerHolder.GetComponent<FirePlacePuzzleController>();
        buttonAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        panelController.ReceiveButtonPress(patternNumber);

        buttonAnimator.SetTrigger(buttonAnimationTriggerName);
    }
}
