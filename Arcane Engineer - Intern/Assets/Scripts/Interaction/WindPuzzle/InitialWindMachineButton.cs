using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialWindMachineButton : KeyDownInteractable
{
    [SerializeField] GameObject windMachineFirstPanelControllerHolder;
    [SerializeField] string buttonPurpose;
    [SerializeField] string buttonAnimationTriggerName;

    WindMachineFirstPanelController panelController;
    Animator buttonAnimator;

    // Use this for initialization
    protected override void ForKeyDownAwake()
    {
        panelController = windMachineFirstPanelControllerHolder.GetComponent<WindMachineFirstPanelController>();
        buttonAnimator = GetComponent<Animator>();
    }

    protected override void ForKeyDownInteract()
    {
        panelController.ReceiveButtonPress(buttonPurpose);
        buttonAnimator.SetBool(buttonAnimationTriggerName, true);
    }
}
