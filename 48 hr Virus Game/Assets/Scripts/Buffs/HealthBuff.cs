using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour {




    public int amount;

    public void Activate(int health)
    {
        amount = health;
        GetComponent<Health>().currentHealth += health;
    }

    public void Deactivate()
    {
        GetComponent<Damage>().attackDamage -= amount;
    }
}
