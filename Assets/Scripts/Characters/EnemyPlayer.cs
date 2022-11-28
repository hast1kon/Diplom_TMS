using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
    public class EnemyPlayer : EnemyBase
    {
        [SerializeField] private Rigidbody enemyRigidbody;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float timeToReachSpeed = 1f;

        private NavMeshAgent _navMeshAgent;
        private Transform _target;
        private float _refreshRate = 0.25f;


        protected override void Start()
        {
            enemyRigidbody = GetComponent<Rigidbody>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _target = FindObjectOfType<Player>().transform;

            StartCoroutine(UpdatePath());
        }
        private void FixedUpdate()
        {
            FindPlayer();
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            transform.LookAt(_target.position);
        }

        private void FindPlayer()
        {
            var position = _target.position;
            Vector3 toPlayer = (position - transform.position).normalized;
            Vector3 force = enemyRigidbody.mass * (toPlayer * speed - enemyRigidbody.velocity) / timeToReachSpeed;
            enemyRigidbody.AddForce(force);
            _navMeshAgent.SetDestination(position);
        }

        IEnumerator UpdatePath()
        {
            while (_target !=null)
            {
                Vector3 targetPosition = new Vector3(_target.position.x, 0, _target.position.z);
                _navMeshAgent.SetDestination(targetPosition);
                yield return new WaitForSeconds(_refreshRate);
            }
        }
    }
}