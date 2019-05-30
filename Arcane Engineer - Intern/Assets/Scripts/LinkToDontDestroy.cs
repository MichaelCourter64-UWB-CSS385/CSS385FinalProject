using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToDontDestroy : MonoBehaviour
{
    [SerializeField] string tagToFind;

    DontDestroyReferenceHolder dontDestroyReferences;
    public DontDestroyReferenceHolder DontDestroyReferences { get { return dontDestroyReferences; } }

	// Use this for initialization
	void Awake () {
        dontDestroyReferences = GameObject.FindGameObjectWithTag(tagToFind).GetComponent<DontDestroyReferenceHolder>();
	}
}
