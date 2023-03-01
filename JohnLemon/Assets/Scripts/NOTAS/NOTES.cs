using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NOTES : MonoBehaviour
{
    private int collectednotes, victoryCondition = 4;

    public bool puedesalir;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }

    }

    private static NOTES instance;

    public static NOTES MyInstance
    {

        get
        {

            if (instance == null)
                instance = new NOTES();

            return instance;
        }

    }
    private void Start()
    {
        NOTASCONTADOR.MyInstance.UpdateNoteUI(collectednotes, victoryCondition);

        puedesalir=false;
    }
    public void AddNotes(int _notes)
    {
        Debug.Log("CogerNotas");
            collectednotes +=_notes;
            NOTASCONTADOR.MyInstance.UpdateNoteUI(collectednotes, victoryCondition);
        
    }
    public void Finish()
    {

        if (collectednotes >= victoryCondition)

        {
            puedesalir=true;

        }
        else
        {
            NOTASCONTADOR.MyInstance.ShowVictoryCondition(collectednotes, victoryCondition);

        }


    }
    private void Update()
    {
        Debug.Log(collectednotes);
    }



}
