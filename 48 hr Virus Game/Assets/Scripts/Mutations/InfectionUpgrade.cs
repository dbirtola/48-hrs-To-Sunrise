using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionUpgrade : Mutation {

    public Virus virus;// will be a Virus
    

	// Use this for initialization
	override public void Start () {
        base.Start();
        PlayerTest.player.killedUnitEvent.AddListener(Infect);
	}
	
    void Infect(GameObject game)
    {

        if (game.GetComponent<RedBloodCell>()) {

            int chance = upgradeLevel * 5;
            if (Random.Range(0, 100) <= chance)
            {
                Instantiate(virus, game.transform.position, Quaternion.identity);
            }
        }

    }

	// Update is called once per frame
	override public void Update () {
        base.Update();
	}
}
