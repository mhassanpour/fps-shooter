using UnityEngine;

namespace FPSShooter.Core.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private WeaponSpecModel weaponSpecModel;
        
        public void Shoot(Transform owner)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.Initialize(weaponSpecModel.Damage, weaponSpecModel.projectileSpeed, owner);
            projectile.Shoot();
        }
    }
    
    
}
