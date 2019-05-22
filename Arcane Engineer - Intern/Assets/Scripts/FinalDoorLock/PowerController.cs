using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour {
    // References to the objects which receive initial power
    [SerializeField] GameObject leftStart;
    [SerializeField] GameObject leftTarget;
    [SerializeField] GameObject rightStart;
    [SerializeField] GameObject rightTarget;
    [SerializeField] GameObject lockActivator;
    [SerializeField] GameObject dial1;
    [SerializeField] GameObject dial2;

    //// For final usage
    //private bool waterOn;
    //private bool fireOn;
    //private bool earthOn;
    //private bool windOn;

    // For debug usage
    [SerializeField] bool waterOn;
    [SerializeField] bool fireOn;
    [SerializeField] bool earthOn;
    [SerializeField] bool windOn;


    // Move these to the PowerboxOutput.cs files for their respective output objects
    private int[] leftStartVals = new int[4] { 1, 2, 3, 4 };
    private int[] leftTargetVals = new int[4] { 3, 4, 2, 1 };
    private int[] rightStartVals = new int[4] { 4, 3, 2, 1 };
    private int[] rightTargetVals = new int[4] { 1, 3, 2, 4 };

    // Initialization
    void Start () {
        //waterOn = false;
        //fireOn = false;
        //earthOn = false;
        //windOn = false;

        waterOn = true;
        fireOn = true;
        earthOn = true;
        windOn = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (waterOn && fireOn && earthOn && windOn)
            PowerOn();
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
