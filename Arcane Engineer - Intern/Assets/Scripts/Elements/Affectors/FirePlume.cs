using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlume : MonoBehaviour
{
    [SerializeField] string affectedTag;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == affectedTag)
        {
            other.GetComponent<ElementAffected>().Affect(Elements.Fire);
        }
    }
}
