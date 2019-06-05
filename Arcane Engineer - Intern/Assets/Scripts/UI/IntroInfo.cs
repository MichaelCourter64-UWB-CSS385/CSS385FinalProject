using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroInfo : MonoBehaviour {
    [SerializeField] GameObject[] objectsToTurnOn;

	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);

            foreach (GameObject thing in objectsToTurnOn)
            {
                thing.SetActive(true);
            }

            Cursor.lockState = CursorLockMode.Locked;
        }
	}
}
