using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PilotoNave : MonoBehaviour


{
    public GameObject proyectil;
    public float speed = -90.0f;
    public float Timer, TiempoDeEspera;
    public GameObject lugarproyectil;

    public Transform NaveEjes;
    public float velocidadMax;
    float velocidad;
    public float velocidadRotacion;
    Rigidbody rb;
    public float combustibleinicial = 100f;
    float combustible;
    public float multiplicadorgasto = 0.5f;
    public Slider combustibleslider;
    public float TiempoDisparo=0.75f;
    float timerdisparo;
    bool disparando;

    public void start()
    {

        timerdisparo=0;
        disparando=false;

    }
    
    // Update is called once per frame
    void Update()
    {
        /*transform.position += transform.forward * Time.deltaTime* speed;

        speed -= transform.forward.y * Time.deltaTime * -50.0f;

        if(speed < 5.0f)
        {
            speed= -5.0f;

        }
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));*/

        //if (Input.GetKeyDown(KeyCode.Space))//&& Timer<=0)
       // {

         //   GameObject bala = Instantiate(proyectil, lugarproyectil.transform.position, lugarproyectil.transform.rotation);
          //  Debug.Log("BALAS");
            //bala.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
            //bala.transform.position = transform.position - transform.forward * 1.5f; 
            //Instantiate(bala, transform.position, Quaternion.Euler(0, 0, -90));





            // Timer = TiempoDeEspera;
       // }




        /*if (aplicardaño.gameObject.tag == "")
        {
            Debug.Log("GOL! DEL Jugador2");
            PuntosNaves.instance.navedestruidas();
        }*/
        //  Timer -= Time.deltaTime;
        disparo();
    }
    public void disparo()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            disparando=true;
           
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {

            timerdisparo=0f;
            disparando=false;

        }
        
        if (disparando==true)
        {

               if (timerdisparo>0f)
               {
                timerdisparo-=Time.deltaTime;
  
               }
               else
               {
                
                timerdisparo=TiempoDisparo;
                GameObject bala = Instantiate(proyectil, lugarproyectil.transform.position, lugarproyectil.transform.rotation);
                Debug.Log("disparo");
 

               }


        }

    }
    public  IEnumerator aumentocadencia(float divisor,float duracion)
    {
        float antiguotiempo = TiempoDisparo;
        TiempoDisparo=antiguotiempo/divisor;
        Debug.Log(TiempoDisparo);
        yield return new WaitForSeconds(duracion);
        TiempoDisparo = antiguotiempo; 
        Debug.Log(TiempoDisparo);

    }
   public void boostedcogido(float divisor,float duracion)
   {
     StartCoroutine(aumentocadencia(divisor,duracion));

   }
}