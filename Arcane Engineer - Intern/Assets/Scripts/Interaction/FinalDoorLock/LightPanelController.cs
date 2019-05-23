using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPanelController : MonoBehaviour {

    [SerializeField] bool isOn;
    [SerializeField] bool isStartpoint;
    [SerializeField] bool isEndpoint;
    [SerializeField] bool rightStream;                         // Tracks direction of power flow for this panel 
    [SerializeField] GameObject upstreamObject;                // Previous object in the "chain" that feeds into this panel
    [SerializeField] GameObject[] lights = new GameObject[4];  // Connected to child light objects' renderers to avoid 
    [SerializeField] Material[] mats = new Material[6];        // Array of possible materials to use

    private int[] settings;                                    // Array storing the indicator light current settings (color arrangegment)

    //// Old Version
    //private Color[] lightColors;                             // Array containing color values of lights


    void Start()
    {
        isOn = false;
        isStartpoint = false;
        isEndpoint = false;
        settings = new int[lights.Length];
    }

    public void GetUpstreamValues()
    {
        if (upstreamObject.GetComponent<DialController>() != null)
            settings = upstreamObject.GetComponent<DialController>().PassValues(rightStream);
        if (upstreamObject.GetComponent<LightPanelController>() != null)
            settings = upstreamObject.GetComponent<LightPanelController>().PassValues();
        if (upstreamObject.GetComponent<PowerboxOutput>() != null)
            settings = upstreamObject.GetComponent<PowerboxOutput>().PassValues();
    }

    // Returns a copy of the array of current indicator light settings
    public int[] PassValues()
    {
        int[] copy = new int[settings.Length];
        // ensure deep copy
        Debug.Log("In LightPanelController - PassValues() - " + this.transform.name);
        for (int i = 0; i < settings.Length; i++)
        {
            copy[i] = settings[i];
            Debug.Log(copy[i]);
        }
        return copy;
    }

    // Illuminates the indicator lights based on the current settings the panel received
    public void Activate()
    {
        this.GetUpstreamValues();
        isOn = true;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Renderer>().material = mats[settings[i]];
        }
    }

    public void Deactivate()
    {
        isOn = false;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Renderer>().material = mats[0];
        }
    }

    ////-------------------------------------- OLD VERSION (Color) --------------------------------------------
    ////
    ////
    //public void GetUpstreamValues()
    //{
    //    lightColors = upstreamObject.GetComponent<DialController>().PassValues(rightStream);
    //}

    //public Color[] PassValues()
    //{
    //    Color[] copy = new Color[lightColors.Length];
    //    // ensure deep copy
    //    for (int i = 0; i < lightColors.Length; i++)
    //    {
    //        copy[i].r = lightColors[i].r;
    //        copy[i].g = lightColors[i].g;
    //        copy[i].b = lightColors[i].b;
    //        copy[i].a = lightColors[i].a;
    //    }
    //    return copy;
    //}

}
