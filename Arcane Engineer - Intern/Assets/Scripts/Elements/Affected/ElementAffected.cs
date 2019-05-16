using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementAffected : MonoBehaviour {
    public abstract void Affect(Elements affectingElement);
}
