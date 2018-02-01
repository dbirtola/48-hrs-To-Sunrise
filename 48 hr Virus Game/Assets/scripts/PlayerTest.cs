using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KilledUnitEvent : UnityEvent<GameObject>
{

}

public class SpawnedUnitEvent : UnityEvent<GameObject>
{

}



public class PlayerTest : MonoBehaviour {
    public static PlayerTest player;

    public KilledUnitEvent killedUnitEvent;
    public SpawnedUnitEvent spawnedUnitEvent;


    public Mutation[] mutations;
    public int mutationPoints;

    void Awake()
    {
        player = this;



        killedUnitEvent = new KilledUnitEvent();
        spawnedUnitEvent = new SpawnedUnitEvent();


    }

    void OnDestroy()
    {
        Debug.Log("Game Over");
    }

	void Start () {
        mutations = GetComponentsInChildren<Mutation>();
        foreach(Mutation m in mutations)
        {
            if(m.enabled == true)
            {
                FindObjectOfType<UIManager>().mutationPanel.AddMutation(m);
            }
        }

	}




    
    public void activateMutation(Mutation mutation)
    {
        mutation.enabled = true;
    }

    public List<Mutation> getActiveMutations()
    {
        List<Mutation> result = new List<Mutation>();
        foreach(Mutation m in mutations)
        {
            if(m.enabled == true)
            {
                result.Add(m);
            }
        }

        return result;
    }

    public List<Mutation> GetInactiveMutations()
    {
        List<Mutation> result = new List<Mutation>();
        foreach (Mutation m in mutations)
        {
            if (m.enabled == false)
            {
                result.Add(m);
            }
        }

        return result;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            FindObjectOfType<MutationPanel>().AddMutation(GetComponent<DamageUpgrade>());
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            FindObjectOfType<UIManager>().toggleMutationSelect();

        }
    }
}
