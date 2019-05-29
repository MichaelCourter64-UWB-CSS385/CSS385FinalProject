using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyDownInteractable : Interactable
{
    [SerializeField] float interactionDisableTime = 1;
    [SerializeField] GameObject objectToAnimate;
    [SerializeField] protected string animationStateName;
    [SerializeField] string neutralStateName;

    bool isInteractable = true;
    protected Animator animator;

    void Awake()
    {
        animator = objectToAnimate.GetComponent<Animator>();

        ForAwake();
    }

    protected abstract void ForAwake();

    public override void Interact()
    {
        Debug.Log("interactble: " + isInteractable);
        if (isInteractable)
        {
            Debug.Log("button pressed at " + Time.time);
            isInteractable = false;
            ForInteract();

            StartCoroutine(WaitToAllowInteraction());
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
    }

    protected abstract void ForInteract();

    IEnumerator WaitToAllowInteraction()
    {
        //Debug.Log("start of wait:" + Time.time + ", speed:" + buttonAnimator.GetNextAnimatorStateInfo(0).speed);
        //yield return new WaitForSeconds(interactionDisableTime);
        //Debug.Log("end of wait:" + Time.time);

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationStateName))
        {
            Debug.Log("waiting for anim");
            yield return new WaitForFixedUpdate();
        }

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(neutralStateName))
        {
            Debug.Log("waiting for return to neutral");
            yield return new WaitForFixedUpdate();
        }

        isInteractable = true;
    }
}
