using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Observer : MonoBehaviour
{

    public Transform player;
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;
    public bool deteccioninstantanea;
    public float tiempodeteccion;
    float timerdeteccion;
    public AudioClip watchSource;
    bool hasWatchAudioPlayed = false;

    [SerializeField] TextMeshProUGUI txtexclamacion;
    [SerializeField] GameObject exclamacion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position,direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray,out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    if(deteccioninstantanea ==true)
                    {

                        gameEnding.CaughtPlayer();


                    }
                    else
                    {

                        if (timerdeteccion >= tiempodeteccion)
                        {

                            gameEnding.CaughtPlayer();

                            Debug.Log("TE PILLE");

                        }
                        else
                        {

                            timerdeteccion +=Time.deltaTime;

                        }

                    }

                    
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
            txtexclamacion.text = " ! ";
           exclamacion.SetActive(true);
            Debug.Log("VERTE");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {

            m_IsPlayerInRange = false;
            timerdeteccion = 0;
            txtexclamacion.text = (" ! ");
            exclamacion.SetActive(false);

        }


    }


}
