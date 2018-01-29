using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResearchButton : MonoBehaviour {

    public Mutation associatedUpgrade;
    Button button;

    public Sprite activeSprite;

	// Use this for initialization
	void Awake () {
        button = GetComponent<Button>();
        button.onClick.AddListener(processClick);
	}
	

    void processClick()
    {
        if(button.interactable == true)
        {

            associatedUpgrade.setAsFocus();
            transform.parent.GetComponent<MutationPanel>().optionSelected(this);

        }
    }

	// Update is called once per frame
	void Update () {
        if(associatedUpgrade != null)
            GetComponentInChildren<Slider>().value = associatedUpgrade.getPercentFull();
	}


    public void setUpgrade(Mutation upgrade)
    {
        associatedUpgrade = upgrade;
        button.interactable = true;
        //GetComponent<Image>().sprite = activeSprite;
        transform.GetChild(0).Find("Background").gameObject.SetActive(true);
        transform.GetChild(0).Find("Background").GetComponent<Image>().sprite = associatedUpgrade.icon;
        transform.parent.gameObject.GetComponent<Image>().sprite = associatedUpgrade.icon;
        GetComponent<Image>().sprite = associatedUpgrade.backgroundIcon;
    }
    

   
}
