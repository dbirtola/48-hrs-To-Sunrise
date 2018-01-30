using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct spawnInfo
{
    public GameObject spawn;
    public float spawnTime;
}

public class WhiteCellSpawner : MonoBehaviour {

    public bool shouldspawn = true;
    public float spawnTime = 1f;
    List<spawnInfo> spawnInfos;

    public GameObject target;
    public GameObject whiteCell;

	// Use this for initialization
	void Start () {
        StartCoroutine(spawn(whiteCell, spawnTime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
    void AddSpawn(spawnInfo info)
    {
        StartCoroutine(spawn(info));
    }*/

    IEnumerator spawn(GameObject spawn, float time)
    {
        while(shouldspawn == true)
        {
            var temp = Instantiate(spawn, transform.position, Quaternion.identity);
            temp.GetComponent<Cell>().SetTargetOrgan(target);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
