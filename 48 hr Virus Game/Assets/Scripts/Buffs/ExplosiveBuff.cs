using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBuff : MonoBehaviour {

    public int damage = 25;
    public int radius = 5;


    void OnDestroy()
    {
        var colls = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider c in colls)
        {
            Health h = c.gameObject.GetComponent<Health>() ;
            if (h != null && (c.gameObject.layer != gameObject.layer))
            {
                h.inflictDamage(damage, gameObject);
            }
        }
    }
}
