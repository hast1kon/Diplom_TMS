using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Others
{
    public class DamageScreen : MonoBehaviour
    {
        [SerializeField] private Image damageImage;

        public void StartEffect()
        {
            if (ShowEffect() !=null)
            {
                StartCoroutine(ShowEffect());
            }
        }

        public void StopEffect()
        {
            StopCoroutine(ShowEffect());
        }

        public IEnumerator ShowEffect()
        {
            damageImage.enabled = true;
            for (float t = 1; t > 0f; t-=Time.deltaTime)
            {
                damageImage.color = new Color(1, 0, 0, t);
                yield return null;
            }
            damageImage.enabled = false;
        }
    }
}