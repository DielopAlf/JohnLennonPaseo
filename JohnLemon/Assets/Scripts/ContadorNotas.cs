using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorNotas : MonoBehaviour
{
    static public int notasEncontradas = 0;

    int notasMaximas = 1;

    Text Contador;

     

    void Awake()
    {
        Contador = GetComponent<Text>();
    }

    
    void Update()
    {
        Contador.text = "paginas cogidas:"+notasEncontradas.ToString();
        if(notasEncontradas >= notasMaximas)
        {



        }
    }
}
