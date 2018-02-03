// Written by anthonychian
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float timeInBetweenAttacks; // 0.3
	public float timer;
	public int attackDamage;
	public bool isVirus;
	public bool inRange;

    public float range;

	Damage otherDamage; 
	Health thisHealth;

	void Awake () {
		thisHealth = gameObject.GetComponent<Health> ();
	}



    IEnumerator dealConsistentDamage()
    {
        while (true)
        {
            if(GetComponent<Cell>() != null)
            {
                if (Vector3.Distance(GetComponent<Cell>().target.transform.position, gameObject.transform.position) <= range)
                {
                    GetComponent<Cell>().target.GetComponent<Health>().inflictDamage(attackDamage, gameObject);
                    Debug.Log(gameObject + " dealt " + attackDamage + " consistent damage to " + GetComponent<Cell>().target);
                    yield return new WaitForSeconds(timeInBetweenAttacks);
                }else
                {
                    yield return null;
                }
            }
        }
        
    }

	void OnCollisionEnter (Collision col)
	{
        /*
		if (isVirus) {
			if (col.gameObject == GameObject.FindWithTag ("Enemy")) {
				otherDamage = col.gameObject.GetComponent<Damage> ();
				inRange = true;
			}
		}
		else { // if not virus
			if (col.gameObject == GameObject.Find ("virusPlayer")) {
				otherDamage = col.gameObject.GetComponent<Damage> ();
				inRange = true;
			}
		}*/
        
        if (col.gameObject.GetComponent<Health>() && GetComponent<Cell>().visionLayerMask == (GetComponent<Cell>().visionLayerMask | 1 << col.gameObject.layer))
        { 
            col.gameObject.GetComponent<Health>().inflictDamage(attackDamage, gameObject);
        }

	}


    /*
	void OnCollisionStay(Collision col)
    {
        timer += Time.deltaTime;
        if(col.gameObject.GetComponent<Health>() && timer >= timeInBetweenAttacks )
        {
            col.gameObject.GetComponent<Health>().inflictDamage(attackDamage, gameObject);
            timer = 0;
        }

    }
    */
    /*
	void OnCollisionExit (Collision col)
	{
		if (isVirus) {
			if (col.gameObject == GameObject.FindWithTag ("Enemy"))
				inRange = false;
		}

		else { // if not virus
			if (col.gameObject == GameObject.Find ("virusPlayer"))
				inRange = false;
		}
	}
		*/
	/*void Attack () {
		timer = 0f;
		if(thisHealth.currentHealth > 0) 
			thisHealth.inflictDamage(otherDamage.attackDamage);
	}	*/
		
}
