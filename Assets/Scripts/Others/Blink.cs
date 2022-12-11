using System.Collections;
using UnityEngine;

namespace Others
{
    public class Blink : MonoBehaviour
    {
        [SerializeField] private Renderer[] Renderers;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        public void StartBlink()
        {
            StartCoroutine(BlinkEffect());
        }

        public IEnumerator BlinkEffect()
        {
            for (float t = 0; t < 1; t+=Time.deltaTime)
            {
                for (int i = 0; i < Renderers.Length; i++)
                {
                    for (int m = 0; m < Renderers[i].materials.Length; m++)
                    {
                        Renderers[i].materials[m].SetColor(EmissionColor, new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
                    }
                }
                yield return null;
            }
        }
    }
}