using UnityEngine;

namespace Others
{
    public class SetTriggerEveryNSeconds : MonoBehaviour
    {
        [SerializeField] private float period = 7f;
        [SerializeField] private Animator animator;
        private float _timer;

        public string triggerName = "Attack";

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer>period)
            {
                _timer = 0;
                animator.SetTrigger(triggerName);
            }
        }
    }
}