using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class NaveEnemiga : MonoBehaviour
{



    public float speed = 5.0f;
    public GameObject navejugador;
    public float Vida;
    public Slider barradevida;
    //public AudioSource collectSound;


    public WayPoint ruta;

    int puntoActual;

    public float margenhastapunto=0.1f;

    Vector3 siguientepunto;

    void Start()
    {       
        transform.position = ruta.puntosruta[0].position;
        puntoActual=0;
        CalcularSiguientePunto();
        transform.LookAt(ruta.puntosruta[0]);
        barradevida.maxValue=Vida;
        barradevida.value=Vida;

    }

    void Update()
    {
        Movimiento();
        if(navejugador!=null)
        {

            barradevida.transform.rotation=Quaternion.LookRotation(barradevida.transform.position-navejugador.transform.position);


        }


    }
    public void Movimiento()
    {
       transform.position=Vector3.MoveTowards(transform.position,siguientepunto,speed*Time.deltaTime);
       if(Vector3.Distance(transform.position,siguientepunto)<margenhastapunto)
       {
            CalcularSiguientePunto();    
       }
    }
    public void CalcularSiguientePunto()
    {
        if(puntoActual+1<=ruta.puntosruta.Length-1)
        {
            puntoActual ++;
            siguientepunto = ruta.puntosruta[puntoActual].position;
            transform.LookAt(siguientepunto);

        }
        else
        {
            puntoActual=0;

            siguientepunto = ruta.puntosruta[puntoActual].position;
            transform.LookAt(siguientepunto);
        }
     

    }

    public void aplicardano(float daño)
    {
        Vida = Vida-daño;
        barradevida.value=Vida;
        if (Vida<=0)
        {
            muerte();

        }

    }
    public void muerte()
    {
        //collectSound.Play();
       //PuntosNaves.puntos+=1;
        Destroy(gameObject);
        PuntosNaves.instance.navedestruidas();
    }
}
