using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soot : ElementAffected {

    [SerializeField] float cleanSpeed;

    SpriteRenderer sootRenderer;

	// Use this for initialization
	void Start () {
        sootRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.M))
        {
            Affect(Elements.Water);
        }
    }

    public override void Affect(Elements affectingElement)
    {
        if (affectingElement == Elements.Water)
        {
            sootRenderer.color -= new Color(0, 0, 0, cleanSpeed * Time.deltaTime);
        }
    }
}
