using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPressureUpgrade : Mutation {

    override public void Start()
    {
        base.Start();
       // PlayerTest.player.spawnedUnitEvent.AddListener(BloodPressure);
    }

    void BloodPressure(GameObject game)//increase the spawn rate of red blood cells 
    {
        //access and change the spawn rate of RBC by iterating through the different organs
        //game.GetComponent<Lungs>().GetComponent<SpawnEnemies>().spawnTime = 20/(5*upgradeLevel);
        var temp = GameObject.FindObjectsOfType<Organ>();//will hold all organs
        for (int i = 0; i < temp.Length; i++) {
            temp[i].GetComponent<SpawnEnemies>().spawnTime = 20 / (5 * upgradeLevel);
        }
    }
    // Update is called once per frame
    override public void Update()
    {
        base.Update();
    }
}
