using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStats entityStats; 
    private int currentHp;

    void Start()
    {
        currentHp = entityStats.MaxHp;
        //Debug.Log(entityStats.PlayerName + " has " + currentHp + " HP.");
    }

    void Update()
    {
     //transform.Translate(Vector3.forward * entityStats.Speed * Time.deltaTime);
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(entityStats.PlayerName + " has died.");
    }
}
