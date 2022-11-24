using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    public GameObject player;

    public float fadeDuration = 1.0f;

    float m_Timer;
    public float displayImageDuration = 1.0f;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup CaughtBackgroundImageCanvasGroup;

    public AudioSource exitAudio;
    public AudioSource caughtAudit;
    bool m_HasAudioPlayed;
    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }else if(m_IsPlayerCaught)
        {
            EndLevel(CaughtBackgroundImageCanvasGroup, true, caughtAudit);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer/fadeDuration;
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if(doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
            //Application.Quit();
            UnityEditor.EditorApplication.isPlaying= false;
            }
        }
        
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;

    }
}
