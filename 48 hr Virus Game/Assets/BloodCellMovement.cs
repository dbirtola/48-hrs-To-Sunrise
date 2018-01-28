using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BloodCellMovement : MonoBehaviour {

    public GameObject target;
    public float thrust;
    public Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(0,0,-thrust);
    }

   public void SetTarget(GameObject other) {
        target = other;
        GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
    }
}
