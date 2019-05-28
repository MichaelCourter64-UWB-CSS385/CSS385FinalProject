using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// MARK: - Class
public class SceneLoader : MonoBehaviour {
    [SerializeField] ScenesList elementMeterScene;
    [SerializeField] ScenesList elementScene;
    [SerializeField] ScenesList interactionScene;
    [SerializeField] ScenesList finalPuzzleScene;
    [SerializeField] ScenesList selectionWheelScene;

    // MARK: Properties
    

	// MARK: Life Cycle
	void Awake () {
		
	}

	void Update () {
		
	}

	// MARK: Private


	// MARK: Public
	public void loadElementalMetersUI() {
		SceneManager.LoadSceneAsync(elementMeterScene.ToString());
	}

	public void loadInteractionPrototype() {
		SceneManager.LoadSceneAsync(elementScene.ToString());
	}

    public void loadElementPrototype()
    {
        SceneManager.LoadSceneAsync(interactionScene.ToString());
    }

	public void loadFinalPuzzle() {
		SceneManager.LoadSceneAsync(finalPuzzleScene.ToString());
	}

	public void loadSelectionWheel() {
		SceneManager.LoadSceneAsync(selectionWheelScene.ToString());
	}

}
