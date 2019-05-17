using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MARK: - Class
public class LayoutController : MonoBehaviour {
	// MARK: Properties
	Image backgroundImage;

	// MARK: Life Cycle
	void Start () {
		backgroundImage = GameObject.FindGameObjectWithTag("BackgroundPanel").GetComponent<Image>();

		Color color = backgroundImage.color;
        color.a = 1;
        backgroundImage.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
