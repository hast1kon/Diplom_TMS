using UnityEngine;

namespace Characters
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Animator animatorMainPlayer;
        [SerializeField] private Rigidbody _myRigidbody;
        [SerializeField] private Camera _viewCameraRay;
        
        private Vector3 _velocity;
        private static readonly int IsRun = Animator.StringToHash("IsRun");
    
        void Start()
        {
            _myRigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 mVelocity)
        {
            _velocity = mVelocity;
        
        }
        public void LookAt (Vector3 lookPoint)
        {
            Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
            transform.LookAt(heightCorrectedPoint);
        }
        void FixedUpdate()
        {
            _myRigidbody.MovePosition(_myRigidbody.position + _velocity * Time.fixedDeltaTime);
        
        }
        
        private void Update()
        {
            MovePlayer();
            RotatePlayer();
        }


        public void MovePlayer()
        {
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Vector3 moveVelocity = moveInput.normalized * moveSpeed;
            Move(moveVelocity);
            
            if (moveVelocity !=Vector3.zero)
            {
                animatorMainPlayer.SetBool(IsRun,true);
            
            }
            else
            {
                animatorMainPlayer.SetBool(IsRun,false);
            }
        }
        private void RotatePlayer()
        {
            Ray ray = _viewCameraRay.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;
        
            if(groundPlane.Raycast(ray,out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
    }
}