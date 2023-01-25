using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace EntityScripts.Enemy_Specific
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class TriggerPlayerOnRange : MonoBehaviour
    {
        public UnityEvent playerEntersAttackRange;
        public UnityEvent playerExitsAttackRange;

        [SerializeField] private float rangoDeAtaque;
        private NavMeshAgent _agent;
        private float _distance;

        private bool _wasLastFrameInsideRangoDeAtaque;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!_agent.hasPath) return;
            _distance = _agent.remainingDistance;
            if (float.IsInfinity(_distance)) _distance = 10000f;
            var insideRangoDeAtaque = _distance <= rangoDeAtaque;

            if (!_wasLastFrameInsideRangoDeAtaque && insideRangoDeAtaque)
                playerEntersAttackRange.Invoke();
            else if (_wasLastFrameInsideRangoDeAtaque && !insideRangoDeAtaque)
                playerExitsAttackRange.Invoke();

            _wasLastFrameInsideRangoDeAtaque = insideRangoDeAtaque;
        }
    }
}