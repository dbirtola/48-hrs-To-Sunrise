using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionUpgrade : Mutation {

    // Use this for initialization
    // Use this for initialization
    override public void Start()
    {
        base.Start();
        PlayerTest.player.spawnedUnitEvent.AddListener(Explode);
    }

    void Explode(GameObject game) {
        if (game.GetComponent<Virus>()) {
            game.AddComponent<ExplosiveBuff>();
        }
    }
    // Update is called once per frame
    override public void Update()
    {
        base.Update();
    }
}
