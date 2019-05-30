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

    void Awake()
    {
        animator = objectToAnimate.GetComponent<Animator>();

        ForAwake();
    }

    protected abstract void ForAwake();

    public override void Interact()
    {
        if (isInteractable)
        {
            isInteractable = false;
            ForInteract();

            StartCoroutine(WaitToAllowInteraction());
        }
    }

    protected abstract void ForInteract();

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
