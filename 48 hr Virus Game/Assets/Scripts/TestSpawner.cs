using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestSpawner : MonoBehaviour {

    public GameObject unit;
    public float time;
    public GameObject target;
    public bool shouldSpawn = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(spawn());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawn()
    {
        while(shouldSpawn == true)
        {
            var temp = Instantiate(unit, transform.position, Quaternion.identity);
            temp.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
            temp.GetComponent<TestResetLocation>().target = target;
            yield return new WaitForSeconds(time);
        }
    }
}
