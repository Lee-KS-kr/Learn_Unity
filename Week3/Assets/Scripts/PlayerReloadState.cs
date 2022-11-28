using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReloadState : StateMachineBehaviour
{
    private readonly int hashIsBulletEmpty = Animator.StringToHash("isBulletEmpty");
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(hashIsBulletEmpty, false);
    }
}
