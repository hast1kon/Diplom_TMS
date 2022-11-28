using UnityEngine;

namespace Guns
{
    public class LootBullets : MonoBehaviour
    {
        [SerializeField] private int gunIndex;
        [SerializeField] private int numberOfBullets;
        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.GetComponent<PlayerArmory>())
            {
                other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(gunIndex,numberOfBullets);
                Destroy(gameObject);
            }
        }
    }
}