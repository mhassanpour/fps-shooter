using System;
using UnityEngine;

namespace FPSShooter.Core.WeaponSystem
{
    public class Projectile : MonoBehaviour
    {
        private float _damage;
        private float _projectileSpeed;

        private Rigidbody _rigidbody;
        private Transform _owner;

        [SerializeField] private ParticleSystem hitEffect;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }


        public void Shoot()
        {
            _rigidbody.AddForce(transform.forward * _projectileSpeed, ForceMode.Impulse);
        }

        public void Initialize(float damage, float projectileSpeed, Transform owner)
        {
            _damage = damage;
            _projectileSpeed = projectileSpeed;
            _owner = owner;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damageable = collision.gameObject.GetComponent<DamageableObject>();
            if (collision.gameObject.transform == _owner) return;
            if (damageable)
            {
                Destroy();
                damageable.TakeDamage(_damage);
                return;
            }

            DoCollisionEffect(collision.contacts[0].point,collision.contacts[0].normal);
        }

        private void DoCollisionEffect(Vector3 pos, Vector3 normal)
        {
            if (hitEffect == null) return;
            var particle = Instantiate(hitEffect, pos + normal * 0.1f, Quaternion.LookRotation(normal));
            Destroy(gameObject);
            Destroy(particle.gameObject, 1f);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}