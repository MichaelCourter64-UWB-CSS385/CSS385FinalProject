using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStream : MonoBehaviour {

    [SerializeField] string affectedTag;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == affectedTag)
        {
            other.GetComponent<ElementAffected>().Affect(Elements.Water);
        }
    }
}
