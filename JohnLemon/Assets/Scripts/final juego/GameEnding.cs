using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitSource;
    public AudioSource caughtSource;
    bool hasExitAudioPlayed = false;
    bool hasCaughtAudioPlayed = false;
    public bool isGameOver;
    bool isPlayerAtExit;
    bool isPlayerCaught;
    float timer;
    public bool resetAcabar;

    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, resetAcabar, exitSource);
        }
        else if (isPlayerCaught || Timer.IsTimeOver)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtSource);
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = false;
           // NOTASCONTADOR.MyInstance.HideVictoryCondition();
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (isPlayerAtExit || isPlayerCaught || Timer.IsTimeOver)
        {
            isGameOver = true;
          //  NOTES.MyInstance.Finish();
           // if (NOTES.MyInstance.puedesalir)
            {
               
            }
        }
        if (!hasExitAudioPlayed && isPlayerAtExit)
        {
            audioSource.Play();
            hasExitAudioPlayed = true;
        }
        else if (!hasCaughtAudioPlayed && (isPlayerCaught || Timer.IsTimeOver))
        {
            audioSource.Play();
            hasCaughtAudioPlayed = true;
        }
        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
