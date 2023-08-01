using Cinemachine;
using UnityEngine;

namespace FPSShooter.Core.Movemenets
{
    public class CinemachinePovExtension : CinemachineExtension
    {
        private PlayerInputManager _inputManager;
        private Vector3 _startingRotation;

        [SerializeField] private float clampAngle = 80f;
        [SerializeField] private float horizontalSpeed = 10f;
        [SerializeField] private float verticalSpeed = 10f;

        protected override void Awake()
        {
            _inputManager = PlayerInputManager.Instance;
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (vcam.Follow == null) return;
            if (stage != CinemachineCore.Stage.Aim) return;
            if (_inputManager == null)
            {
                _inputManager = PlayerInputManager.Instance;
                return;
            }

            Vector2 input = _inputManager.GetMouseDelta();
            Debug.Log(input);
            _startingRotation.x -= input.x * verticalSpeed * Time.deltaTime;
            _startingRotation.y += input.y * horizontalSpeed * Time.deltaTime;
            _startingRotation.y = Mathf.Clamp(_startingRotation.y, -clampAngle, clampAngle);
            state.RawOrientation = Quaternion.Euler(_startingRotation.y, _startingRotation.x, 0f);
        }
    }
}