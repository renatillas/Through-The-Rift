using UnityEngine;

namespace StateMachineBehaviours
{
    public class EnemyDeathState : StateMachineBehaviour
    {
        [SerializeField] private GameObject deathParticle;

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Instantiate(deathParticle, animator.transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(animator.gameObject);
        }
    }
}