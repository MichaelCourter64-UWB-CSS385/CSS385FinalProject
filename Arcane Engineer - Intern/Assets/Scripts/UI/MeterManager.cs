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

    [SerializeField] float maxValue = 1;

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
                waterValue = Mathf.Clamp(waterValue, 0, maxValue);
                waterMeter.value = waterValue;
                break;
            case Elements.Earth:
                earthValue += restorationRate * Time.deltaTime;
                earthValue = Mathf.Clamp(earthValue, 0, maxValue);
                earthMeter.value = earthValue;
                break;
            case Elements.Fire:
                fireValue += restorationRate * Time.deltaTime;
                fireValue = Mathf.Clamp(fireValue, 0, maxValue);
                fireMeter.value = fireValue;
                break;
            case Elements.Air:
                airValue += restorationRate * Time.deltaTime;
                airValue = Mathf.Clamp(airValue, 0, maxValue);
                airMeter.value = airValue;
                break;
        }
    }

    public void expendElement(Elements elementToExpend) {
        switch (elementToExpend) {
            case Elements.Water:
                waterValue -= exhaustRate * Time.deltaTime;
                waterValue = Mathf.Clamp(waterValue, 0, maxValue);
                waterMeter.value = waterValue;
                break;
            case Elements.Earth:
                earthValue -= exhaustRate * Time.deltaTime;
                earthValue = Mathf.Clamp(earthValue, 0, maxValue);
                earthMeter.value = earthValue;
                break;
            case Elements.Fire:
                fireValue -= exhaustRate * Time.deltaTime;
                fireValue = Mathf.Clamp(fireValue, 0, maxValue);
                fireMeter.value = fireValue;
                break;
            case Elements.Air:
                airValue -= exhaustRate * Time.deltaTime;
                airValue = Mathf.Clamp(airValue, 0, maxValue);
                airMeter.value = airValue;
                break;
        }
    }

    public float GetElementLevel(Elements elementToRetrieve)
    {
        switch (elementToRetrieve)
        {
            case Elements.Water:
                return waterValue;
                break;
            case Elements.Earth:
                return earthValue;
                break;
            case Elements.Fire:
                return fireValue;
                break;
            case Elements.Air:
                return airValue;
                break;
			default:
				Debug.Log("Error: Could not determine elementToRetrieve from Elements enum");
				return -1;
        }
    }
}
