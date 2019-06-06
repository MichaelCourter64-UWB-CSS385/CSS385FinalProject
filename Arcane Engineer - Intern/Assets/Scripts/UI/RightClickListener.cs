using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MARK: - Class
public class RightClickListener : ProgressAffector
{
	// MARK: Properites
	[SerializeField] GameObject selectionWheel;
    [SerializeField] GameObject[] elementButtonHolders;

	public bool isRightClicking = false;

	// MARK: Life Cycle
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.None;

            isRightClicking = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            foreach (GameObject button in elementButtonHolders)
            {
                button.GetComponent<OnHighlight>().CheckElementSelection();
            }

            isRightClicking = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

   		if (isRightClicking)
        {
            if (!dontDestroyRefs.ProgressionSystemInstance.IsCompleted(ProgressionMarks.FirstOpenSelectionWheel.ToString()) &&
                dontDestroyRefs.ProgressionSystemInstance.IsCompleted(ProgressionMarks.CleanedDoorSoot.ToString()))
            {
                dontDestroyRefs.ProgressionSystemInstance.Completed(ProgressionMarks.FirstOpenSelectionWheel.ToString());
            }

			// Show selection wheel
        	selectionWheel.SetActive(true);
        	Cursor.visible = true;
		}
        else
        {
            if (!dontDestroyRefs.ProgressionSystemInstance.IsCompleted(ProgressionMarks.FirstElementSelection.ToString()) &&
                dontDestroyRefs.ProgressionSystemInstance.IsCompleted(ProgressionMarks.FirstOpenSelectionWheel.ToString()))
            {
                dontDestroyRefs.ProgressionSystemInstance.Completed(ProgressionMarks.FirstElementSelection.ToString());
            }

            // Hide selection wheel
            selectionWheel.SetActive(false);
        	Cursor.visible = false;
		}
	}
}
