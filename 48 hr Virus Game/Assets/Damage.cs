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

	Damage otherDamage; 
	Health thisHealth;

	void Awake () {
		thisHealth = gameObject.GetComponent<Health> ();
	}

	void Update () {
		timer += Time.deltaTime; 
		if(timer >= timeInBetweenAttacks && inRange && thisHealth.currentHealth > 0)
			Attack ();
	}

	void OnCollisionEnter (Collision col)
	{
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
		}

	}
	void OnCollisionStay(Collision col)
	{
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
		}
	}
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
		
	void Attack () {
		timer = 0f;
		if(thisHealth.currentHealth > 0) 
			thisHealth.inflictDamage(otherDamage.attackDamage);
	}	
		
}
