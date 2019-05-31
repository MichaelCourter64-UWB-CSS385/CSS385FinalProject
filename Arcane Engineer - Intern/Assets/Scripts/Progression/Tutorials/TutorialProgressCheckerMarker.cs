using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialProgressCheckerMarker : ProgressChecker, ProgressionUser
{
    [SerializeField] ProgressionMarks markToBaseCompletionOn;

    Toggle checkMark;

	// Use this for initialization
	protected override void ForAwake ()
    {
        checkMark = GetComponent<Toggle>();
	}

    protected override void ReceiveProgressionUpdate()
    {
        // If the given mark is marked, then:
        if (!checkMark.isOn && dontDestroyRefs.ProgressionSystemInstance.IsCompleted(markToBaseCompletionOn.ToString()))
        {
            checkMark.isOn = true;
        }
    }
}
