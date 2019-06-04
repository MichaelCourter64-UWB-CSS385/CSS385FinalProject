using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineController : WindMachine {

    [SerializeField] GameObject controlPanel;
    [SerializeField] GameObject parent;
    [SerializeField] float heightAdjustSpeed;

    Animator turbineAnimator;
    bool isActivated = false;

    // Use this for initialization
    void Awake ()
    {
        turbineAnimator = this.transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Used for raycast hit to turn on the turbine when a fan successfully
    // directs its flow of air at the turbine.
    public override void Activate()
    {
        isActivated = true;
        controlPanel.GetComponent<WindMachinePanelController>().Activate();
        turbineAnimator.SetBool("isOn", true);
    }

    public override void Deactivate()
    {
        isActivated = false;
        controlPanel.GetComponent<WindMachinePanelController>().Deactivate();
        turbineAnimator.SetBool("isOn", false);
    }

    public bool CheckIfRunning()
    {
        return isActivated;
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
}
