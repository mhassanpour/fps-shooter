using System;
using UnityEngine;

namespace FPSShooter.Core.Movemenets
{
    [RequireComponent(typeof(CharacterController))]
    public class GravityAffect : MonoBehaviour
    {
        private CharacterController _controller;
        private float _verticalSpeed;
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _verticalSpeed += Physics.gravity.y * Time.deltaTime;
            _controller.Move(new Vector3(0, _verticalSpeed, 0));
        }
    }
}
