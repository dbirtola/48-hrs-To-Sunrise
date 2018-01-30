using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  WhiteBloodCell : Cell {

	// Use this for initialization
	override protected void Start()
    {
        base.Start();
    }
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();
	}

    override protected void OnDestroy()
    {
        PlayerTest.player.killedUnitEvent.Invoke(gameObject);
    }
}
