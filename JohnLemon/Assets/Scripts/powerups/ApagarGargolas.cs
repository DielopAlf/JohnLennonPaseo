using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarGargolas : MonoBehaviour
{

    List<GameObject> Gargolas = new List<GameObject>();
    GameObject[] Enemigos;
    public GameObject malla;
    public float duracion;
    List<Material> linternas  = new List<Material>();
    Color albedo;

    void Start()
    {
     Enemigos=GameObject.FindGameObjectsWithTag("Enemigo");

     foreach(GameObject Enemigo in Enemigos)
     {
          if(Enemigo.name.Contains("Gargoyle"))
          {
                Gargolas.Add(Enemigo);
          }
     }

    }

  
    public void DesactivarGargolas()
    {
        int linterna = 0;
        foreach(GameObject Gargola in Gargolas)
        {
            Gargola.GetComponentInChildren<Observer>().enabled=false;
            linternas.Add(Gargola.transform.Find("GargoyleModel").gameObject.GetComponent<Renderer>().materials[0]); 
            albedo = linternas[linterna].color;
            linternas[linterna].color =new Vector4(0f,0f,0f,0f);
            linterna += 1;
        }

    }
    public void ActivarGargolas()
    {
        int linterna = 0;
        foreach(GameObject Gargola in Gargolas)
        {

            Gargola.GetComponentInChildren<Observer>().enabled=true;
            linternas[linterna].color = albedo;
            linterna +=1;
        }
        //si 
        //si ya que estamos
        //si
        //los mas complicados 
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
