using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMPanelController : WindMachine
{
    
    [SerializeField] GameObject fan;
    [SerializeField] GameObject turbine;
    [SerializeField] GameObject panelPowerLight;
    [SerializeField] GameObject[] buttons;
    
    //[SerializeField] GameObject increaseFanHeightButton;
    //[SerializeField] GameObject decreaseFanHeightButton;
    //[SerializeField] GameObject increaseTurbineHeightButton;
    //[SerializeField] GameObject decreaseTurbineHeightButton;
    //[SerializeField] GameObject RotateFanCCWButton;
    //[SerializeField] GameObject RotateFanCWButton;

    [SerializeField] Material activeLightMaterial;
    [SerializeField] Material inactiveLightMaterial;

    bool hasPower = false;
    bool isActivated = false;

    public override void Activate()
    {
        hasPower = true;
        isActivated = true;
        fan.GetComponent<FanController>().SetPowerState(true);
        fan.GetComponent<FanController>().Activate(); // Remove if we want fan to be activated by a button instead.
        panelPowerLight.GetComponent<Renderer>().material = activeLightMaterial;
        foreach (GameObject button in buttons)
        {
            button.GetComponent<InteractablePushAndHoldButton>().Activate();
        }
    }

    public override void Deactivate()
    {
        hasPower = false;
        isActivated = false;
        fan.GetComponent<FanController>().Deactivate();
        fan.GetComponent<FanController>().SetPowerState(false);
        panelPowerLight.GetComponent<Renderer>().material = activeLightMaterial;
        foreach (GameObject button in buttons)
        {
            button.GetComponent<InteractablePushAndHoldButton>().Deactivate();
        }
    }
}
