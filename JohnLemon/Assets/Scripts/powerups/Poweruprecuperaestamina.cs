using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poweruprecuperaestamina : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().staminatimer=other.gameObject.GetComponent<PlayerMovement>().duracionstamina;

            Destroy(gameObject);
        }
        
    }
}
