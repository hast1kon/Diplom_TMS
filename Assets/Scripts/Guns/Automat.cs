using UnityEngine;
using UnityEngine.UI;

namespace Guns
{
    public class Automat: Gun
    {
        [SerializeField] private int numberOfBullets;
        [SerializeField] private Text bulletsText;
        [SerializeField] private PlayerArmory playerArmory;

        public override void Shot()
        {
            base.Shot();
            numberOfBullets -= 1;
            UpdateText();
            if (numberOfBullets==0)
            {
                playerArmory.TakeGunByIndex(0);
            }
        }

        public override void Activate()
        {
            base.Activate();
            bulletsText.enabled = true;
            UpdateText();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            bulletsText.enabled = false;
        }

        public void UpdateText()
        {
            bulletsText.text = ": " + numberOfBullets.ToString();
        }

        public override void AddBullets(int addNumberOfBullets)
        {
            base.AddBullets(addNumberOfBullets);
            numberOfBullets += addNumberOfBullets;
            UpdateText();
            playerArmory.TakeGunByIndex(1);
        }
    }
}