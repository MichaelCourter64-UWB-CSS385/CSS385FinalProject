using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialProgressChecker : MonoBehaviour
{
    [SerializeField] GameObject linkToDontDestroyHolder;
    [SerializeField] ProgressionMarks markToBaseCompletionOn;

    DontDestroyReferenceHolder dontDestroyRefs;
    Toggle checkMark;

	// Use this for initialization
	void Awake () {
        checkMark = GetComponent<Toggle>();

        ProgressionSystem.ProgressionMarkMarked.AddListener(ReceiveProgressionUpdate);
	}

    void Start()
    {
        dontDestroyRefs = linkToDontDestroyHolder.GetComponent<LinkToDontDestroy>().DontDestroyReferences;
    }

    void OnDestroy()
    {
        ProgressionSystem.ProgressionMarkMarked.RemoveListener(ReceiveProgressionUpdate);
    }

    void ReceiveProgressionUpdate()
    {
        // If the given mark is marked, then:
        if (!checkMark.isOn && dontDestroyRefs.ProgressionSystemInstance.IsCompleted(markToBaseCompletionOn.ToString()))
        {
            checkMark.isOn = true;
        }
    }
}
