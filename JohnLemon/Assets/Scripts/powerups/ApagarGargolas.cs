using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarGargolas : MonoBehaviour
{

    List<GameObject> Gargolas = new List<GameObject>();
    GameObject[] Enemigos;
    public GameObject malla;
    public float duracion;
    Material linterna;
     Vector4 albedo;

    void Start()
    {
     Enemigos=GameObject.FindGameObjectsWithTag("Enemigo");

     foreach(GameObject Enemigo in Enemigos)
     {
          if(Enemigo.name.Contains("Gargoyle"))
          {
                Gargolas.Add(Enemigo);
                Debug.Log("Add");
          }
     }

    }

  
    public void DesactivarGargolas()
    {
        foreach(GameObject Gargola in Gargolas)
        {
            Gargola.GetComponentInChildren<Observer>().enabled=false;
            linterna = Gargola.transform.Find("GargoyleModel").gameObject.GetComponent<Renderer>().materials[0];
            albedo = linterna.color;
            linterna.color =new Vector4(0f,0f,0f,0f);
        }

    }
    public void ActivarGargolas()
    {
        foreach(GameObject Gargola in Gargolas)
        {
            Gargola.GetComponentInChildren<Observer>().enabled=true;
            linterna.color=albedo;
        }
        
    }
     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           DesactivarGargolas();
           StartCoroutine(duracionefecto());
        }
    }
    public IEnumerator duracionefecto()
    {
        gameObject.GetComponent<SphereCollider>().enabled=false;
        malla.SetActive(false);

        yield return new WaitForSeconds(duracion);
        
        ActivarGargolas();
        Destroy(gameObject);
        
    }

     
}
