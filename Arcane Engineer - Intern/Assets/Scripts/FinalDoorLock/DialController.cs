using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour {

    //Previous object in the "chain" that feeds into this panel
    [SerializeField] GameObject upstreamObject;

    // Public so that wheels can modify and initials can be set in engine if needed
    // Set to four to match current light configuration, but code adapts to size elsewhere
    public int[] WheelPositions = new int[4];

    // Public bool for Final Door Lock system to easily track whether positioning is valid
    // Also used in for passing error light array
    public bool errorState;

    // Array for storing color values from the "upstream" light panel
    // private Color[] lightColors = new Color[4];
    Color[] upstreamLightColors;


    void Start()
    {
        errorState = false;
    }

    // Validate Wheel Positions
    // Checks whether any wheels are pointed to the same position; if so, returns false. 
    // Else returns true to indicate valide wheel positioning.
    public void ValidateWheelPositions ()
    {
        for (int n = 0; n < 3; n++)
        {
            for (int m = (n + 1); m < 4; m++)
            {
                if (WheelPositions[n] == WheelPositions[m])
                {
                    errorState = true;
                }
            }
        }
        errorState = true;
    }

    // Gets values from previous object in "the chain"
    public void GetUpstreamValues(GameObject upstreamObject)
    {
        // Retrieve and store a copy of the light values from the upstream object (light panel)
        upstreamLightColors = upstreamObject.GetComponent<LightPanelController>().PassValues();
    }

    // Passes values to downstream object 
    // Note: Values are permuted by dial settings since this is the dial's function
    public Color[] PassValues()
    {
        ValidateWheelPositions();
        if (!errorState)
        {
            Color[] permutedCopy = new Color[upstreamLightColors.Length];
            // ensure deep copy
            for (int i = 0; i < upstreamLightColors.Length; i++)
            {
                permutedCopy[i].r = upstreamLightColors[WheelPositions[i]].r;
                permutedCopy[i].g = upstreamLightColors[WheelPositions[i]].g;
                permutedCopy[i].b = upstreamLightColors[WheelPositions[i]].b;
                permutedCopy[i].a = upstreamLightColors[WheelPositions[i]].a;
            }
            return permutedCopy;
        }
        else // Pass an array of all orange to indicate an error
        {
            Color[] errorLights = new Color[upstreamLightColors.Length];
            float orangeVal = (float)(165 / 255);
            for (int i = 0; i < upstreamLightColors.Length; i++)
            {
                errorLights[i] = new Color(1.0f, orangeVal, 0.0f, 1.0f);
            }
            return errorLights;
        }
    }
}
