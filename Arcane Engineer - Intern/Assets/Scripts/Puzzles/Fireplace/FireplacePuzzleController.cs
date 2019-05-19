using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplacePuzzleController : MonoBehaviour
{
    [SerializeField] GameObject[] lightHolders;
    [SerializeField] Color offLight;
    [SerializeField] Color correctLight;
    [SerializeField] Color incorrectLight;
    [SerializeField] int incorrectAnimationFlashCycles;
    [SerializeField] float incorrectAnimationFlashDelay;
    [SerializeField] int solvedAnimationFlashCycles;
    [SerializeField] float solvedAnimationFlashDelay;

    const int NEUTRAL_VALUE = -2;
    const int LOOP_AROUND_VALUE = -1;
    
    Light[] lights;
    bool isInteractable = true;
    int previousButtonIndex = NEUTRAL_VALUE;
    int completionCounter = 0;

    void Start()
    {
        lights = new Light[lightHolders.Length];

        for(int i = 0; i < lightHolders.Length; i++)
        {
            lights[i] = lightHolders[i].GetComponent<Light>();
        }

        SetAllLights(offLight);
    }

    public void ReceiveButtonPress(int buttonNumber)
    {
        // If the puzzle isn't currently interactable, then:
        if (!isInteractable)
        {
            return;
        }

        // If the button sequence isn't started, then:
        if (previousButtonIndex == NEUTRAL_VALUE)
        {
            lights[buttonNumber].color = correctLight;

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
            StartCoroutine(PlaySolvedAnimtation());
        }
    }

    IEnumerator PlayIncorrectAnimation(int incorrectButtonIndex)
    {
        // The actual number frames run instead of the number of flashs.
        int totalAnimationFramesIterations = incorrectAnimationFlashCycles * 2;
        bool isRed = false;

        isInteractable = false;

        SetAllLights(offLight);

        for (int i = 0; i < totalAnimationFramesIterations; i++)
        {
            if (isRed)
            {
                lights[incorrectButtonIndex].color = offLight;
            }
            else
            {
                lights[incorrectButtonIndex].color = incorrectLight;
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
                SetAllLights(offLight);
            }
            else
            {
                SetAllLights(correctLight);
            }

            isGreen = !isGreen;

            yield return new WaitForSeconds(solvedAnimationFlashDelay);
        }
    }

    void SetAllLights(Color colorToUse)
    {
        for (int i = 0; i < lightHolders.Length; i++)
        {
            lights[i].color = colorToUse;
        }
    }
}
