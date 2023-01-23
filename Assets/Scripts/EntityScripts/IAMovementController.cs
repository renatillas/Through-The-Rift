using UnityEngine;
using UnityEngine.AI;

namespace EntityScripts
{
    public class IAMovementController : MonoBehaviour
    {
        [SerializeField] private float playerRange;
        private NavMeshAgent _agent;
        private Animator _animator;
        private bool _canMove;
        private Transform _transformDestination;

        private void Awake()
        {
            _transformDestination = GameObject.FindWithTag("Player").transform;
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _canMove = true;
            _agent = GetComponent<NavMeshAgent>();
            _agent.destination = _transformDestination.position;
        }


        private void Update()
        {
            if (_canMove && IsPlayerOnRange())
            {
                _agent.isStopped = false;
                _animator.SetBool("Running", true);
            }
            else
            {
                _agent.isStopped = true;
                _animator.SetBool("Running", false);
            }
        }

        public void StopMoving()
        {
            _canMove = false;
        }

        private bool IsPlayerOnRange()
        {
            if (_transformDestination == null) return false;
            var realDistance = Vector3.Distance(_transformDestination.position, transform.position);
            return realDistance < playerRange;
        }
    }
}