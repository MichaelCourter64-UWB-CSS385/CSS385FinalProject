using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SootSetCleaningTracker : ProgressAffector {
    [SerializeField] GameObject[] sootSpotHolders;
    [SerializeField] float cleanEnoughAlpha;
    [SerializeField] ProgressionMarks markToMarkWhenPreReqsMet;

    SpriteRenderer[] sootSprites;

    void Awake()
    {
        sootSprites = new SpriteRenderer[sootSpotHolders.Length];

        for (int i = 0; i < sootSpotHolders.Length; i++)
        {
            sootSprites[i] = sootSpotHolders[i].GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update () {
        bool isCleanEnough = true;

        for (int i = 0; isCleanEnough && i < sootSprites.Length; i++)
        {
            if (sootSprites[i].color.a > cleanEnoughAlpha)
            {
                isCleanEnough = false;
                break;
            }
        }

        if (isCleanEnough)
        {
            dontDestroyRefs.ProgressionSystemInstance.Completed(markToMarkWhenPreReqsMet.ToString());

            enabled = false;
        }
	}
}
