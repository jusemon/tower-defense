using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Enemy enemy;

    [SerializeField] int maxHealthPoints = 5;

    [Tooltip("Adds amount to max health points when enemy dies")]
    [SerializeField] int difficutyRamp = 1;
    int currentHealthPoints = 0;

    void OnEnable()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHealthPoints--;
        if (currentHealthPoints < 1)
        {
            gameObject.SetActive(false);
            maxHealthPoints += difficutyRamp;
            enemy.RewardGold();
        }
    }
}
