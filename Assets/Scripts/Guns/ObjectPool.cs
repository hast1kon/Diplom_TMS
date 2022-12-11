using System.Collections.Generic;
using UnityEngine;

namespace Guns
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        private List<GameObject> pooledObjects = new List<GameObject>();
        public static ObjectPool Instance;
        private int amountPool = 10;
        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            for (int i = 0; i < amountPool; i++)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }
}