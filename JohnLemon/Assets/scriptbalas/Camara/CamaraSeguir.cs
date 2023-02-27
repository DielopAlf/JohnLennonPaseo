using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    [Tooltip("posiciones de camara")]
    [SerializeField]Transform[] povs;
    [Tooltip("la velocidad a la que la sigue")]
    [SerializeField] float speed;

    private int index = 1;
    private Vector3 target;

    private void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        else if(Input.GetKeyDown(KeyCode.Alpha2)) index= 1;
        else if(Input.GetKeyDown(KeyCode.Alpha3)) index= 2;
        else if(Input.GetKeyDown(KeyCode.Alpha4)) index= 3;

        target = povs[index].position;
    } 

     private void FixedUpdate()
    {
       transform.position= Vector3.MoveTowards(transform.position,target, Time.deltaTime * speed);
       transform.forward= povs[index].forward;
    }
}
