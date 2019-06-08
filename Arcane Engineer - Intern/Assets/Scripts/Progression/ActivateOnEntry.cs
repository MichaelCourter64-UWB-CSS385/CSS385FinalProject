using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnEntry : MonoBehaviour {
    [SerializeField] string tagToCheck;
    [SerializeField] GameObject objectToActivate;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo(tagToCheck) == 0)
        {
            objectToActivate.SetActive(true);
        }
    }
}
