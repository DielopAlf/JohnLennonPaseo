using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource  exitsource;
    public AudioSource  caughtsource;
    bool m_hasAudioPlayed=false;
    bool m_IsPlayerAtExit; 
    bool m_IsPlayerCaught;
    float m_Timer;

    void Update ()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup,false, exitsource);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel (caughtBackgroundImageCanvasGroup,true,caughtsource);
             
        }
       
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught=true;

    }

   private  void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
       if (m_hasAudioPlayed==false)
       {
         audioSource.Play();
         m_hasAudioPlayed = true;
       }
        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if(doRestart)
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

