using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //text variables will be used to create display of mutation points
    public Text countText;
    public Text winText;


    public GameObject target;

    //counts the number of kills for Mutation points
    public int countKills;
    public float speed;
    private Rigidbody rb;

    //number of spawned virus bodies
    public float spawnRate = .01f;

    //clone the virus after the kill
    public Transform prefab;

	// Use this for initialization
	void Start () {
        NavMesh.pathfindingIterationsPerFrame = 1000;
        countKills = 0;
        rb = GetComponent<Rigidbody>();
        
	}

    public void SetTarget(GameObject target)
    {
        this.target = target;
        GetComponent<SpawnEnemies>().target = target;
    }

    public GameObject findNewTarget()
    {
        var temp = FindObjectOfType<Organ>().gameObject;
        SetTarget(temp);
        return temp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        */
    }
        //if collides with bloodCell, destroy bloodCell, increment count, explode force, create 5 viruses
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("bloodCell"))
            {
            //damage the bloodCell, decrement health


            //if bloodCell health is zero,
            Destroy(other.gameObject);
            //randomize the chance of having a higher 
            int numOfVirusSpawned = (int)(spawnRate * Random.Range(0,10));
            for(int i = 0;i< numOfVirusSpawned;i++)
            Instantiate(prefab, other.gameObject.transform.position, Quaternion.identity);


            //other.gameObject.SetActive(false);
            countKills++;
            }
            //else if other.gameObject.CompareTag("whiteCell")
            //damage the whiteCell
             //take damage from whiteCell
             //if player health zero die
             //if whiteCell health zero die
        }
        void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("bloodCell"))
            {
            //take damage per second

        }
    }

}
