using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //text variables will be used to create display of mutation points
    public Text countText;
    public Text winText;

    public int countKills;//counts the number of kills for Mutation points
    public float speed;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        countKills = 0;
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
        //if collides with bloodCell, destroy bloodCell, increment count, explode force, create 5 viruses
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("bloodCell"))
            {
                Destroy(other.gameObject,.2f);
                //other.gameObject.SetActive(false);
                countKills++;
            }
        }
    
}
