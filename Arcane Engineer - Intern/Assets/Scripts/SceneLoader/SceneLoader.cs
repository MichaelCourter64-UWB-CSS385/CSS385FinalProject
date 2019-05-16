using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// MARK: - Class
public class SceneLoader : MonoBehaviour {
	// MARK: Properties


	// MARK: Life Cycle
	void Start () {
		
	}

	void Update () {
		
	}

	// MARK: Private


	// MARK: Public
	public void loadElementalMetersUI() {
		SceneManager.LoadScene(0);
	}

	public void loadPlayerMovement() {
		SceneManager.LoadScene(1);
	}

	public void loadFinalPuzzle() {
		SceneManager.LoadScene(2);
	}

	public void loadSelectionWheel() {
		SceneManager.LoadScene(4);
	}

}
