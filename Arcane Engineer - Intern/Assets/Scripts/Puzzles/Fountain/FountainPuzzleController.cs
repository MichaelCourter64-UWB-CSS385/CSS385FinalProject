using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainPuzzleController : MonoBehaviour {
    [SerializeField] GameObject waterLevelIndicator;
    [SerializeField] float waterLevelToReachDeadZoneHalf;
    [SerializeField] float waterLevelToReach;
    [SerializeField] GameObject progressionSystemHolder;
    [SerializeField] ProgressionMarks progressMarkToCheckOff;
    [SerializeField] string overpressureParamName;
    [SerializeField] float waterLevelIndicatorRange;

    Animator indicatorAnimator;
    float waterLevel = 0;
    float indicatorStartingPoint;
    float indicatorEndPoint;
    ProgressionSystem progressionSystem;

	// Use this for initialization
	void Start ()
    {
        indicatorAnimator = waterLevelIndicator.transform.parent.GetComponent<Animator>();
        indicatorStartingPoint = waterLevelIndicator.transform.position.y;
        indicatorEndPoint = indicatorStartingPoint + waterLevelIndicatorRange;

        progressionSystem = progressionSystemHolder.GetComponent<ProgressionSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeWaterLevel(float amountToChange)
    {
        float waterFloatPercentage;
        float levelIndicatorNewLevel;

        waterLevel += amountToChange;
        waterLevel = Mathf.Clamp(waterLevel, 0, int.MaxValue);

        // If the water level is close enough to the amount to reach, then:
        if (waterLevel <= waterLevelToReach && waterLevel > waterLevelToReach - waterLevelToReachDeadZoneHalf)
        {
            progressionSystem.Completed(progressMarkToCheckOff.ToString());
        }

        if (waterLevel > waterLevelToReach)
        {
            indicatorAnimator.SetBool(overpressureParamName, true);
        }
        else if (waterLevel <= waterLevelToReach)
        {
            indicatorAnimator.SetBool(overpressureParamName, false);
        }

        Debug.Log("new water level: " + waterLevel);
        Debug.Log("is shaking: " + (waterLevel > waterLevelToReach));
        //Debug.Log("level / toReach: " + waterLevel / waterLevelToReach);
        waterFloatPercentage = Mathf.Clamp(waterLevel / waterLevelToReach, 0, 1);
        //Debug.Log("waterFloatPercentage: " + waterFloatPercentage);
        levelIndicatorNewLevel = (waterFloatPercentage * waterLevelIndicatorRange) + indicatorStartingPoint;
        //Debug.Log("levelIndicatorNewLevel: " + levelIndicatorNewLevel);
        waterLevelIndicator.transform.position = new Vector3(waterLevelIndicator.transform.position.x, levelIndicatorNewLevel, waterLevelIndicator.transform.position.z);
    }
}
