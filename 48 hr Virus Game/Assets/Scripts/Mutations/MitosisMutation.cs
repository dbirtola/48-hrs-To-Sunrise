using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitosisMutation : Mutation {

    public int chancePerLevel = 5;

    public GameObject virusPrefab;

     override public void Start()
    {
        base.Start();
        PlayerTest.player.spawnedUnitEvent.AddListener(AddMitosis);
    }



    void AddMitosis(GameObject cell)
    {
        int chance = upgradeLevel * chancePerLevel;
        if(Random.Range(0, 100) < chance)
        {
            cell.AddComponent<MitosisBuff>();
            cell.GetComponent<MitosisBuff>().virusPrefab = virusPrefab;

        }
    }
}
