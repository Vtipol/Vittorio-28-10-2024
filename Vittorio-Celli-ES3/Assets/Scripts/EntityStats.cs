using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityStats", menuName = "Entities/EntityStats")]
public class EntityStats : ScriptableObject
{
    public float Speed;
    public int Hp;
    public int MaxHp;
    public string PlayerName;
    public int Damage;
}
