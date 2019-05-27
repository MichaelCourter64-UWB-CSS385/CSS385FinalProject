using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected string interactionToolTip;
    public string InteractionToolTip { get { return interactionToolTip; } }

    public abstract void Interact();
}
