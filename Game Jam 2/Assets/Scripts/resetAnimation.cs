using UnityEngine;

public class resetAnimation : StateMachineBehaviour

{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("whichAnimation", 0);
    }
}

