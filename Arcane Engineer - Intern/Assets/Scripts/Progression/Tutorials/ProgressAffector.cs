using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProgressAffector : MonoBehaviour
{
    [SerializeField] GameObject linkToDontDestroyHolder;

    protected DontDestroyReferenceHolder dontDestroyRefs;
    
    void Start()
    {
        dontDestroyRefs = linkToDontDestroyHolder.GetComponent<LinkToDontDestroy>().DontDestroyReferences;
    }
}
