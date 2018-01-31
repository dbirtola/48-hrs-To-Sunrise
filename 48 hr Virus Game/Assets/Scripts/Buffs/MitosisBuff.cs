using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MitosisBuff : Buff {

    public GameObject virusPrefab;

    void OnDestroy()
    {
        if (applicationQuitting == true)
            return;

        
        for(int i = 0; i < 3; i++)
        {
            Debug.Log("Creatng mini");
            GameObject temp = Instantiate(virusPrefab, transform.position, transform.rotation);
            temp.transform.localScale = temp.transform.localScale * 0.5f;
            temp.GetComponent<Damage>().attackDamage = (int)(GetComponent<Damage>().attackDamage * 0.3f);
            temp.GetComponent<Health>().startingHealth = (int)(GetComponent<Health>().startingHealth * 0.3f);
            temp.GetComponent<Health>().currentHealth = temp.GetComponent<Health>().startingHealth;


            //Vector3 spreadForce = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)) * 5;
            //temp.GetComponent<Rigidbody>().AddForce(spreadForce);

        
            
        }
    }

}
