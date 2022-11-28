using Characters;
using UnityEngine;

namespace Guns
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float rotationSpeed=1f;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<Player>().transform;
        }

        private void Update()
        {
            transform.position += Time.deltaTime * transform.forward * speed;
            Vector3 toPlayer = _playerTransform.position - transform.position;
            Quaternion targetRotation=Quaternion.LookRotation(toPlayer,Vector3.forward);

            transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime*rotationSpeed);
        }
    }
}