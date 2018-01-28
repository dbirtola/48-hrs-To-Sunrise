// Written by anthonychian
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	
	public int startingHealth; // 100
	public int currentHealth;
	public float despawnTime; // 0.2f

	public bool isDead;
	public bool damaged;

	void Awake() {
		currentHealth = startingHealth;
	}

	void Update () {
		damaged = false;
	}

	public void inflictDamage(int dmg, GameObject attacker) {
		damaged = true;
		currentHealth -= dmg;
		if (currentHealth <= 0 && !isDead)
			Die (attacker);
	}

	public void Die(GameObject killer) {
		isDead = true;
        killer.GetComponent<BloodCellMovement>().FindNewTarget();
		Destroy (gameObject, despawnTime);
	}
}
