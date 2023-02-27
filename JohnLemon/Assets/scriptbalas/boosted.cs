using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosted : MonoBehaviour
{
    public float DivisorDisparo=2f;
    public float Duracion=20f;
    public spawner Spawner;
    public void start()
    {

        Destroy(gameObject,20f);

    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("player"))
        {
           other.GetComponent<PilotoNave>().boostedcogido(DivisorDisparo,Duracion);
          
            Spawner.startSpawn();
            Destroy(gameObject);
        
        
        
        }
    }
}
