using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EntityStats enemyStats;
    private int currentHp;

    public GameObject healthBarPrefab;
    private HealthBar healthBar;

    void Start()
    {
        currentHp = enemyStats.MaxHp;

        GameObject hb = Instantiate(healthBarPrefab);
        healthBar = hb.GetComponent<HealthBar>();
        healthBar.SetTarget(transform);
        healthBar.SetHealth(currentHp, enemyStats.MaxHp);
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        Debug.Log(enemyStats.PlayerName + " took " + amount + " damage. Current HP: " + currentHp);

        healthBar.SetHealth(currentHp, enemyStats.MaxHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(enemyStats.PlayerName + " has died.");
        Destroy(gameObject);
    }
}
