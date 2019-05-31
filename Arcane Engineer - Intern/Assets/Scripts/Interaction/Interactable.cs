using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected string interactionToolTip;
    [SerializeField] GameObject interactLayerColliderHolder;
    public string InteractionToolTip { get { return interactionToolTip; } }

    bool isDisabled = false;

    Collider interactLayerCollider;

    void Awake()
    {
        interactLayerCollider = interactLayerColliderHolder.GetComponent<Collider>();

        ForAwake();
    }

    protected virtual void ForAwake() { }

    public void Interact()
    {
        if (!isDisabled)
        {
            ForInteract();
        }
    }

    protected abstract void ForInteract();

    public void DisableInteraction()
    {
        interactLayerCollider.enabled = false;

        isDisabled = true;
    }
}
