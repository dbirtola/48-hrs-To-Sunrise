using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerUpgrade : Mutation {

    //Tanker upgrade increases the health and size of tanker Viruses
    //tanker upgrade increase the spawn rate and size of tanker Viruses
    // Use this for initialization
    override public void Start()
    {
        base.Start();
        PlayerTest.player.spawnedUnitEvent.AddListener(Tanker);
    }

    void Tanker(GameObject game)
    {
        //Randomize and lower the chance of spawning a virus with the TankerBuff 
        if (game.GetComponent<Virus>())
        {
            int chance = upgradeLevel * 5;
            //Add size buff here.
            if (Random.Range(0, 100) <= chance)
            {
                // var temp = game.AddComponent<SizeBuff>();//access sizeBuff component so we can use upgradeLevel to increment the size and mass of Virus
                int size = 2 * upgradeLevel;//at level one, the Tanker size will be double the size of a normal virus
                GetComponent<Virus>().transform.localScale.Set(GetComponent<Virus>().transform.localScale.x * size, GetComponent<Virus>().transform.localScale.y * size, GetComponent<Virus>().transform.localScale.z * size);
                float newMass;
                newMass = size * game.GetComponent<Rigidbody>().mass;
                //set mass to newMass
                game.GetComponent<Rigidbody>().mass = newMass;
                game.GetComponent<Health>().startingHealth += upgradeLevel * size;
                game.GetComponent<Health>().currentHealth = game.GetComponent<Health>().startingHealth;
            }

        }
    }
    // Update is called once per frame
    override public void Update()
    {
        base.Update();
    }
}
