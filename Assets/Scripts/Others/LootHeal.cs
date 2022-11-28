using Characters;
using UnityEngine;

namespace Others
{
    public class LootHeal : MonoBehaviour
    {
        [SerializeField] private int healthValue = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.GetComponent<Player>())
            {
                other.attachedRigidbody.GetComponent<Player>().AddHealth(healthValue);
                Destroy(gameObject);
            }
        }
    }
}