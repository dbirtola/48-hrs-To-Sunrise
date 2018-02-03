using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : Cell{

	// Use this for initialization
	override protected void Start () {

	}
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<PlayerTest>())
        {
            Destroy(gameObject);
        }
    }
    override protected void OnDestroy()
    {
        base.OnDestroy();
        PlayerTest.player.killedUnitEvent.Invoke(gameObject);
    }
}
