using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMachinePanelController : WindMachine {

    [SerializeField] GameObject fan;
    [SerializeField] GameObject turbine;
    [SerializeField] GameObject panelPowerLight;
    [SerializeField] GameObject fanActiveLight;
    [SerializeField] Material activeLightMaterial;
    [SerializeField] Material inactiveLightMaterial;
    [SerializeField] float[] validHeights;
    [SerializeField] GameObject[] fanHeightLights;
    [SerializeField] GameObject[] turbineHeightLights;

    [SerializeField] GameObject fanHeightButton;
    [SerializeField] GameObject turbineHeightButton;


    bool hasPower = false;
    bool isActivated = false;

    private void Awake()
    {
        
    }

    public void ReceiveButtonPress(string buttonPurpose)
    {
        if (hasPower)
        {
            if (buttonPurpose == "ActivateFan")
            {
                if (fan.GetComponent<FanController>().GetActivatedState() == false)
                {
                    fan.GetComponent<FanController>().Activate();
                    fanActiveLight.GetComponent<Renderer>().material = activeLightMaterial;
                }
                else
                {
                    fan.GetComponent<FanController>().Deactivate();
                    panelPowerLight.GetComponent<Renderer>().material = inactiveLightMaterial;
                }
            }
            else if (buttonPurpose == "TurnFanCW" && isActivated)
            {
                fan.GetComponent<FanController>().Rotate(true);     // True for clockwise
            }
            else if (buttonPurpose == "TurnFanCCW" && isActivated)
            {
                fan.GetComponent<FanController>().Rotate(false);    // False for counter-clockwise
            }
        }
    }

    public void ReceiveHeightButtonSettings(string leverPurpose, int leverPosition)
    {
        if (hasPower && isActivated)
        {
            if (leverPurpose == "FanHeight")
            {
                Debug.Log("In WM Panel Controller - Fan Height");
                fan.GetComponent<FanController>().SetFanHeight(validHeights[leverPosition]);
                fanHeightLights[leverPosition].GetComponent<Renderer>().material = activeLightMaterial;
                if (leverPosition > 0)
                    fanHeightLights[leverPosition - 1].GetComponent<Renderer>().material = inactiveLightMaterial;
                else
                    fanHeightLights[fanHeightLights.Length - 1].GetComponent<Renderer>().material = inactiveLightMaterial;
            }
            else if (leverPurpose == "TurbineHeight")
            {
                Debug.Log("In WM Panel Controller - Fan Height");
                turbine.GetComponent<TurbineController>().SetTurbineHeight(validHeights[leverPosition]);
                turbineHeightLights[leverPosition].GetComponent<Renderer>().material = activeLightMaterial;
                if (leverPosition > 0)
                    turbineHeightLights[leverPosition - 1].GetComponent<Renderer>().material = inactiveLightMaterial;
                else
                    turbineHeightLights[turbineHeightLights.Length - 1].GetComponent<Renderer>().material = inactiveLightMaterial;
            }
        }
    }

    public override void Activate()
    {
        hasPower = true;
        isActivated = true;
        fan.GetComponent<FanController>().SetPowerState(true);
        panelPowerLight.GetComponent<Renderer>().material = activeLightMaterial;
        fanHeightLights[fanHeightButton.GetComponent<InteractableWMHeightButton>().GetStartingPoint()].GetComponent<Renderer>().material = activeLightMaterial;
        turbineHeightLights[turbineHeightButton.GetComponent<InteractableWMHeightButton>().GetStartingPoint()].GetComponent<Renderer>().material = activeLightMaterial;
    }

    public override void Deactivate()
    {
        fan.GetComponent<FanController>().Deactivate();
        fan.GetComponent<FanController>().SetPowerState(false);
        fanActiveLight.GetComponent<Renderer>().material = inactiveLightMaterial;
        panelPowerLight.GetComponent<Renderer>().material = inactiveLightMaterial;
        isActivated = false;
        hasPower = false;
    }
}
