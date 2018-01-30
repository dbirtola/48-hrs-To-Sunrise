using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour {

     void Start()
    {
        PlayerTest.player.spawnedUnitEvent.AddListener(changeColor);
    }



    void changeColor(GameObject ob)
    {

    }
}
