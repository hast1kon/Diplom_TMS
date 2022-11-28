using UnityEngine;

namespace Ui
{
    public class JoystickController : MonoBehaviour
    {
        [SerializeField] private FixedJoystick joystickMove;
        [SerializeField] private FixedJoystick joystickAim;
        [SerializeField] private Animator animatorPlayer;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float aimSpeed;
        [SerializeField] private Rigidbody rbJoystickPlayer;

        private Vector3 _moveVelocity;
        private Vector3 _aimVelocity;
        
        private static readonly int IsRun = Animator.StringToHash("IsRun");

        private void Awake()
        {
            animatorPlayer = FindObjectOfType<Animator>();
            rbJoystickPlayer = FindObjectOfType<Rigidbody>();
        }

        private void Update()
        {
            MoveJoystick();
            AimJoystick();
            PlayAnimation();
        }
        
        private void MoveJoystick()
        {
            if (joystickMove.Direction != Vector2.zero)
            {
                rbJoystickPlayer.MovePosition(rbJoystickPlayer.position+transform.forward * (moveSpeed * Time.deltaTime));
            }
            if (joystickMove.Direction != Vector2.zero)
            {
                Vector3 direction = new Vector3(joystickMove.Direction.x, 0, joystickMove.Direction.y).normalized;
                rbJoystickPlayer.MoveRotation(Quaternion.Lerp(rbJoystickPlayer.rotation,Quaternion.LookRotation(direction),aimSpeed*Time.deltaTime ));
            }
        }
        private void AimJoystick()
        {
            _aimVelocity = new Vector3(joystickAim.Horizontal, 0f, joystickAim.Vertical);
            Vector3 aimInput = new Vector3(_aimVelocity.x, 0f, _aimVelocity.z).normalized;
            Vector3 lookAtPoint = transform.position + aimInput * Time.deltaTime;
            transform.LookAt(lookAtPoint);
        }
        
        private void PlayAnimation()
        {
            if (joystickMove.Direction != Vector2.zero)
            {
                animatorPlayer.SetBool(IsRun,true);
            }
            else
            {
                animatorPlayer.SetBool(IsRun,false);
            }
        }
    }
}