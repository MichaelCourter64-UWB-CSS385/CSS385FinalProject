using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soot : ElementAffected {

    [SerializeField] float cleanSpeed;

    SpriteRenderer sootRenderer;

	// Use this for initialization
	void Awake () {
        sootRenderer = GetComponent<SpriteRenderer>();
	}
	
    public override void Affect(Elements affectingElement)
    {
        if (affectingElement == Elements.Water)
        {
            sootRenderer.color -= new Color(0, 0, 0, cleanSpeed * Time.deltaTime);
        }
    }
}
