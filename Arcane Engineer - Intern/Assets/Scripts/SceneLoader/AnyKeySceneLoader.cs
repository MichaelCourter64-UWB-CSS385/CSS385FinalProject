using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeySceneLoader : MonoBehaviour
{
    [SerializeField] ScenesList sceneToLoad;

	// Update is called once per frame
	void Update ()
    {
		if (Input.anyKey)
        {
            SceneManager.LoadSceneAsync((int)sceneToLoad);
        }
	}
}
