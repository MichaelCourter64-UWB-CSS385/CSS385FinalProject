using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePushAndHoldButton : Interactable
{
    //[SerializeField] GameObject parent;
    [SerializeField] GameObject controlledObject;
    //[SerializeField] string downStateName;
    //[SerializeField] string upStateName;
    //[SerializeField] string neutralStateName;
    [SerializeField] string buttonUsedFor;
    [SerializeField] bool direction;

    //Animator buttonAnimator;
    //Alternate_WindMachinePanelController panelController;
    FanController fc;
    TurbineController tc;

    bool isInteractable;

    void Awake()
    {
        //buttonAnimator = this.transform.GetComponent<Animator>();
        fc = controlledObject.GetComponent<FanController>();
        //this.DisableInteraction();
    }

    protected override void ForAwake()
    {
        //if (controlledObject.GetComponent<FanController>() != null)
            //fc = controlledObject.GetComponent<FanController>();
        //if (controlledObject.GetComponent<TurbineController>() != null)
            //tc = controlledObject.GetComponent<TurbineController>();
    }

    protected override void ForInteract()
    {
        if (isInteractable)
        {
            if (buttonUsedFor == "fanRotation")
            {
                //Debug.Log("In InteractablePushAndHoldButton - fanRotation");
                fc.NewRotate(direction);
            }
            if (buttonUsedFor == "fanHeight")
            {
                //Debug.Log("In InteractablePushAndHoldButton - fanHeight");
                fc.MoveVertical(direction);
            }
            if (buttonUsedFor == "turbineheight")
            {
                ///Debug.Log("In InteractablePushAndHoldButton - turbineHeight");
                tc.MoveVertical(direction);
            }
        }
    }

    public void Activate()
    {
        isInteractable = true;
    }

    public void Deactivate()
    {
        isInteractable = false;
    }
}
