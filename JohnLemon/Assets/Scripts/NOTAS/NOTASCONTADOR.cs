using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NOTASCONTADOR : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI TxTNotes, txtVictoryCondition;
    [SerializeField] GameObject victoryCondition;
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

    private static NOTASCONTADOR instance;

    public static NOTASCONTADOR MyInstance
    {

        get
        {

            if (instance == null)
                instance = new NOTASCONTADOR();

            return instance;
        }

    }
    public void UpdateNoteUI(int _notes, int _victoryCondition)
    {
        {
            TxTNotes.text = "Notes:" +_notes+" / " +_victoryCondition;
        }
    }
    public void ShowVictoryCondition(int _notes, int _victoryCondition)
    {
        victoryCondition.SetActive(true);
        txtVictoryCondition.text=" You need " +(_victoryCondition - _notes) +" more notes ";

    }
    public void HideVictoryCondition()
    {
        victoryCondition.SetActive(false);

    }
}





