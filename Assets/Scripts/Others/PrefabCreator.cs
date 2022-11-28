using UnityEngine;

namespace Others
{
    public class PrefabCreator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform spawn;
    
        public void Create()
        {
            Instantiate(prefab,spawn.position,spawn.rotation);
        }
    }
}