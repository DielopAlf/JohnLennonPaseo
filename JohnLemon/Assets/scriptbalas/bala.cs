using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabbala;

    [SerializeField]
    float tiempoentredisparos;

    float tiempopasado;
    [SerializeField]
    bool estapowerup = false;
    [SerializeField]
    float tiempoenpowerup;
    float tiempousadoenpowerup;
    [SerializeField]
    float coeficientedisparopowerup = 0.5f;
    float coeficienteactual = 1f;

    void Awake()
    {
        tiempopasado = tiempoentredisparos;
    }
   public void cogerpowerup()
    {

        coeficienteactual = coeficientedisparopowerup;
        estapowerup = true;
        tiempousadoenpowerup=0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        tiempopasado += Time.deltaTime;

        if(estapowerup==true)
        {
            //tiempopasado += Time.deltaTime;

            tiempousadoenpowerup += Time.deltaTime;

            if(tiempousadoenpowerup>tiempoenpowerup)
            {

                estapowerup = false;
                tiempousadoenpowerup= 0.0f;

            }

        }
        if(Input.GetKeyDown(KeyCode.Space) && tiempopasado >= tiempoentredisparos*coeficienteactual)
        {
            Instantiate(prefabbala, transform.position, Quaternion.identity);
            tiempopasado = 0f;
        }
    }
}
