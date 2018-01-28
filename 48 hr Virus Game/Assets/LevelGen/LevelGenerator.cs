using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject levelPeg;
    Collider coll;

	// Use this for initialization
	void Start () {
        coll = GetComponent<BoxCollider>();
        generatePegs();
	}


    void generatePegs()
    {

        Bounds bounds = coll.bounds;
        Debug.Log("Bounds are: " + (int)bounds.min.x + " to " + (int)bounds.max.x);
        for(float i = bounds.min.z; i< bounds.max.z; i++)
        {
            Debug.Log("Tryin");
            for(float j = bounds.min.x; j < bounds.max.x; j++)
            {
                Debug.Log("Creating sphere at: " + j + ", " + i);
                var temp = Instantiate(levelPeg, new Vector3(j, 0, i), Quaternion.identity);
                temp.transform.SetParent(transform);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
