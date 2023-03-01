using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TextMeshProUGUI tiempo;
    private float restante;
    private bool enmarcha;
    public static bool IsTimeOver;
    public GameEnding gameEnding;

    private void Awake()
    {
        restante = (min * 60) + seg;
        enmarcha = true;
        IsTimeOver= false;
    }

    private void Update()
    {
        if (enmarcha && !gameEnding.isGameOver) {
            restante -= Time.deltaTime;
        }
        
        if (restante < 1)
        {
            enmarcha = false;
            IsTimeOver = true;
            gameEnding.CaughtPlayer();
        }

        int tempMin = Mathf.FloorToInt(restante / 60);
        int tempSeg = Mathf.FloorToInt(restante % 60);
        tiempo.text = string.Format("{0:00}:{1:00}", tempMin, tempSeg);
    }
}
