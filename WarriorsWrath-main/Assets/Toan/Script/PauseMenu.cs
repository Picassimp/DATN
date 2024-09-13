using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;    
    [SerializeField] GameObject endGamePanel;

    private GameObject data;
    private bool isPause = false;

    void Start(){
        data = GameObject.FindGameObjectWithTag("Data");
    }
    private void Update()
    {
        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else if (!isPause)
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        data.GetComponent<dataHolder>().stopTimer();
        isPause = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        data.GetComponent<dataHolder>().startTimer();
        isPause = false;


    }
    public void Home(int sceneID)
    {
        isPause = false;
        SceneManager.LoadScene(sceneID);
    }

    public void endRun(){
        isPause = false;
        Destroy(GameObject.FindGameObjectWithTag("Player"));        
        Destroy(GameObject.FindGameObjectWithTag("GameUI"));
        data.GetComponent<dataHolder>().endGame();
        endGamePanel.SetActive(true);
    }
}
