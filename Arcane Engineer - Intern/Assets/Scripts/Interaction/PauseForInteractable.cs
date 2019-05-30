using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PauseForInteractable : Interactable
{
    [SerializeField] float interactionDisableTime = 1;

    bool isInteractable = true;

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

    protected IEnumerator WaitToAllowInteraction()
    {
        yield return new WaitForSeconds(interactionDisableTime);
        isInteractable = true;
    }
}