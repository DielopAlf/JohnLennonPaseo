using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerNotas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag  == "Player")
        {
            NOTES.MyInstance.AddNotes(1);
            Destroy(this.gameObject);
        }
    }
}
