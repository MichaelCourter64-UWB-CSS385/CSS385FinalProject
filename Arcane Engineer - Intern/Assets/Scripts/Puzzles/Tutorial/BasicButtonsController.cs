using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonsController : MonoBehaviour, ProgressionUser
{
    [SerializeField] GameObject linkToDontDestroyHolder;
    [SerializeField] ProgressionMarks markToMarkOnCompletion;

    [SerializeField] GameObject[] buttons;

    DontDestroyReferenceHolder dontDestroyRefs;

    int pressCount = 0;

    // Use this for initialization
    void Start()
    {
        dontDestroyRefs = linkToDontDestroyHolder.GetComponent<LinkToDontDestroy>().DontDestroyReferences;
    }
    public void pressedAButton()
    {
        pressCount++;

        if(pressCount >= buttons.Length)
        {
            dontDestroyRefs.ProgressionSystemInstance.Completed(markToMarkOnCompletion.ToString());

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Interactable>().DisableInteraction();
            }
        }
    }
}
