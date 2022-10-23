using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvas_manager : MonoBehaviour
{
    public GameObject pauseBtn;
    public GameObject pausePanel;
    public GameObject GameOverPanel;
    private bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
        GameOverPanel.SetActive(true);
        pauseBtn.SetActive(true);
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        Time.timeScale = 0;
    }

    public void PausePlay(){
        if(isPause)
        {
            isPause = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            pauseBtn.SetActive(true);
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.Play();
            }

        }
        else
        {
            isPause = true;
            Time.timeScale = 0;
            pauseBtn.SetActive(false);
            pausePanel.SetActive(true);
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }
    }

    public void restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }


}

