using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Mutation{


    public int healthPerLevel = 2;

	// Use this for initialization
	override public void Start () {
        base.Start();
        GetComponent<PlayerTest>().spawnedUnitEvent.AddListener(addHealthComponent);
	}

    void addHealthComponent(GameObject unit)
    {
        //Debug.Log("Adding health buff!");
        //var buff = unit.AddComponent<HealthBuff>();

        //buff.Activate(upgradeLevel);

        unit.GetComponent<Health>().startingHealth += upgradeLevel * healthPerLevel;
        unit.GetComponent<Health>().currentHealth = unit.GetComponent<Health>().startingHealth;

    }
	
	// Update is called once per frame
	override public void Update () {
        base.Update();
	}
}
