using UnityEngine;

namespace StateMachineBehaviours
{
    public class EnemyDeathState : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Destroy(animator.gameObject);
        }
    }
}