using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellMovement : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0,-thrust);
    }
}
