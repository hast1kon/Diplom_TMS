using Characters;
using UnityEngine;

namespace Others
{
    public class MakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private int damageValue = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody?.GetComponent<Player>())
            {
                other.attachedRigidbody.GetComponent<Player>().TakeDamage(damageValue);
            }
        }
    }
}