using System;
using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class EnemyBase : HealthCharacter
    {
        [SerializeField] private int health=1;
        public UnityEvent unityEventOnTakeDamage;
        public UnityEvent unityEventOnDie;

        public static event Action OnEnemyDeadScore;
        public void TakeDamage(int damageValue)
        {
            health -= damageValue;
            if (health<=0)
            {
                EnemyDie();
            }
            unityEventOnTakeDamage?.Invoke();
        }

        public void EnemyDie()
        {
            unityEventOnDie?.Invoke();
            Destroy(gameObject);
            OnEnemyDeadScore?.Invoke();
        }
    }
}