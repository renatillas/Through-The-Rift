using UnityEngine;

namespace src
{
    public class SwordManager : MonoBehaviour
    {
        [SerializeField] private float weaponDelay;
        [SerializeField] private Animator animator;

        private float _internalTimer;
        private Collider _swordCollider;
        private static readonly int SwordAttack = Animator.StringToHash("SwordAttack");

        private void Awake()
        {
            _swordCollider = GetComponent<Collider>();
        }

        private void Start()
        {
            _internalTimer = 0;
        }

        private void Update()
        {
            _internalTimer -= Time.deltaTime;
            if (_internalTimer < 0f)
            {
                StartAttack();
            }
        }

        private void StartAttack()
        {
            _internalTimer = weaponDelay;
            _swordCollider.enabled = true;
            animator.SetTrigger(SwordAttack);
        }

        public void EndAttack()
        {
            _swordCollider.enabled = false;
        }

    }
}