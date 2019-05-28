using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroInfo : MonoBehaviour {
    [SerializeField] GameObject[] objectsToTurnOn;
    
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);

            foreach (GameObject thing in objectsToTurnOn)
            {
                thing.SetActive(true);
            }
        }
	}
}
