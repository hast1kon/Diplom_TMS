using Characters;
using Guns;
using UnityEngine;

namespace Others
{
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        public EnemyBase enemyHealth;
        public bool dieOnAnyCollision;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody)
            {
                if (other.attachedRigidbody.GetComponent<Bullet>())
                {
                    enemyHealth.TakeDamage(1);
                }
            }

            if (dieOnAnyCollision==true)
            {
                if (other.isTrigger==false)
                {
                    enemyHealth.TakeDamage(1000);
                }
            }
        }
    }
}