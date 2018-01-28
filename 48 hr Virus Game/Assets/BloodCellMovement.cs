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
        if (gameObject.layer != LayerMask.NameToLayer("Viruses"))
        {
            PlayerTest.player.killedUnitEvent.Invoke(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (targetCell != null)
        {
            
            if (Vector3.Distance(targetCell.transform.position, transform.position) <= 2)
            {
                Debug.Log("Hit!");
                targetCell.GetComponent<Health>().inflictDamage(GetComponent<Damage>().attackDamage);
            }
        }*/

        //rb.AddForce(0,0,-thrust);
        /*
        NavMeshHit hit = new NavMeshHit();
        NavMesh.Raycast(transform.position, transform.forward * raycastDistance, out hit, GetComponent<NavMeshAgent>().areaMask);
        if (hit.hit)
        {
            Debug.Log("RECALC");
            Vector3 targetPos = target.transform.position;
            targetPos.y = 1;
            GetComponent<NavMeshAgent>().SetDestination(targetPos);

        }

    */

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
        GetComponent<NavMeshAgent>().SetDestination(targetPos);
        if(GetComponent<NavMeshAgent>().isOnNavMesh == false)
        {
            Debug.Log(gameObject.name + " IS NOT ON NAVMESH");
        }
    }
}
