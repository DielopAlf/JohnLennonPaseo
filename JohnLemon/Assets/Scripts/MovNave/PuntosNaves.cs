/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PuntosNaves : MonoBehaviour
{
    public TextMeshProUGUI textpuntos;
    public GameObject camaramuerte;
    public static PuntosNaves instance;
    int navesdestruidas;
    public GameObject canvasjuego;
    public GameObject canvasvictoria;
    public GameObject canvasGameover;
    public GameObject botonResetear;

    public GameObject jugador;

    // public TextMeshPro puntuacion;
    //public AudioSource collectSound;

    private void Awake()
    {
        if (PuntosNaves.instance == null)
        {

            PuntosNaves.instance = this;

        }
        else
        {
            Destroy(this);


        }
    }

    void Start()
    {
        navesdestruidas=0;
        canvasvictoria.SetActive(false);
        canvasjuego.SetActive(true);

    }

    public void navedestruidas()
    {
        navesdestruidas++;
        textpuntos.text = navesdestruidas.ToString() + " / 5 Naves Destruidas";
        if (navesdestruidas>=5)
        {
            canvasvictoria.SetActive(true);
            canvasjuego.SetActive(false);
            Destroy(jugador);

        }

    }
    public void gAMEOVER()
    {
        Destroy(jugador);
        canvasvictoria.SetActive(false);
        canvasjuego.SetActive(false);
        canvasGameover.SetActive(true);
        camaramuerte.SetActive(true);
    }
    public void ResetearPuntos()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    /*void Update()
    {
        // textpuntos.GetComponent<TextMeshProUGUI>().text="Naves 0/5" + puntos;

    }}*/

