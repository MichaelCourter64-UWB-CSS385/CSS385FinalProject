using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineController : ParentTurbineController {

    [SerializeField] GameObject controlPanel;
    [SerializeField] GameObject parent;

    [SerializeField] float heightAdjustSpeed;
    [SerializeField] float heightMin;
    [SerializeField] float heightMax;

    Animator turbineAnimator;
    bool isActivated = false;

    // Use this for initialization
    void Awake ()
    {
        turbineAnimator = this.transform.GetComponent<Animator>();
	}
	
    // Used for raycast hit to turn on the turbine when a fan successfully
    // directs its flow of air at the turbine.
    public override void Activate()
    {
        isActivated = true;
        //controlPanel.GetComponent<WMPanelController>().Activate();
        controlPanel.GetComponent<WindMachine>().Activate();
        turbineAnimator.SetBool("isOn", true);
    }

    public override void Deactivate()
    {
        isActivated = false;
        //controlPanel.GetComponent<WMPanelController>().Deactivate();
        controlPanel.GetComponent<WindMachine>().Deactivate();
        turbineAnimator.SetBool("isOn", false);
    }

    public void MoveVertical(bool up)
    {
        float currentHeight = parent.transform.position.y;
        int directionModifier = up ? 1 : -1;
        float adjust = heightAdjustSpeed * directionModifier;
        if ((currentHeight + adjust) <= heightMax && (currentHeight + adjust) >= heightMin)
        {
            parent.transform.position += new Vector3(0, adjust, 0);
        }
    }

    public void SetTurbineHeight(float newHeight)
    {
        StartCoroutine(AdjustTurbineHeight(newHeight));
    }

    IEnumerator AdjustTurbineHeight(float targetHeight)
    {
        float currentHeight = parent.transform.position.y;
        int directionModifier = (currentHeight < targetHeight) ? 1 : -1;
        Vector3 pos = parent.transform.position;
        while (currentHeight != targetHeight)
        {
            yield return new WaitForFixedUpdate();
            pos.y += (heightAdjustSpeed * directionModifier);
            parent.transform.position = pos;
        }
    }

    public override bool getIsActivated()
    {
        return isActivated;
    }
}
