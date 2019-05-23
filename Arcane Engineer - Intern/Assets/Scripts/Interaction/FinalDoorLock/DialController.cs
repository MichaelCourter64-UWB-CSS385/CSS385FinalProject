using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour {

    //Previous object in the "chain" that feeds into this panel
    [SerializeField] GameObject upstreamObjectLeft;
    [SerializeField] GameObject upstreamObjectRight;

    // Public so that wheels can modify and initial values can be set in engine if needed
    public int[] WheelPositions = new int[4];

    // Public bool for Final Door Lock system to easily track whether positioning is valid
    // Also used in for passing error light array
    public bool errorState;
    private bool hasPower;

    // Array for storing the values from the "upstream" light panels
    // private Color[] lightColors = new Color[4];
    int[] upstreamValuesLeft;
    int[] upstreamValuesRight;


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
            int m = (n + 1);
            for (; m < 4; m++)
            {
                if (WheelPositions[n] == WheelPositions[m])
                {
                    errorState = true;
                    // Debug.Log("In DialController - Validate Wheel Positions - Invalid Wheel Positions:");
                    // Debug.Log("Wheel " + n + " = " + WheelPositions[n] + "and Wheel " + m + " = " + WheelPositions[m]);
                    return;
                }
            }
        }
        errorState = false;
    }


    //--------------------------------------- NEW VERSION (int) --------------------------------------------
    //
    // Gets values from previous object in "the chain"
    public void GetUpstreamValues(bool rightStream)
    {
        // Retrieve and store a copy of the light values from the appropriate upstream object (light panel)
        if (rightStream)
            upstreamValuesRight = upstreamObjectRight.GetComponent<LightPanelController>().PassValues();
        else
            upstreamValuesLeft = upstreamObjectLeft.GetComponent<LightPanelController>().PassValues();
    }

    // Passes values to downstream object 
    // Note: Values are permuted by dial settings since this is the dial's function
    public int[] PassValues(bool rightStream)
    {
        ValidateWheelPositions();
        if (!errorState)
        {
            if (rightStream)
                return CopyAndPermute(upstreamValuesLeft);
            else
                return CopyAndPermute(upstreamValuesRight);
        }
        else // Pass an array of all error mat indexes to indicate an error
        {
            int[] errorLights = new int[upstreamValuesLeft.Length];
            for (int i = 0; i < upstreamValuesLeft.Length; i++)
            {
                errorLights[i] = 5; // Set all to error light shader's index in material array
            }
            return errorLights;
        }
    }

    private int[] CopyAndPermute(int[] upstreamValues)
    {
        int[] permutedCopy = new int[upstreamValues.Length];
        for (int i = 0; i < upstreamValues.Length; i++)
        {
            permutedCopy[i] = upstreamValues[WheelPositions[i]]; //+ 1]; // Plus 1 to avoid the 0 index "off material"
        }
        return permutedCopy;
    }

    public void Activate()
    {
        hasPower = true;
        GetUpstreamValues(true);
        GetUpstreamValues(false);
    }

    public void Deactivate()
    {
        hasPower = false;
    }

    ////-------------------------------------- OLD VERSION (Color) --------------------------------------------
    // 
    //
    //// Array for storing color values from the "upstream" light panel
    //// private Color[] lightColors = new Color[4];
    //Color[] upstreamColorsLeft;
    //Color[] upstreamColorsRight;
    //
    //// Gets values from previous object in "the chain"
    //public void GetUpstreamValues(bool rightStream)
    //{
    //    // Retrieve and store a copy of the light values from the appropriate upstream object (light panel)
    //    if (rightStream)
    //        upstreamColorsRight = upstreamObjectRight.GetComponent<LightPanelController>().PassValues();
    //    else
    //        upstreamColorsLeft = upstreamObjectLeft.GetComponent<LightPanelController>().PassValues();
    //}

    //// Passes values to downstream object 
    //// Note: Values are permuted by dial settings since this is the dial's function
    //public Color[] PassValues(bool rightStream)
    //{
    //    ValidateWheelPositions();
    //    if (!errorState)
    //    {
    //        if (rightStream)
    //            return CopyAndPermute(upstreamColorsLeft);
    //        else
    //            return CopyAndPermute(upstreamColorsRight);
    //    }
    //    else // Pass an array of all orange to indicate an error
    //    {
    //        Color[] errorLights = new Color[upstreamColorsLeft.Length];
    //        float orangeVal = (float)(165 / 255);
    //        for (int i = 0; i < upstreamColorsLeft.Length; i++)
    //        {
    //            errorLights[i] = new Color(1.0f, orangeVal, 0.0f, 1.0f);
    //        }
    //        return errorLights;
    //    }
    //}

    //private Color[] CopyAndPermute(Color[] upstreamColors)
    //{
    //    Color[] permutedCopy = new Color[upstreamColors.Length];
    //    for (int i = 0; i < upstreamColors.Length; i++)
    //    {
    //        permutedCopy[i].r = upstreamColors[WheelPositions[i]].r;
    //        permutedCopy[i].g = upstreamColors[WheelPositions[i]].g;
    //        permutedCopy[i].b = upstreamColors[WheelPositions[i]].b;
    //        permutedCopy[i].a = upstreamColors[WheelPositions[i]].a;
    //    }
    //    return permutedCopy;
    //}

}
