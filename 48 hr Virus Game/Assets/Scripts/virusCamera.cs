using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusCamera : MonoBehaviour {
    public float movementBorder = 100;
    public float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        Camera main = Camera.main;
        if (mousePos.y > Screen.height - movementBorder)
            main.transform.position += transform.up * speed;
        if(mousePos.y < movementBorder)
            main.transform.position -= transform.up * speed;
        if (mousePos.x > Screen.width - movementBorder)
            main.transform.position += transform.right * speed;
        if (mousePos.x < movementBorder)
            main.transform.position -= transform.right * speed;
    }
}
