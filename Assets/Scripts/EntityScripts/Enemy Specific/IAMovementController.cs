using UnityEngine;
using UnityEngine.AI;

namespace EntityScripts.Enemy_Specific
{
    public class IAMovementController : MonoBehaviour
    {
        [SerializeField] private float rangoDeBronca;
        private NavMeshAgent _agent;
        private Animator _animator;
        private bool _canMove;
        private Transform _transformDestination;

        private void Awake()
        {
            _transformDestination = GameObject.FindWithTag("Player").transform;
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.isStopped = false;
        }

        private void Start()
        {
            _canMove = true;
            _agent.destination = _transformDestination.position;
        }


        private void Update()
        {
            if (_transformDestination == null) return;
            _agent.destination = _transformDestination.position;
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
            if (_transformDestination == null || !_agent.hasPath) return false;
            var realDistance = _agent.remainingDistance;
            return realDistance < rangoDeBronca;
        }
    }
}