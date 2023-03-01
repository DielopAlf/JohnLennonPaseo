using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staminainfinita : MonoBehaviour
{
    public GameObject malla;
    public float duracion;
    PlayerMovement player;





   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player= other.gameObject.GetComponent<PlayerMovement>();
            player.staminainfinita= true;
            player.staminatimer= player.duracionstamina;
            StartCoroutine(duracionefecto());
        }
    }
    public IEnumerator duracionefecto()
    {
        gameObject.GetComponent<SphereCollider>().enabled=false;
        malla.SetActive(false);

        yield return new WaitForSeconds(duracion);

        player.staminainfinita=false;
        Destroy(gameObject);

    }
}
