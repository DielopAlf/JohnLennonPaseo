using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupspawner : MonoBehaviour

{
    [SerializeField]
    GameObject prefabpowerup;
    [SerializeField]
    GameObject[] puntosdeaparicion;
    [SerializeField]
    float tiempominimo, tiempomaximo;
    [SerializeField]
    float tiempoparaaparecer;
    [SerializeField]
    float tiempobase;

    bool puedecrearse;


    void Start()
    {
        tiempoparaaparecer = Random.Range(tiempominimo, tiempomaximo);
        
       
    }
    void CrearPowerup()
    {

        Instantiate(prefabpowerup, puntosdeaparicion[Random.Range(0, puntosdeaparicion.Length)].transform);
        tiempoparaaparecer = Random.Range(tiempominimo, tiempomaximo) + tiempobase;
        puedecrearse = false;

    }
    public void reiniciarpowerup()
    {

        tiempoparaaparecer = Random.Range(tiempominimo, tiempomaximo) + tiempobase;
        puedecrearse = true;


    }

    // Update is called once per frame
    void Update()
    {
        tiempoparaaparecer = tiempoparaaparecer - Time.deltaTime;
        if(tiempoparaaparecer<=0.0f)
        {

            CrearPowerup();

        }
    }
}
