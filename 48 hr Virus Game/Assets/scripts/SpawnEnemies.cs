using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    public GameObject spawner;                // The enemy prefab to be spawned.
    public GameObject target;
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public float offset = 0f;
    // Use this for initialization
    void Start () {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Spawn () {
        // Find a random index between zero and one less than the number of spawn points.
        if(target == null)
        {
            PlayerController pc = GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.findNewTarget();
            }
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Vector3 pos = transform.position + transform.forward * offset;
        pos.y = 1;
        GameObject temp = Instantiate(spawner, pos, Quaternion.identity);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.


        if(temp.GetComponent<Cell>() == null)
        {
        }else
        {

            temp.GetComponent<Cell>().SetTargetOrgan(target);
        }

        if (GetComponent<PlayerController>())
        {
            PlayerTest.player.spawnedUnitEvent.Invoke(temp);
        }

    }
}
