using Characters;
using UnityEngine;

namespace Others
{
    public class MakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private int damageValue = 1;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody)
            {
                if (collision.rigidbody.GetComponent<Player>())
                {
                    collision.rigidbody.GetComponent<Player>().TakeDamage(damageValue);
                }
            }
        
        }
    }
}