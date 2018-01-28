using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public MutationSelection mutationSelect;
    public MutationPanel mutationPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleMutationSelect()
    {
        if (mutationSelect.gameObject.activeSelf == false)
        {
            mutationSelect.gameObject.SetActive(true);
            mutationSelect.updateOptions();
        }
        else
        {
            mutationSelect.gameObject.SetActive(false);
        }
    }

    
}
