using System.Collections.Generic;
using UnityEngine;

namespace Ui
{
    public class UiHealth : MonoBehaviour
    {
        [SerializeField] private GameObject healthIconPrefab;
        [SerializeField] private List<GameObject> healthIcons;

        public void Setup(int maxHealth)
        {
            for (int i = 0; i < maxHealth; i++)
            {
                GameObject newIcon = Instantiate(healthIconPrefab, transform);
                healthIcons.Add(newIcon);
            }
        }

        public void DisplayHealth(int health)
        {
            for (int i = 0; i < healthIcons.Count; i++)
            {
                if (i<health)
                {
                    healthIcons[i].SetActive(true);
                }
                else
                {
                    healthIcons[i].SetActive(false);
                }
            }
        }
    }
}