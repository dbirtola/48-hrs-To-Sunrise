using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour {
    public enum UpgradeState
    {
        Active,
        Inactive
    }



    static Mutation focusedUpgrade;

    public Sprite icon;
    public string description;

    public int currentDNALevel = 0;
    public int[] DNAToLevel;
    public int upgradeLevel = 1;
    public int maxLevel = 10;

    public bool activeUpgrade = false;

    public virtual void Start()
    {
        PlayerTest.player.killedUnitEvent.AddListener(processUnitKilled);
    }


    protected virtual void processUnitKilled(GameObject unit)
    {
        Debug.Log("Adding: 1 exp to " + name);
        currentDNALevel += 1;
        if(currentDNALevel >= DNAToLevel[upgradeLevel])
        {
            Debug.Log(name + "Leveled up");
            upgradeLevel++;
        }
    }

    public virtual void Update()
    {
        if(focusedUpgrade == this)
        {
            Debug.Log("Dna going to: " + name);
            
        }
    }

    public virtual void setAsFocus()
    {
        focusedUpgrade = this;
    }

    public virtual void Activate()
    {

    }

    public virtual void Deactivate()
    {

    }
}
