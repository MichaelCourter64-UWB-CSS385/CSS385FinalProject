using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMFinalTurbineController : WindMachine {

    [SerializeField] GameObject finalControlPanel;

    [SerializeField] int turbineNumber;

    Animator turbineAnimator;
    bool isActivated = false;

    // Use this for initialization
    void Awake()
    {
        turbineAnimator = this.transform.GetComponent<Animator>();
    }

    // Used for raycast hit to turn on the turbine when a fan successfully
    // directs its flow of air at the turbine.
    public override void Activate()
    {
        isActivated = true;
        if (turbineNumber == 1)
            finalControlPanel.GetComponent<FinalWMPanelController>().Turbine1Power(true);
        if (turbineNumber == 2)
            finalControlPanel.GetComponent<FinalWMPanelController>().Turbine2Power(true);
        if (turbineNumber == 3)
            finalControlPanel.GetComponent<FinalWMPanelController>().Turbine3Power(true);
        finalControlPanel.GetComponent<FinalWMPanelController>().Activate();
        turbineAnimator.SetBool("isOn", true);
    }

    public override void Deactivate()
    {
        isActivated = false;
        if (turbineNumber == 1)
            finalControlPanel.GetComponent<FinalWMPanelController>().Turbine1Power(false);
        if (turbineNumber == 2)
            finalControlPanel.GetComponent<FinalWMPanelController>().Turbine2Power(false);
        if (turbineNumber == 3)
            finalControlPanel.GetComponent<FinalWMPanelController>().Turbine3Power(false);
        finalControlPanel.GetComponent<FinalWMPanelController>().Deactivate();
        turbineAnimator.SetBool("isOn", false);
    }

    public bool CheckIfRunning()
    {
        return isActivated;
    }
}

