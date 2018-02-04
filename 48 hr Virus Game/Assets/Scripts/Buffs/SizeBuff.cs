using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script is currently unused
public class SizeBuff : Buff {

    //public float size;//Start the multiplier at 1, and increment the size per upgrade
    //public Rigidbody rb = GetComponent<Rigidbody>();

    public void Activate(int newSize)
    {
        // amount = health;
        // GetComponent<Health>().currentHealth += health;
       // size += newSize;//increment the size of the Virus
        //increase the scale of the Virus
       // GetComponent<Virus>().transform.localScale.Set(GetComponent<Virus>().transform.localScale.x*size, GetComponent<Virus>().transform.localScale.y * size, GetComponent<Virus>().transform.localScale.z * size);
        //increase the mass of the virus??
        
    }

    public void Deactivate()
    {
       // GetComponent<Damage>().attackDamage -= amount;
    }
}
