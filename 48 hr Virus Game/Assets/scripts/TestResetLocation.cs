using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestResetLocation : MonoBehaviour {

    public GameObject target;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        FindObjectOfType<TerrainMorpher>().navmeshRebuiltEvent.AddListener(ResetDestination);
	}
	

	void ResetDestination()
    {
        /*
        if (target == null)
            return;
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        Debug.Log(GetComponent<NavMeshAgent>().isOnNavMesh);
        */


    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
        
    }
}
