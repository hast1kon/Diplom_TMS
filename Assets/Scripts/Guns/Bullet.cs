using UnityEngine;

namespace Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject effectPrefabBullet;

        private void OnCollisionEnter(Collision collision)
        {
            Instantiate(effectPrefabBullet, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}