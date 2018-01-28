using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddMutation(Mutation mutation)
    {
        Debug.Log("Adding : " + mutation.name);
        var buttons = GetComponentsInChildren<ResearchButton>();
        foreach(ResearchButton b in buttons)
        {
            if(b.associatedUpgrade == null)
            {
                b.setUpgrade(mutation);
                break;
            }
        }
    }
}
