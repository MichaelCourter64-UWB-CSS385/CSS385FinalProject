using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceButtonResetBeh : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isBeingPressed", false);
    }
}
