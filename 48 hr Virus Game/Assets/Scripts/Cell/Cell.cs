using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cell : MonoBehaviour
{
    public static int cellsCreated = 0;

    public GameObject target;
    public GameObject targetOrgan;
    public float thrust;
    public Rigidbody rb;

    public ParticleSystem deathParticles;

    public NavMeshAgent navAgent;

    bool aware = true;
    public float findTargetInterval = 0.3f;
    public float visionRadius = 10f;
    //visionLayerMask should be set by children
    public LayerMask visionLayerMask;



    public bool shouldChaseEnemy = true;
    public float setDestinationInterval = 0.1f;


    float speed = 1f;
    virtual protected void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        //navAgent.updateRotation = false;
        //navAgent.updatePosition = false;

    }

    // Use this for initialization
    virtual protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        //StartCoroutine(CheckForEnemies());
        //StartCoroutine(chaseEnemy());
        cellsCreated++;
    }

    virtual protected void Update()
    {

        //FindTarget();
        
        if (target != null)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.y = 1;
            navAgent.SetDestination(targetPos);
        }

        var child = transform.Find("blood cell");
        if (child != null)
        {
            child.transform.Rotate(new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)) * Time.deltaTime);
        }

        


    }


    virtual protected void OnTriggerEnter(Collider col)
    {

        //Check to see if gameobjects layer is in this units vision mask
        if (visionLayerMask == (visionLayerMask | 1 << col.gameObject.layer)){
            FindTarget();
            //SetTarget(col.gameObject);
        }
    }


    virtual protected void FixedUpdate()
    {
        //rb.MovePosition(rb.position + navAgent.desiredVelocity.normalized * speed);

    }

    IEnumerator chaseEnemy()
    {
        while(shouldChaseEnemy == true)
        {

            if (target != null)
            {
                if (GetComponent<Virus>())
                    Debug.Log("Chasing");
                Vector3 targetPos = target.transform.position;
                targetPos.y = 1;
                navAgent.SetDestination(targetPos);
            }
            yield return new WaitForSeconds(setDestinationInterval);
        }

    }

    IEnumerator CheckForEnemies()
    {
        //Happens once per checktime
        //Avoids using a collider to check for enemies around in the interest of performance
        while (aware)
        {
            FindTarget();
            yield return new WaitForSeconds(findTargetInterval);
        }

        yield return null;
    }





    void OnDestroy()
    {
        if (gameObject.layer != LayerMask.NameToLayer("Viruses"))
        {
            PlayerTest.player.killedUnitEvent.Invoke(gameObject);
        }
        if (deathParticles != null)
        {

            var temp = Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(temp, 2);

        }
    }


    /*
    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.GetComponent<BloodCellMovement>() != null)
        {

            GetComponent<NavMeshAgent>().SetDestination(col.transform.position);
        }
    }*/



    public void FindTarget()
    {
        var surroundings = Physics.OverlapSphere(transform.position, visionRadius, visionLayerMask);
        if (surroundings.Length > 0)
        {
            SetTarget(surroundings[0].gameObject);
        }else
        {
            if(targetOrgan == null)
            {
                targetOrgan = FindObjectOfType<Organ>().gameObject;
            }

            SetTarget(targetOrgan);
                
        }

    }

    public void SetTargetOrgan(GameObject organ)
    {
        targetOrgan = organ;
        SetTarget(organ);
    }

    public void SetTarget(GameObject other)
    {
        target = other;
        //Vector3 targetPos = other.transform.position;
        //targetPos.y = 1;

        if (navAgent.isOnNavMesh == false)
        {
            Debug.Log(gameObject.name + " IS NOT ON NAVMESH");
        }
        else
        {
            //navAgent.SetDestination(targetPos);
        }
    }
}
