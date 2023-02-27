using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimacion : MonoBehaviour
{
    public GameObject timeline;

    public float duracionanimacion;



    public GameObject nave;

    public void Start()
    {
        nave.SetActive(false);
        timeline.SetActive(true);
        StartCoroutine(Empezarjuego());
    }

    public IEnumerator Empezarjuego()
    {
        yield return new WaitForSeconds(duracionanimacion);
        Destroy(timeline);
        nave.SetActive(true);
           
            
    }
}
