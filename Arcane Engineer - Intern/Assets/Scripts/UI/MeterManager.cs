using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MARK: - Class
public class MeterManager : MonoBehaviour {
    [SerializeField] float restorationRate;
    [SerializeField] float exhaustRate;

	// MARK: Properties
	public Slider waterMeter, earthMeter, fireMeter, airMeter;
	public float waterValue, earthValue, fireValue, airValue = 0;

	// MARK: Life Cycle
	void Awake () {
		if (GameObject.FindGameObjectWithTag ("WaterMeter")) { waterMeter = GameObject.FindGameObjectWithTag("WaterMeter").GetComponent<Slider>();  } else { Debug.Log("Error: Could not find the WaterMeter object"); }
		if (GameObject.FindGameObjectWithTag ("EarthMeter")) { earthMeter = GameObject.FindGameObjectWithTag("EarthMeter").GetComponent<Slider>(); } else { Debug.Log("Error: Could not find the EarthMeter object"); }
		if (GameObject.FindGameObjectWithTag ("FireMeter")) { fireMeter = GameObject.FindGameObjectWithTag("FireMeter").GetComponent<Slider>(); } else { Debug.Log("Error: Could not find the FireMeter object"); }
		if (GameObject.FindGameObjectWithTag ("AirMeter")) { airMeter = GameObject.FindGameObjectWithTag("AirMeter").GetComponent<Slider>(); } else { Debug.Log("Error: Could not find the AirMeter object"); }

		// Set initial values for the meters
		waterMeter.value = waterValue;
		earthMeter.value = earthValue;
		fireMeter.value = fireValue;
		airMeter.value = airValue;
	}

	void Update () {

	}

	// MARK: Private


	// MARK: Public
    public void RestoreElement(Elements elementToRestore) {
        switch (elementToRestore) {
            case Elements.Water:
                waterValue += restorationRate * Time.deltaTime;
                waterMeter.value = waterValue;
                break;
            case Elements.Earth:
                earthValue += restorationRate * Time.deltaTime;
                earthMeter.value = earthValue;
                break;
            case Elements.Fire:
                fireValue += restorationRate * Time.deltaTime;
                fireMeter.value = fireValue;
                break;
            case Elements.Air:
                airValue += restorationRate * Time.deltaTime;
                airMeter.value = airValue;
                break;
        }
    }

    public void expendElement(Elements elementToExpend) {
        switch (elementToExpend) {
            case Elements.Water:
                waterValue -= exhaustRate * Time.deltaTime;
                waterMeter.value = waterValue;
                break;
            case Elements.Earth:
                earthValue -= exhaustRate * Time.deltaTime;
                earthMeter.value = earthValue;
                break;
            case Elements.Fire:
                fireValue -= exhaustRate * Time.deltaTime;
                fireMeter.value = fireValue;
                break;
            case Elements.Air:
                airValue -= exhaustRate * Time.deltaTime;
                airMeter.value = airValue;
                break;
        }
    }

}
