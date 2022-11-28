using Characters;
using UnityEngine;

namespace Guns
{
    public class Knife : MonoBehaviour
    {
        [SerializeField] private Rigidbody knifeRigidbody;
        [SerializeField] private float speed;
        private void Start()
        {
            transform.rotation=Quaternion.identity;
            Transform playerTransform = FindObjectOfType<Player>().transform;
            Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
            knifeRigidbody.velocity = toPlayer * speed; 
        }
    }
}