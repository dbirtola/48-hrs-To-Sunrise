using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutationSelectionButton : MonoBehaviour {

    Mutation associatedMutation;
    public Image image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void setMutation(Mutation mutation)
    {
        associatedMutation = mutation;
        image.sprite = associatedMutation.icon;
        transform.Find("Name_txt").GetComponent<Text>().text = mutation.name;
        transform.Find("Description_txt").GetComponent<Text>().text = mutation.description;

    }
}
