using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelValveTurnBeh : StateMachineBehaviour
{
    [SerializeField] bool turnClockwise;
    [SerializeField] float amountToRotate;
    [SerializeField] float speed;
    [SerializeField] string wheelTurnAnimationTriggerName;

    float totalRotation;
    int direction;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("reset state");
        //Debug.Log("amntToRot. " + amountToRotate);
        totalRotation = 0;
        direction = turnClockwise ? -1 : 1;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(totalRotation < amountToRotate)
        {
            animator.transform.rotation *= Quaternion.Euler(speed * direction * Time.deltaTime, 0, 0);

            totalRotation += speed * Time.deltaTime;
            Debug.Log("total rot. " + totalRotation);
            //Debug.Log("amount added " + speed * direction * Time.deltaTime);
            //Debug.Log("new transform rotation " + animator.transform.eulerAngles);
        }
        else
        {
            Debug.Log("STOP at " + Time.time);
            animator.SetBool(wheelTurnAnimationTriggerName, false);
        }
    }
}
