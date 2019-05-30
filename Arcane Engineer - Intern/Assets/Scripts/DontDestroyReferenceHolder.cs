using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyReferenceHolder : MonoBehaviour
{
    [SerializeField] GameObject progressionHolder;

    ProgressionSystem progressionSystemInstance;
    public ProgressionSystem ProgressionSystemInstance { get { return progressionSystemInstance; } }

    void Awake()
    {
        progressionSystemInstance = progressionHolder.GetComponent<ProgressionSystem>();
    }
}
