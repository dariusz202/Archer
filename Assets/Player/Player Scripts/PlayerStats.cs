using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int attackPower = 50;

    public void AddAttack()
    {
        attackPower += 5;
    }
    public void AddMaxHealth()
    {
        maxHealth += 10;
    }
}
