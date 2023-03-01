/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform [] puntosspawn;
             
    [Range(0f,2f)]
    public float Tamanopunto=1f;
    public float tiempoMax= 40f;
    public float tiempoMin= 20f;
    int spawnprevio;
    public GameObject powerup;
    public float tiempoEspera = 15f;

    public void Start()
    {
        StartCoroutine(spawnpowerup(0));
       
    }


    public void OnDrawGizmos()
    {
        if(puntosspawn!=null && puntosspawn.Length>0)
        {
            for(int i =0; i < puntosspawn.Length; i++)
            {
               Gizmos.color=Color.yellow;
               Gizmos.DrawWireSphere(puntosspawn[i].position,Tamanopunto);

            }

            

        }
        

    }

     public IEnumerator spawnpowerup(float tiempoEspera)
     {
        int Randomspawn=Random.Range(0,puntosspawn.Length-1);
        while(Randomspawn== spawnprevio )
        {

          Randomspawn=Random.Range(0,puntosspawn.Length-1);
         
        }
          yield return new WaitForSeconds (tiempoEspera+Random.Range(tiempoMin,tiempoMax));

         spawnprevio=Randomspawn;
         GameObject newpowerup = Instantiate(powerup,puntosspawn[Randomspawn].transform.position,Quaternion.identity);
         newpowerup.GetComponent<boosted>().Spawner=this;
     }
     public void startSpawn()
     {

       StartCoroutine(spawnpowerup(tiempoEspera));
     
     }





}*/
