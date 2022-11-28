using System;
using System.Collections;
using Cinemachine;
using Others;
using Ui;
using UnityEngine;

namespace Characters
{
    public class Player : HealthCharacter
    {
        [SerializeField] private AudioSource addHealthSound;
        [SerializeField] private AudioSource playerDiedSound;
        [SerializeField] private UiHealth uiHealth;
        [SerializeField] private AudioSource takeDamageSound;
        [SerializeField] private DamageScreen damageScreen;
        [SerializeField] private Blink blink;
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;
        [SerializeField] private float delayInvulnerable = 1f;
        [SerializeField] private float amplitudeGain = 1f;
        [SerializeField] private float frequencyGain = 1f;
        [SerializeField] private float shakeTime = 1f;
        [SerializeField] private CinemachineVirtualCamera cmVirtualCameraMain;
        [SerializeField] private ParticleSystem damageParticle;

        private Camera _viewCameraRay;

        private bool _immortal;

        public static event Action OnPlayerDead;

        protected override void Start()
        {
            base.Start();
            uiHealth.Setup(maxHealth);
            uiHealth.DisplayHealth(health);
        }
    
        public void TakeDamage(int damageValue)
        {
            if (_immortal==false)
            {
                health -= damageValue;
                if (health<=0)
                {
                    health = 0;
                    PlayerDie();
                }

                _immortal = true;
                Invoke("StopImmortal",delayInvulnerable);
            
                takeDamageSound.Play();
                uiHealth.DisplayHealth(health);
                damageScreen.StartEffect();
                damageParticle.Play();
                blink.StartBlink();

                StartCoroutine(StartShake());
            }
        }

        public IEnumerator StartShake()
        {
            cmVirtualCameraMain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitudeGain;
            cmVirtualCameraMain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequencyGain;
            yield return new WaitForSeconds(shakeTime);
            cmVirtualCameraMain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
            cmVirtualCameraMain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
        }
    
        private void StopImmortal()
        {
            _immortal = false;
        }

        public void AddHealth(int healthValue)
        {
            health += healthValue;
            if (health>maxHealth)
            {
                health = maxHealth;
            }
            addHealthSound.Play();
            uiHealth.DisplayHealth(health);
        }

        public void PlayerDie()
        {
            playerDiedSound.Play();
            if (OnPlayerDead != null) 
                OnPlayerDead.Invoke();
            damageScreen.StopEffect();
        }
    }
}
