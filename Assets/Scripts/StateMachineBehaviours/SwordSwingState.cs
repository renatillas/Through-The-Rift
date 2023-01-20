using System.Linq;
using UnityEngine;

namespace StateMachineBehaviours
{
    public class SwordSwingState : StateMachineBehaviour
    {
        private ParticleSystem _particleSystem;
        private Collider _swordTriggerCollider;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _particleSystem = animator.GetComponentInChildren<ParticleSystem>();
            _swordTriggerCollider = animator
                .GetComponentsInChildren<BoxCollider>()
                .First(boxCollider => boxCollider.CompareTag("Sword"));
            _swordTriggerCollider.enabled = true;
            _particleSystem.Play();
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _swordTriggerCollider.enabled = false;
            _particleSystem.Stop();
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}