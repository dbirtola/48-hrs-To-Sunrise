using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutationOptions : MonoBehaviour {

    public MutationSelectionButton mutationSelectionButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateOptions()
    {
        foreach(Transform t in transform)
        {
            Destroy(t);
        }
        transform.DetachChildren();

        foreach(Mutation m in PlayerTest.player.mutations)
        {
            if(m.enabled == false)
            {
                var mut = Instantiate(mutationSelectionButton);
                mut.transform.SetParent(transform);
            }
        }
        
    }
}
