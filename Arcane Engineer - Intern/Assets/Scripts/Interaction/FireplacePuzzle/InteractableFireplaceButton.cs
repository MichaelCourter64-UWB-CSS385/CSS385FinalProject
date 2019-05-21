using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFireplaceButton : Interactable {
    [SerializeField] GameObject firePlacePanelControllerHolder;
    [SerializeField] int patternNumber = 0;
    [SerializeField] string buttonAnimationTriggerName;
    [SerializeField] float interactionDisableTime = 1;

    FireplacePuzzleController panelController;
    Animator buttonAnimator;
    bool isInteractable = true;

    void Start()
    {
        panelController = firePlacePanelControllerHolder.GetComponent<FireplacePuzzleController>();
        buttonAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        //Debug.Log("interactble: " + isInteractable);
        if (isInteractable)
        {
            //Debug.Log("button pressed at " + Time.time);
            isInteractable = false;
            panelController.ReceiveButtonPress(patternNumber);

            buttonAnimator.SetBool(buttonAnimationTriggerName, true);

            StartCoroutine(WaitToAllowInteraction());
        }
        /*else
        {
            Debug.Log("re interact results:" + buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Neutral") + ", " + !buttonAnimator.GetBool("isBeingPressed"));

            if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Neutral") && !buttonAnimator.GetBool("isBeingPressed"))
            {
                Debug.Log("reset");
                isInteractable = true;
            }// Baisically the animation controller takes a while to update. Consider calculating animation time based on speed to not reset intercatable until that time.
        }*/
    }

    IEnumerator WaitToAllowInteraction()
    {
        //Debug.Log("start of wait:" + Time.time + ", speed:" + buttonAnimator.GetNextAnimatorStateInfo(0).speed);
        yield return new WaitForSeconds(interactionDisableTime);
        //Debug.Log("end of wait:" + Time.time);
        isInteractable = true;
    }
}
