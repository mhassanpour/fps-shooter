using System;

namespace FPSShooter.Core.WeaponSystem
{
    [Serializable]
    public struct WeaponSpecModel
    {
        public float Damage;
        public float FireRate;
        public float projectileSpeed;
    }
}