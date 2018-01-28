using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrganButton : MonoBehaviour {
    public GameObject associatedOrgan;
    
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(processClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void processClick()
    {
        Vector3 pos = associatedOrgan.transform.position;
        Vector3 oldPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(pos.x, oldPos.y, pos.z);
        if (associatedOrgan.GetComponent<Organ>())
        {

            PlayerTest.player.GetComponent<PlayerController>().SetTarget(associatedOrgan);
        }
    }
}
