using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutationSelectionButton : MonoBehaviour {

    Mutation associatedMutation;
    public Image image;
    Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(processClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void processClick()
    {

        if(PlayerTest.player.mutationPoints >= 1)
        {

            PlayerTest.player.activateMutation(associatedMutation);
            PlayerTest.player.mutationPoints--;
            FindObjectOfType<UIManager>().mutationPanel.AddMutation(associatedMutation);
            FindObjectOfType<UIManager>().toggleMutationSelect();


            
        }

    }


    public void setMutation(Mutation mutation)
    {
        associatedMutation = mutation;
        //image.sprite = associatedMutation.icon;
        transform.Find("Image").GetComponent<Image>().sprite = mutation.icon;
        transform.Find("Name_txt").GetComponent<Text>().text = mutation.mutationName;
        transform.Find("Description_txt").GetComponent<Text>().text = mutation.description;

    }
}
