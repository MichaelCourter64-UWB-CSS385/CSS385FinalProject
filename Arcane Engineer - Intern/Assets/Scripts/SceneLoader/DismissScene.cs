using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DismissScene : MonoBehaviour {

    [SerializeField] ScenesList sceneToGoBackTo;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
            SceneManager.LoadSceneAsync(sceneToGoBackTo.ToString());
        }
	}
}
