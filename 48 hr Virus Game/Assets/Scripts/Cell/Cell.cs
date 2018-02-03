using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cell : MonoBehaviour
{

    public bool applicationQuitting = false;
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
    Vector3 rotation;

    private bool flickTrigger = true;

    virtual protected void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rotation = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)) * 50;
        rb.isKinematic = true;
        navAgent.updateRotation = false;
        cellsCreated++;
    }

    // Use this for initialization
    virtual protected void Start()
    {
        //rb.angularVelocity = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));

        StartCoroutine(CheckForEnemies2());
    }

    virtual protected void Update()
    {

        rb.transform.Rotate(rotation * Time.deltaTime);

        if (target == null)
        {
            FindTarget();
        }else if(target != targetOrgan) { 
            Vector3 targetPos = target.transform.position;
            targetPos.y = 1;
            navAgent.SetDestination(targetPos);
        }

    }

    /*
    virtual protected void OnTriggerEnter(Collider col)
    {
        if (visionLayerMask == (visionLayerMask | 1 << col.gameObject.layer))
        {
            if (target != null && target.GetComponent<Cell>())
                return;
            SetTarget(col.gameObject);
            rb.isKinematic = false;
        }
    }*/

    
    IEnumerator CheckForEnemies2()
    {
        //Happens once per checktime
        //Avoids using a collider to check for enemies around in the interest of performance
        while (aware)
        {
            var surroundings = Physics.OverlapSphere(transform.position, visionRadius, visionLayerMask);
            if (surroundings.Length > 0)
            {
                if (!(target != null && target.GetComponent<Cell>()))
                {
                    SetTarget(surroundings[0].gameObject);
                    rb.isKinematic = false;

                }


            }

            yield return new WaitForSeconds(findTargetInterval);
        }

        yield return null;
    }



    
    virtual protected void OnDestroy()
    {
        if(applicationQuitting == true)
        {
            return;
        }
        cellsCreated--;


        if(PlayerTest.player.killedUnitEvent != null)
            PlayerTest.player.killedUnitEvent.Invoke(gameObject);

        if (deathParticles != null)
        {

            var temp = Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(temp, 2);

        }
    }





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
        Vector3 targetPos = other.transform.position;
        targetPos.y = 1;

        if (navAgent.isOnNavMesh == false)
        {
            Debug.Log(gameObject.name + " IS NOT ON NAVMESH");
        }
        else
        {
            navAgent.SetDestination(targetPos);
        }
    }


    void OnApplicationQuit()
    {
        applicationQuitting = true;
    }

}
