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

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }else if(m_IsPlayerCaught)
        {
            EndLevel(CaughtBackgroundImageCanvasGroup, true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
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
