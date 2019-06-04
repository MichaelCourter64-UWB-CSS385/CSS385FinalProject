using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWMHeightButton : KeyDownInteractable
{

    [SerializeField] GameObject windMachinePanelControllerHolder;
    [SerializeField] string buttonPurpose;
    [SerializeField] string buttonAnimationTriggerName;
    [SerializeField] int startingPosition;
    [SerializeField] int numPositions;

    WindMachinePanelController panelController;
    Animator buttonAnimator;
    int position;

    private void Awake()
    {
        if (startingPosition >= 0 && startingPosition <= numPositions)
            position = startingPosition;
        else
            position = 0;
        Debug.Log(windMachinePanelControllerHolder.GetComponent<WindMachinePanelController>());
        panelController = windMachinePanelControllerHolder.GetComponent<WindMachinePanelController>();
    }

    // Use this for initialization
    protected override void ForKeyDownAwake()
    {
        panelController = windMachinePanelControllerHolder.GetComponent<WindMachinePanelController>();
        buttonAnimator = GetComponent<Animator>();
    }

    protected override void ForKeyDownInteract()
    {
        position = ((position + 1) % numPositions) - 1;
        Debug.Log("In WM Panel Controller - Fan Height");
        Debug.Log(position);
        panelController.ReceiveHeightButtonSettings(buttonPurpose, position);
        buttonAnimator.SetBool(buttonAnimationTriggerName, true); 
    }

    public int GetStartingPoint()
    {
        return startingPosition;
    }
}
