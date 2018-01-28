using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : Mutation{

	// Use this for initialization
	override public void Start () {
        base.Start();
        GetComponent<PlayerTest>().spawnedUnitEvent.AddListener(addDamageComponent);
	}

    void addDamageComponent(GameObject unit)
    {
        Debug.Log("Adding damage buff!");
        var buff = unit.AddComponent<DamageBuff>();
        buff.Activate(upgradeLevel);
    }
	
	// Update is called once per frame
	override public void Update () {
        base.Update();
	}
}
