using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWindMachineButton : KeyDownInteractable
{
    [SerializeField] GameObject windMachinePanelControllerHolder;
    [SerializeField] string buttonPurpose;
    [SerializeField] string buttonAnimationTriggerName;

    WindMachinePanelController panelController;
    Animator buttonAnimator;

    private void Awake()
    {
        panelController = windMachinePanelControllerHolder.GetComponent<WindMachinePanelController>();
        buttonAnimator = this.transform.GetComponent<Animator>();
    }

    // Use this for initialization
    protected override void ForKeyDownAwake()
    {
        panelController = windMachinePanelControllerHolder.GetComponent<WindMachinePanelController>();
        buttonAnimator = this.transform.GetComponent<Animator>();
    }

    protected override void ForKeyDownInteract()
    {
        panelController.ReceiveButtonPress(buttonPurpose);
        Debug.Log("Center Button Animator: " + buttonAnimator);
        buttonAnimator.SetBool(buttonAnimationTriggerName, true);
    }
}
