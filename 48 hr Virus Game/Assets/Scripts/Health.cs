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

    public ParticleSystem damageTakenParticle;

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

        var aud = GetComponent<AudioSource>();
        if(aud != null && aud.enabled == true)
        {
            aud.Play();
        }

        if(damageTakenParticle != null)
        {
            var temp = Instantiate(damageTakenParticle, transform.position, transform.rotation);
            Destroy(temp, 1);

        }
	}

	public void Die(GameObject killer) {
		isDead = true;
        if (GetComponent<PlayerController>())
        {
            FindObjectOfType<UIManager>().GameOver();
        }
		Destroy (gameObject, despawnTime);
	}
}
