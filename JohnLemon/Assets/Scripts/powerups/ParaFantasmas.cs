using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParaFantasmas : MonoBehaviour
{

    List<GameObject> Fantasmas = new List<GameObject>();
    GameObject[] Enemigos;
    public GameObject malla;
    public float duracion;


    void Start()
    {
        Enemigos=GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject Enemigo in Enemigos)
        {
            if (Enemigo.name.Contains("Ghost"))
            {
                Fantasmas.Add(Enemigo);
            }
        }
        

    }

    
    public void DesactivarFantasmas()
    {
        foreach (GameObject Ghost in Fantasmas)
        {
            Ghost.GetComponentInChildren<Observer>().enabled=false;
            Ghost.GetComponent<NavMeshAgent>().isStopped= true;
        }

    }
    public void ActivarFantasmas()
    {
        foreach (GameObject Ghost in Fantasmas)
        {

            Ghost.GetComponentInChildren<Observer>().enabled=true;
            Ghost.GetComponent<NavMeshAgent>().isStopped= false;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DesactivarFantasmas();
            StartCoroutine(duracionefecto());
        }
    }
    public IEnumerator duracionefecto()
    {
        gameObject.GetComponent<SphereCollider>().enabled=false;
        malla.SetActive(false);

        yield return new WaitForSeconds(duracion);

        ActivarFantasmas();
        Destroy(gameObject);

    }
    

}
