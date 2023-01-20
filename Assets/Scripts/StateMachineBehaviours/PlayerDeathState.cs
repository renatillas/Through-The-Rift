using UnityEngine;

namespace StateMachineBehaviours
{
    public class PlayerDeathState : StateMachineBehaviour
    {
        [SerializeField] private GameObject deathParticle;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Time.timeScale = 0.3f;
            Instantiate(deathParticle, animator.transform.position - Camera.main.transform.forward * 5,
                Quaternion.Euler(0, 0, 0));
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Destroy(animator.gameObject);
        }
    }
}