using UnityEngine;
using UnityEngine.UI;

namespace Guns
{
    public class Automat: Gun
    {
        [SerializeField] private int numberOfBullets;
        [SerializeField] private Text bulletsText;
        [SerializeField] private PlayerArmory playerArmory;
        [SerializeField] private GameObject bulletsPanel;

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
            bulletsPanel.SetActive(true);
            bulletsText.enabled = true;
            UpdateText();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            bulletsPanel.SetActive(false);
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