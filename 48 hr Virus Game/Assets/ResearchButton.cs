using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResearchButton : MonoBehaviour {

    public Mutation associatedUpgrade;
    Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(processClick);
	}
	

    void processClick()
    {
        associatedUpgrade.setAsFocus();
        GetComponent<Image>().color = GetComponent<Button>().colors.pressedColor;
    }

	// Update is called once per frame
	void Update () {
		
	}


    public void setUpgrade(Mutation upgrade)
    {
        associatedUpgrade = upgrade;
        button.interactable = true;
        GetComponent<Image>().sprite = associatedUpgrade.icon;
    }
    

   
}
