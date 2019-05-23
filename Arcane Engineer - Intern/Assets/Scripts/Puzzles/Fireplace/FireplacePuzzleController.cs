using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplacePuzzleController : MonoBehaviour
{
    [SerializeField] GameObject[] lightHolders;
    [SerializeField] Color offLight;
    [SerializeField] Color correctLight;
    [SerializeField] Color incorrectLight;
    [SerializeField] Material offMat;
    [SerializeField] Material correctMat;
    [SerializeField] Material incrorrectMat;
    [SerializeField] GameObject progressionSystemHolder;
    [SerializeField] int incorrectAnimationFlashCycles;
    [SerializeField] float incorrectAnimationFlashDelay;
    [SerializeField] int solvedAnimationFlashCycles;
    [SerializeField] float solvedAnimationFlashDelay;

    const int NEUTRAL_VALUE = -2;
    const int LOOP_AROUND_VALUE = -1;
    
    Light[] lights;
    MeshRenderer[] lightRends;
    bool isInteractable = true;
    int previousButtonIndex = NEUTRAL_VALUE;
    int completionCounter = 0;
    ProgressionSystem progressionSystem;

    void Start()
    {
        lights = new Light[lightHolders.Length];
        lightRends = new MeshRenderer[lightHolders.Length];
        progressionSystem = progressionSystemHolder.GetComponent<ProgressionSystem>();

        for(int i = 0; i < lightHolders.Length; i++)
        {
            lights[i] = lightHolders[i].GetComponent<Light>();
            lightRends[i] = lightHolders[i].GetComponent<MeshRenderer>();
        }

        SetAllLights(offLight, offMat);
    }

    public void ReceiveButtonPress(int buttonNumber)
    {
        // If the puzzle isn't currently interactable, then:
        if (!isInteractable)
        {
            return;
        }
        //Debug.Log("received at " + Time.time);
        // If the button sequence isn't started, then:
        if (previousButtonIndex == NEUTRAL_VALUE)
        {
            lights[buttonNumber].color = correctLight;
            lightRends[buttonNumber].material = correctMat;

            previousButtonIndex = buttonNumber;
        }
        else
        {
            // If the previously pressed button is the last button in the array, then:
            if (previousButtonIndex == lights.Length - 1)
            {
                // Loop it around to just before the first index.
                previousButtonIndex = LOOP_AROUND_VALUE;
            }

            // If the pressed button isn't the next one in the sequence, then:
            if (buttonNumber != previousButtonIndex + 1)
            {
                StartCoroutine(PlayIncorrectAnimation(buttonNumber));

                previousButtonIndex = NEUTRAL_VALUE;
                completionCounter = 0;
            }
            // Else, the button is the correct one:
            else
            {
                lights[buttonNumber].color = correctLight;
                lightRends[buttonNumber].material = correctMat;

                previousButtonIndex = buttonNumber;
                completionCounter++;

                CheckIsCompleted();
            }
        }
    }

    void CheckIsCompleted()
    {
        if(completionCounter == lights.Length - 1)
        {
            progressionSystem.Completed(ProgressionMarks.FireplaceFixed.ToString());

            StartCoroutine(PlaySolvedAnimtation());
        }
    }

    IEnumerator PlayIncorrectAnimation(int incorrectButtonIndex)
    {
        // The actual number frames run instead of the number of flashs.
        int totalAnimationFramesIterations = incorrectAnimationFlashCycles * 2;
        bool isRed = false;

        isInteractable = false;

        SetAllLights(offLight, offMat);

        for (int i = 0; i < totalAnimationFramesIterations; i++)
        {
            if (isRed)
            {
                lights[incorrectButtonIndex].color = offLight;
                lightRends[incorrectButtonIndex].material = offMat;
            }
            else
            {
                lights[incorrectButtonIndex].color = incorrectLight;
                lightRends[incorrectButtonIndex].material = incrorrectMat;
            }

            isRed = !isRed;

            // If this is the last animation frame, then:
            if (i != totalAnimationFramesIterations - 1)
            { 
                yield return new WaitForSeconds(incorrectAnimationFlashDelay);
            }
        }

        isInteractable = true;
    }

    IEnumerator PlaySolvedAnimtation()
    {
        // The actual number frames run instead of the number of flashs.
        int totalAnimationFramesIterations = solvedAnimationFlashCycles * 2;
        bool isGreen = true;

        isInteractable = false;

        for (int i = 0; i < totalAnimationFramesIterations; i++)
        {
            if (isGreen)
            {
                SetAllLights(offLight, offMat);
            }
            else
            {
                SetAllLights(correctLight, correctMat);
            }

            isGreen = !isGreen;

            yield return new WaitForSeconds(solvedAnimationFlashDelay);
        }
    }

    void SetAllLights(Color colorToUse, Material materialToUse)
    {
        for (int i = 0; i < lightHolders.Length; i++)
        {
            lights[i].color = colorToUse;
            lightRends[i].material = materialToUse;
        }
    }
}
