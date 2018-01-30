using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugUI : MonoBehaviour {
    public Text objectsText;
    public Text fpsText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        objectsText.text = Cell.cellsCreated.ToString();
        fpsText.text = (1f / Time.deltaTime).ToString();
	}
}
