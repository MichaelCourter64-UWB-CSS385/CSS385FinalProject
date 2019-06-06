using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWMFinalPanelButton : KeyDownInteractable
{

    [SerializeField] GameObject FinalWMPanelControllerHolder;
    [SerializeField] string buttonPurpose;
    [SerializeField] string buttonAnimationTriggerName;

    FinalWMPanelController panelController;
    Animator buttonAnimator;

    private void Awake()
    {
        panelController = FinalWMPanelControllerHolder.GetComponent<FinalWMPanelController>();
        buttonAnimator = this.transform.GetComponent<Animator>();
    }

    // Use this for initialization
    protected override void ForKeyDownAwake()
    {
        panelController = FinalWMPanelControllerHolder.GetComponent<FinalWMPanelController>();
        buttonAnimator = this.transform.GetComponent<Animator>();
    }

    protected override void ForKeyDownInteract()
    {
        panelController.ReceiveButtonPress(buttonPurpose);
        buttonAnimator.SetBool(buttonAnimationTriggerName, true);
    }
}
