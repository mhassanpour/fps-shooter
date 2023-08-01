using UnityEngine;

namespace FPSShooter.Core.Movemenets
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerControl _playerControl;


        public static PlayerInputManager Instance { get; private set; }


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Debug.LogError("There is more than one PlayerInputManager in the scene!");
            
            _playerControl = new PlayerControl();
        }

        private void OnEnable()
        {
            _playerControl.Enable();
        }

        private void OnDisable()
        {
            _playerControl.Disable();
        }

        public Vector2 GetPlayerMovement()
        {
            return _playerControl.Player.Move.ReadValue<Vector2>();
        }
        
        public bool IsJumping()
        {
            return _playerControl.Player.Jump.triggered;
        }

        public Vector2 GetMouseDelta()
        {
            return _playerControl.Player.Look.ReadValue<Vector2>();
        }
    }
}