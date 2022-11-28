using System;
using UnityEngine;

namespace Characters
{
    public class HealthCharacter : MonoBehaviour
    {
        private float _startingHealth;
        private float _health;
        private bool _dead;

        protected virtual void Start()
        {
            _health = _startingHealth;
        }

        public void TakeDamage(float damage, RaycastHit hit)
        {
            _health -= damage;

            if (_health <= 0 && !_dead)
            {
                Die();
            }
        }
        protected void Die()
        {
            _dead = true;
            Destroy(gameObject);
        }
    }
}