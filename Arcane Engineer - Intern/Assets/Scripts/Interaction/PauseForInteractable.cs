using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PauseForInteractable : Interactable
{
    [SerializeField] float interactionDisableTime = 1;

    bool isInteractable = true;

    protected override void ForInteract()
    {
        if (isInteractable)
        {
            isInteractable = false;
            ForPauseInteract();

            StartCoroutine(WaitToAllowInteraction());
        }
    }

    protected abstract void ForPauseInteract();

    protected IEnumerator WaitToAllowInteraction()
    {
        yield return new WaitForSeconds(interactionDisableTime);
        isInteractable = true;
    }
}