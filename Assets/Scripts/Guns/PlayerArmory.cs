using UnityEngine;

namespace Guns
{
    public class PlayerArmory : MonoBehaviour
    {
        [SerializeField] private Gun[] guns;
        [SerializeField] private int currentGunIndex;
        [SerializeField] private AudioSource addAmmo;

        private void Start()
        {
            TakeGunByIndex(currentGunIndex);
        }

        public void TakeGunByIndex(int gunIndex)
        {
            currentGunIndex = gunIndex;
            for (int i = 0; i < guns.Length; i++)
            {
                if (i==gunIndex)
                {
                    guns[i].gameObject.SetActive(true);
                }
                else
                {
                    guns[i].gameObject.SetActive(false);
                }
            }
        }

        public void AddBullets(int gunIndex,int numberOfBullets)
        {
            guns[gunIndex].AddBullets(numberOfBullets);
            addAmmo.Play();
        }
    }
}