using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BloodCellMovement : MonoBehaviour {

    public GameObject targetCell;
    public GameObject target;
    public float thrust;
    public Rigidbody rb;
    public float raycastDistance = 3f;
    public Collider physicsCollider;
    public Collider triggerCollider;
    public bool isFighting = false;

    public ParticleSystem deathParticles;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }

    void Update()
    {
        
        if(target== null)
        {
            SetTarget(FindObjectOfType<Organ>().gameObject);
            return;
        }

        var child = transform.Find("blood cell");
        if(child != null)
        {
            child.transform.Rotate(new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
        }




        
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.GetComponent<BloodCellMovement>() != null)
        {
            SetTargetCell(col.gameObject);
        }

    }

    void OnDestroy()
    {
        if (!gameObject.GetComponent<Virus>())
        {
            PlayerTest.player.killedUnitEvent.Invoke(gameObject);
        }
        if(deathParticles != null)
        {

            var temp = Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(temp, 2);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.GetComponent<BloodCellMovement>() != null)
        {

            GetComponent<NavMeshAgent>().SetDestination(col.transform.position);
        }
    }
    public void SetTargetCell(GameObject cell)
    {
        targetCell = cell;
        GetComponent<NavMeshAgent>().SetDestination(cell.transform.position);
        if(GetComponent<NavMeshAgent>().isOnNavMesh == false)
        {
            Debug.Log("NOT ON NAVMESH: " + gameObject.name);
        }
    }

    public void FindNewTarget()
    {
        if(target != null)
        {
            SetTarget(target);
        }else
        {
            SetTarget(FindObjectOfType<Organ>().gameObject);
        }
    }

   public void SetTarget(GameObject other) {
        target = other;
        Vector3 targetPos = other.transform.position;
        targetPos.y = 1;
        if(GetComponent<NavMeshAgent>().isOnNavMesh == false)
        {
            Debug.Log(gameObject.name + " IS NOT ON NAVMESH");
        }else
        {

            GetComponent<NavMeshAgent>().SetDestination(targetPos);
        }
    }
}
