using Characters;
using Guns;
using UnityEngine;

namespace Others
{
    public class TakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private EnemyBase enemyHealth;
        public bool dieOnAnyCollision;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody?.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }

            if (dieOnAnyCollision)
            {
                enemyHealth.TakeDamage(1000);
            }
        }
    }
}