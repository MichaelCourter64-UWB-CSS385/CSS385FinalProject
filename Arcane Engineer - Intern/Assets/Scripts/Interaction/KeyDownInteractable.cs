using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyDownInteractable : Interactable
{
    [SerializeField] GameObject objectToAnimate;
    [SerializeField] protected string animationStateName;
    [SerializeField] string neutralStateName;

    bool isInteractable = true;
    protected Animator animator;

    protected override void ForAwake()
    {
        animator = objectToAnimate.GetComponent<Animator>();

        ForKeyDownAwake();
    }

    protected virtual void ForKeyDownAwake() { }

    protected override void ForInteract()
    {
        if (isInteractable)
        {
            isInteractable = false;
            ForKeyDownInteract();

            StartCoroutine(WaitToAllowInteraction());
        }
    }

    protected abstract void ForKeyDownInteract();

    IEnumerator WaitToAllowInteraction()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationStateName))
        {
            yield return new WaitForFixedUpdate();
        }

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(neutralStateName))
        {
            yield return new WaitForFixedUpdate();
        }

        isInteractable = true;
    }
}
