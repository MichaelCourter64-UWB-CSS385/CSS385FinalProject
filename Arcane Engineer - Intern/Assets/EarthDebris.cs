using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDebris : ElementAffected {
    public override void Affect(Elements affectingElement) {
        if (affectingElement == Elements.Earth) {
			Vector3 pos = gameObject.transform.position;
			pos.y -= 0.05f;
			gameObject.transform.position = pos;
        }
    }
}
