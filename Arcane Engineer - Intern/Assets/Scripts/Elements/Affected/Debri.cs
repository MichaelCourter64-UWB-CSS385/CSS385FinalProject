using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debri : ElementAffected {
    public override void Affect(Elements affectingElement)
    {
        if (affectingElement == Elements.Fire)
        {
            gameObject.SetActive(false);
        }
    }
}
