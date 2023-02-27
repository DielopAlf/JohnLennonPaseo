using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
     public float speed=2;


    

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * Time.deltaTime *speed);
    }
}
