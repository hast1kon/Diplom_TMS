using UnityEngine;

namespace Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform spawn;
        [SerializeField] private float bulletSpeed=10f;
        [SerializeField] private float shotPeriod=0.2f;
        [SerializeField] private AudioSource shotSound;
        [SerializeField] private GameObject flash;
        [SerializeField] private float delayFlash = 0.12f;
        [SerializeField] private ParticleSystem shellparticle;
        [SerializeField] private FixedJoystick joystickShot;

        private float _timer;
    
        private void Start()
        {
            HideFlash();
        }

        private void Update()
        {
            ShotMouse();
            //ShotJoystick();
        }

        private void ShotJoystick()
        {
            _timer += Time.deltaTime;
            if (_timer > shotPeriod)
            {
                if (joystickShot.Horizontal >=0.5f || joystickShot.Vertical >=0.5f)
                {
                    _timer = 0f;
                    Shot();
                    shellparticle.Play();
                }
                else if(joystickShot.Horizontal <=-0.5f || joystickShot.Vertical <=-0.5f)
                {
                    _timer = 0f;
                    Shot();
                    shellparticle.Play();
                }
            }
        }

        private void ShotMouse()
        {
            _timer += Time.deltaTime;
            if (_timer > shotPeriod)
            {
                if (Input.GetMouseButton(0))
                {
                    _timer = 0f;
                    shellparticle.Play();
                    Shot();
                }
            }
        }

        public virtual void Shot()
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject();

            if (bullet!=null)
            {
                bullet.transform.position = spawn.position;
                bullet.transform.rotation = spawn.rotation;
                bullet.GetComponent<Rigidbody>().velocity = spawn.forward * bulletSpeed;
                bullet.SetActive(true);
                shotSound.Play();
                flash.SetActive(true);
                Invoke("HideFlash",delayFlash);
            }
        }
        public void HideFlash()
        {
            flash.SetActive(false);
        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public virtual void AddBullets(int addNumberOfBullets)
        {
        
        }
    }
}
