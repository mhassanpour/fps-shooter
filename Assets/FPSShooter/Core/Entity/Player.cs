using FPSShooter.Core.Movemenets;
using UnityEngine;

namespace FPSShooter.Core.Entity
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private WeaponSystem.Weapon weapon;
        
        private void Update()
        {
            if (PlayerInputManager.Instance.IsShooting())
            {
                weapon.Shoot(transform);
            }
        }
    }
}