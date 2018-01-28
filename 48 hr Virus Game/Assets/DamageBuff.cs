using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : MonoBehaviour {




    public int amount;

    public void Activate()
    {
        GetComponent<Damage>().attackDamage += amount;
    }

    public void Deactivate()
    {
        GetComponent<Damage>().attackDamage -= amount;
    }
}
