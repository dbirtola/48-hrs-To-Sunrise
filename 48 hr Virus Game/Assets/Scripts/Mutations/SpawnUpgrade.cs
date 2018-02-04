using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUpgrade : Mutation {


    override public void Start()
    {
        base.Start();
       // PlayerTest.player.spawnedUnitEvent.AddListener(Spawn);
    }

    void Spawn(GameObject game)
    {
                PlayerTest.player.GetComponent<SpawnEnemies>().spawnTime = 20 *(1/5*upgradeLevel);
    }
    // Update is called once per frame
    override public void Update()
    {
        base.Update();
    }
}
