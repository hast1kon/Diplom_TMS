using UnityEngine;

namespace Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject effectPrefabBullet;
        [SerializeField] private float timeToDestroy = 4f;

        private void Start()
        {
            Destroy(gameObject,timeToDestroy);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Instantiate(effectPrefabBullet, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}