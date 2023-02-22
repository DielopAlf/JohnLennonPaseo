using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metralleta : MonoBehaviour
{
    [SerializeField]
    Vector3 direccionFuerza;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(direccionFuerza, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}
