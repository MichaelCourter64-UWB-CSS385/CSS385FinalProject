using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerboxOutput : MonoBehaviour {

    [SerializeField] int[] InitialValues = new int[4];

    // Not strictly necessary, just useful in the editor for illustrating which things are connected
    // Can likely be removed after "debugging"
    [SerializeField] GameObject connection;

    public int[] PassValues()
    {
        int[] copy = new int[InitialValues.Length];
        // ensure deep copy
        for (int i = 0; i < InitialValues.Length; i++)
        {
            copy[i] = InitialValues[i];
        }
        return copy;
    }
}
