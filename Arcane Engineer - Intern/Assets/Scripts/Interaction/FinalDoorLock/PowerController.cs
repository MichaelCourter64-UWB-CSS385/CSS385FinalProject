using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : ProgressChecker, ProgressionUser
{
    // References to the objects in the final puzzle that get inital power
    [SerializeField] GameObject leftStart;
    [SerializeField] GameObject leftTarget;
    [SerializeField] GameObject rightStart;
    [SerializeField] GameObject rightTarget;
    [SerializeField] GameObject lockActivator;
    [SerializeField] GameObject dial1;
    [SerializeField] GameObject dial2;

    // References to the progression system trackers for element puzzle completion
    [SerializeField] ProgressionMarks waterComplete;
    [SerializeField] ProgressionMarks fireComplete;
    [SerializeField] ProgressionMarks earthComplete;
    [SerializeField] ProgressionMarks windComplete;

    // Move these to the PowerboxOutput.cs files for their respective output objects
    private int[] leftStartVals = new int[4] { 1, 2, 3, 4 };
    private int[] leftTargetVals = new int[4] { 3, 4, 2, 1 };
    private int[] rightStartVals = new int[4] { 4, 3, 2, 1 };
    private int[] rightTargetVals = new int[4] { 1, 3, 2, 4 };

    // For debug usage
    //bool waterOn;
    //bool fireOn;
    //bool earthOn;
    //bool windOn;

    // Initialization
    void Awake () {
        // For debugging purposes
        //waterOn = true;
        //fireOn = true;
        //earthOn = true;
        //windOn = true;
        //PowerOn();
    }

    protected override void ReceiveProgressionUpdate()
    {
        // If all previous element puzzles are complete, power on the final puzzle;
        if (dontDestroyRefs.ProgressionSystemInstance.IsCompleted(waterComplete.ToString())
            && dontDestroyRefs.ProgressionSystemInstance.IsCompleted(fireComplete.ToString())
            && dontDestroyRefs.ProgressionSystemInstance.IsCompleted(earthComplete.ToString())
            && dontDestroyRefs.ProgressionSystemInstance.IsCompleted(windComplete.ToString()))
        {
            PowerOn();
        }
    }

    void PowerOn()
    {
        lockActivator.GetComponent<LockActivationController>().hasPower = true;
        dial1.GetComponent<DialController>().Activate();
        dial2.GetComponent<DialController>().Activate();
        leftStart.GetComponent<LightPanelController>().Activate();
        rightStart.GetComponent<LightPanelController>().Activate();
        leftTarget.GetComponent<LightPanelController>().Activate();
        rightTarget.GetComponent<LightPanelController>().Activate();
    }
}
