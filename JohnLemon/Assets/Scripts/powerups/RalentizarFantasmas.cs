using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RalentizarFantasmas : MonoBehaviour
{

    List<GameObject> Fantasmas = new List<GameObject>();
    GameObject[] Enemigos;
    public GameObject malla;
    public float duracion;
    List<float> Speeds = new List<float>();
    [Range(0f, 1f)]
    public  float reduccionvelocidad;



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


    public void AlentarFantasma()
    {
        foreach (GameObject Ghost in Fantasmas)
        {


            Speeds.Add(Ghost.GetComponent<NavMeshAgent>().speed);
            Ghost.GetComponent<NavMeshAgent>().speed =  Ghost.GetComponent<NavMeshAgent>().speed * reduccionvelocidad;

        }

    }
    public void AcelerarFantasma()
    {
        int velocidad = 0;
        foreach (GameObject Ghost in Fantasmas)
        {

            Ghost.GetComponent<NavMeshAgent>().speed=Speeds[velocidad];
            velocidad+=1;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AlentarFantasma();
            StartCoroutine(duracionefecto());
        }
    }
    public IEnumerator duracionefecto()
    {
        gameObject.GetComponent<SphereCollider>().enabled=false;
        malla.SetActive(false);

        yield return new WaitForSeconds(duracion);

        AcelerarFantasma();
        Destroy(gameObject);

    }

    
}
