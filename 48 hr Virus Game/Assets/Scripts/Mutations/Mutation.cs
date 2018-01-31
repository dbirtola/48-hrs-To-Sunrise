using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour {
    public enum UpgradeState
    {
        Active,
        Inactive
    }


    public Color mutationColor;

    static Mutation focusedUpgrade;
    public Sprite backgroundIcon;
    public Sprite icon;
    public string mutationName;
    [TextArea]
    public string description;
    public int currentDNALevel = 0;
     int[] DNAToLevel;
    public int upgradeLevel = 1;
    public int maxLevel = 10;

    public bool activeUpgrade = false;

    public virtual void Start()
    {
        PlayerTest.player.killedUnitEvent.AddListener(processUnitKilled);

        if(DNAToLevel == null)
        {
            DNAToLevel = new int[20];
            for(int i = 0; i < 20; i++)
            {
                DNAToLevel[i] = (int)(10 * Mathf.Pow(1.3f, i));
            }
        }
    }


    protected virtual void processUnitKilled(GameObject unit)
    {
        if (focusedUpgrade == this)
        {
            if (unit.GetComponent<RedBloodCell>() || unit.GetComponent<WhiteBloodCell>())
            {
                currentDNALevel += 1;
                if (currentDNALevel >= DNAToLevel[upgradeLevel])
                {
                    currentDNALevel = 0;
                    var aud = GetComponent<AudioSource>();
                    aud.Play();
                    upgradeLevel++;
                }

            }
        }


    }

    public virtual void Update()
    {
        if(focusedUpgrade == this)
        {
            
        }
    }


    public float getPercentFull()
    {
        if (upgradeLevel == maxLevel)
            return 0;
        return (float)currentDNALevel / DNAToLevel[upgradeLevel];
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
