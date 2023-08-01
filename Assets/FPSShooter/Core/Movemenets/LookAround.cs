using System;
using UnityEngine;

namespace FPSShooter.Core.Movemenets
{
    public class LookAround : MonoBehaviour
    {
        private PlayerInputManager _inputManager;
        private Vector3 _startingRotation;

        [SerializeField] private float clampAngle = 80f;
        [SerializeField] private float horizontalSpeed = 10f;
        [SerializeField] private float verticalSpeed = 10f;
        [SerializeField] private bool isReverseAxis = true;

        private int _reverseAxisSign = 1;
        
        private void Awake()
        {
            _inputManager = PlayerInputManager.Instance;
            if (isReverseAxis)
            {
                _reverseAxisSign = -1;
            }
        }

        private void Update()
        {
            if (_inputManager == null)
            {
                _inputManager = PlayerInputManager.Instance;
                return;
            }

            Vector2 input = _inputManager.GetMouseDelta();
            _startingRotation.x += input.x * verticalSpeed * Time.deltaTime;
            _startingRotation.y += input.y * horizontalSpeed * Time.deltaTime * _reverseAxisSign;
            _startingRotation.y = Mathf.Clamp(_startingRotation.y, -clampAngle, clampAngle);
            transform.rotation = Quaternion.Euler(_startingRotation.y, _startingRotation.x, 0f);
        }
    }
}