using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    private Transform target;

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void SetHealth(float currentHp, float maxHp)
    {
        healthBarFill.fillAmount = currentHp / maxHp;
    }

    public void SetTarget(Transform entity)
    {
        target = entity;
        transform.position = target.position + Vector3.up * 2;
    }
}
