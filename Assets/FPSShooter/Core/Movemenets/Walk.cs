using System;
using UnityEngine;

namespace FPSShooter.Core.Movemenets
{
    [RequireComponent(typeof(CharacterController))]
    public class Walk : MonoBehaviour
    {
        private CharacterController controller;
        [SerializeField] private float speed = 5f;

        private Vector3 _direction;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }


        private void Move(Vector3 direction, float speed)
        {
            controller.Move(direction * (speed * Time.deltaTime));
        }

        private void Update()
        {
            if (!controller.isGrounded) return;
            _direction = PlayerInputManager.Instance.GetPlayerMovement();
            _direction = new Vector3(_direction.x, 0, _direction.y);
            _direction = transform.TransformDirection(_direction);
            Move(_direction, speed);
        }
    }
}