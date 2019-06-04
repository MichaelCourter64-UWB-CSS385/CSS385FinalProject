using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMachineFirstPanelController : WindMachine {

    [SerializeField] GameObject[] controlledObjects;
    [SerializeField] GameObject[] lightObjects;
    [SerializeField] Material activeLightMaterial;
    [SerializeField] Material inactiveLightMaterial;
    [SerializeField] int[] heightSettings;

    bool hasPower = false;
    bool isActivated = false;

    private void Awake()
    {
        Activate();     // Change this if it needs to not start with power.
    }

    public void ReceiveButtonPress(string buttonPurpose)
    {
        if (hasPower)
        {
            if (buttonPurpose == "Activate")
            {
                isActivated = !isActivated;
                if (isActivated)
                {
                    foreach (GameObject co in controlledObjects)
                    {
                        // Have to set power state and Activate here because this is 
                        // the first stage of the wind machine and the button does both.
                        co.GetComponent<FanController>().SetPowerState(true);
                        co.GetComponent<FanController>().Activate();
                    }
                    foreach (GameObject light in lightObjects)
                        light.GetComponent<Renderer>().material = activeLightMaterial;
                }
                else
                {
                    foreach (GameObject co in controlledObjects)
                        co.GetComponent<WindMachine>().Deactivate();
                    foreach (GameObject light in lightObjects)
                        light.GetComponent<Renderer>().material = inactiveLightMaterial;
                }
            }
        }
    }

    public override void Activate()
    {
        hasPower = true;
        lightObjects[1].GetComponent<Renderer>().material = activeLightMaterial;
    }

    public override void Deactivate()
    {
        hasPower = false;
    }
}
