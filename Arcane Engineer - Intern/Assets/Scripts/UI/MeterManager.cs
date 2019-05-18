using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MARK: - Class
public class MeterManager : MonoBehaviour {
	// MARK: Properties
	public Slider waterMeter, earthMeter, fireMeter, airMeter;

	// MARK: Life Cycle
	void Start () {
		if (GameObject.FindGameObjectWithTag ("WaterMeter")) { waterMeter = GameObject.FindGameObjectWithTag("WaterMeter").GetComponent<Slider>();  } else { Debug.Log("Error: Could not find the WaterMeter object"); }
		if (GameObject.FindGameObjectWithTag ("EarthMeter")) { earthMeter = GameObject.FindGameObjectWithTag("EarthMeter").GetComponent<Slider>(); } else { Debug.Log("Error: Could not find the EarthMeter object"); }
		if (GameObject.FindGameObjectWithTag ("FireMeter")) { fireMeter = GameObject.FindGameObjectWithTag("FireMeter").GetComponent<Slider>(); } else { Debug.Log("Error: Could not find the FireMeter object"); }
		if (GameObject.FindGameObjectWithTag ("AirMeter")) { airMeter = GameObject.FindGameObjectWithTag("AirMeter").GetComponent<Slider>(); } else { Debug.Log("Error: Could not find the AirMeter object"); }
	}

	void Update () {

	}

	// MARK: Private


	// MARK: Public

}
