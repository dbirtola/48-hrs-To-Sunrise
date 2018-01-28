using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KilledUnitEvent : UnityEvent<GameObject>
{

}


public class PlayerTest : MonoBehaviour {
    public static PlayerTest player;
    public KilledUnitEvent killedUnitEvent;
    public Mutation[] mutations;

    void Awake()
    {
        player = this;
        killedUnitEvent = new KilledUnitEvent();
    }



	void Start () {
        mutations = GetComponentsInChildren<Mutation>();

	}


    
    void AddMutation<T>() where T : Mutation
    {
        GetComponent<T>().enabled = true;

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
            Debug.Log("A");
            killedUnitEvent.Invoke(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            FindObjectOfType<MutationPanel>().AddMutation(GetComponent<DamageUpgrade>());
        }
    }
}
