using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPanelController : MonoBehaviour {
    // Boolean for tracking/controlling whether this panel is on
    [SerializeField] bool isOn;
    [SerializeField] bool isStartpoint;
    [SerializeField] bool isEndpoint;

    // Array containing color values of lights
    // private Color[] lightColors = new Color[4];
    private Color[] lightColors;

    // Previous object in the "chain" that feeds into this panel
    [SerializeField] GameObject upstreamObject;

    void Start()
    {
        isOn = false;
        isStartpoint = false;
        isEndpoint = false;
    }

    public void GetUpstreamValues()
    {
        lightColors = upstreamObject.GetComponent<DialController>().PassValues();
    }

    public Color[] PassValues()
    {
        Color[] copy = new Color[lightColors.Length];
        // ensure deep copy
        for (int i = 0; i < lightColors.Length; i++)
        {
            copy[i].r = lightColors[i].r;
            copy[i].g = lightColors[i].g;
            copy[i].b = lightColors[i].b;
            copy[i].a = lightColors[i].a;
        }
        return copy;
    }

    void TurnOnLights()
    {
        isOn = true;
        // Set light GameObject colors here
    }

}
