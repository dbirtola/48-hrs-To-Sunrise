using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MutationPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void optionSelected(ResearchButton selected)
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.GetComponent<Image>().color = b.colors.normalColor;
        }

        var col = selected.GetComponent<Image>().color;
        selected.GetComponent<Image>().color = selected.GetComponent<Button>().colors.highlightedColor;


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
