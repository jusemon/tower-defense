using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagetLocator : MonoBehaviour
{

    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticles;

    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        if (target == null) return;
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target.position);
        Attack(targetDistance < range);
    }

    void Attack(bool IsActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = IsActive;
    }
}
