using UnityEngine;

namespace FPSShooter.Core.Movemenets
{
    public class Jump : MonoBehaviour
    {
        private CharacterController _controller;
        private float _verticalSpeed;
        [SerializeField] private float jumpSpeed = 5f;
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (PlayerInputManager.Instance.IsJumping())
            {
                _verticalSpeed = jumpSpeed;
            }
            _controller.Move(new Vector3(0, _verticalSpeed, 0));
        }
    }
}
