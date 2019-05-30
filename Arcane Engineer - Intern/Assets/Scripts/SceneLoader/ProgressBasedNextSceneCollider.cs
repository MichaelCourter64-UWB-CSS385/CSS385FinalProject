using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressBasedNextSceneCollider : MonoBehaviour {
    [SerializeField] string tagOfPlayer;
    [SerializeField] GameObject linkToDontDestroyHolder;
    [SerializeField] ProgressionMarks[] marksToMeet;
    [SerializeField] ScenesList sceneToGoTo;

    DontDestroyReferenceHolder dontDestroyRefs;

    void Start()
    {
        dontDestroyRefs = linkToDontDestroyHolder.GetComponent<LinkToDontDestroy>().DontDestroyReferences;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag.CompareTo(tagOfPlayer) == 0)
        {
            int markedCount = 0;

            for (int i = 0; i < marksToMeet.Length; i++)
            {
                // If the progression mark is marked, then:
                if (dontDestroyRefs.ProgressionSystemInstance.IsCompleted(marksToMeet[i].ToString()))
                {
                    markedCount++;
                }
                else
                {
                    break;
                }
            }

            // If all the progression marks are marked, then:
            if (markedCount == marksToMeet.Length)
            {
                SceneManager.LoadSceneAsync((int)sceneToGoTo);
            }
            
        }
    }
}
