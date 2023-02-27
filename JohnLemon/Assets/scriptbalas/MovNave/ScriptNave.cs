using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptNave : MonoBehaviour
{
    public Transform NaveEjes;
    public float velocidadMax;
    float velocidad;
    public float velocidadRotacion;
    Rigidbody rb;
    public float combustibleinicial = 100f;
    float combustible;
    public float multiplicadorgasto = 0.5f;
    public Slider combustibleslider;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        combustible=combustibleinicial;
        velocidad=0f;
        combustibleslider.maxValue=combustibleinicial;
        combustibleslider.value=combustible;
        //para empezar volando

    }

    void FixedUpdate()
    {
        if (combustible>0)
        {
            rotar();
            acelerar();
            gastocombustible();

        }
        else
        {
            if (rb.useGravity==false)
            {

                rb.useGravity=true;


            }


        }

    }






    void rotar()
    {
        float yaw = velocidadRotacion * Input.GetAxis("Rotate") * Time.deltaTime;
        float pitch = velocidadRotacion * Input.GetAxis("Vertical") * Time.deltaTime;
        float roll = velocidadRotacion * Input.GetAxis("Horizontal") * Time.deltaTime;

        NaveEjes.Rotate(pitch, yaw, roll);



    }
    void acelerar()
    {

        if (velocidad < velocidadMax)
        {

            velocidad += Input.GetAxis("Acelerar") * Time.deltaTime * 1.5f;


        }

        if (velocidad > velocidadMax * (-1f))
        {

            velocidad += Input.GetAxis("Acelerar") * Time.deltaTime * 1.5f;


        }

       // Debug.Log("velocidad: "+velocidad);


        NaveEjes.position += NaveEjes.forward * velocidad * Time.deltaTime;
    }

    public void empezaramoverse()
    {
        velocidad=velocidadMax*-1;


    }

   
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lata")&& combustibleinicial>0f)
        {
            combustible += 30f;
            

            if (combustible > combustibleinicial)
            {
                combustible = combustibleinicial;


            }
           // Debug.Log("destruida");
            Destroy(other.gameObject);
            
        }

      if (other.CompareTag("terreno")||other.CompareTag("Enemy"))
        {
            PuntosNaves.instance.gAMEOVER();

        }


    }
    public void gastocombustible()
    {
        float gasto = Mathf.Abs(velocidad) * multiplicadorgasto * Time.deltaTime;
        if (combustible > 0)
        {

            //Debug.Log("combustible: " + combustible);
            combustible = combustible - gasto;
            combustibleslider.value = combustible;

        }

    }
}
    /*private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("terreno")||other.CompareTag("Enemy"))
        {
            PuntosNaves.instance.gAMEOVER();

        }
        if (other.CompareTag("Lata"))
        {
            combustibleinicial += 10f;
            if (combustibleinicial > 100f)
            {
                combustibleinicial = 100f;

            }
            Destroy(gameObject);

        }

    }

}

/* private void OnTriggerEnter(Collider other)
 {
     if(other.CompareTag("Lata")&& combustibleinicial>0f)
     {
         combustibleinicial += 10f;
         if (combustibleinicial > 100f)
         {
             combustibleinicial = 100f;

         }
         Destroy(gameObject);

     }
 } */


