using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWMPanelController : WindMachine
{
    [SerializeField] GameObject fan1;
    [SerializeField] GameObject fan2;
    [SerializeField] GameObject turbine1;
    [SerializeField] GameObject turbine2;
    [SerializeField] GameObject turbine3;
    [SerializeField] GameObject panelPowerLight;
    [SerializeField] GameObject fan1ActiveLight;
    [SerializeField] GameObject fan2ActiveLight;
    [SerializeField] Material activeLightMaterial;
    [SerializeField] Material inactiveLightMaterial;

    bool turbine1_IsOn = false;
    bool turbine2_IsOn = false;
    bool turbine3_IsOn = false;
    bool hasPower = false;
    bool isActivated = false;


    public void ReceiveButtonPress(string buttonPurpose)
    {
        if (hasPower)
        {
            if (buttonPurpose == "Fan1Activate")
            {
                if (fan1.GetComponent<FanController>().GetActivatedState() == false)
                {
                    fan1.GetComponent<FanController>().Activate();
                    fan1ActiveLight.GetComponent<Renderer>().material = activeLightMaterial;
                }
                else
                {
                    fan1.GetComponent<FanController>().Deactivate();
                    fan1ActiveLight.GetComponent<Renderer>().material = inactiveLightMaterial;
                }
            }
            else if (buttonPurpose == "Fan2Activate")
            {
                if (fan2.GetComponent<FanController>().GetActivatedState() == false)
                {
                    fan2.GetComponent<FanController>().Activate();
                    fan2ActiveLight.GetComponent<Renderer>().material = activeLightMaterial;
                }
                else
                {
                    fan2.GetComponent<FanController>().Deactivate();
                    fan2ActiveLight.GetComponent<Renderer>().material = inactiveLightMaterial;
                }
            }
        }
    }

    public override void Activate()
    {
        if (turbine1_IsOn && turbine2_IsOn && turbine3_IsOn)
        {
            hasPower = true;
            isActivated = true;
            fan1.GetComponent<FanController>().SetPowerState(true);
            fan2.GetComponent<FanController>().SetPowerState(true);
            panelPowerLight.GetComponent<Renderer>().material = activeLightMaterial;
        }
    }

    public override void Deactivate()
    {
        fan1.GetComponent<FanController>().Deactivate();
        fan1.GetComponent<FanController>().SetPowerState(false);
        fan2.GetComponent<FanController>().Deactivate();
        fan2.GetComponent<FanController>().SetPowerState(false);
        panelPowerLight.GetComponent<Renderer>().material = inactiveLightMaterial;
        isActivated = false;
        hasPower = false;
    }

    public void Fan1Power(bool isOn)
    {
        turbine1_IsOn = isOn;
    }

    public void Fan2Power(bool isOn)
    {
        turbine2_IsOn = isOn;
    }

    public void Fan3Power(bool isOn)
    {
        turbine3_IsOn = isOn;
    }
}
