using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerNotas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag  == "Player")
        {
            ContadorNotas.notasEncontradas +=1;
            Destroy(this.gameObject);
         }
    }
}
