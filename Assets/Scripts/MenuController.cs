using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject panel;
    public GameObject gameOverScene;
    public bool gameIsPause;
    
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPause) {
               Resume();    
            }
            else {
               Pause();
            }
        }
        
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause() {
        pauseMenu.SetActive(true);
        panel.SetActive(true);
        settingsMenu.SetActive(false);
        gameIsPause = true;
        Time.timeScale = 0;
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        panel.SetActive(false);
        gameIsPause = false;
        Time.timeScale = 1;
    }
    public void Quit() {
        //Menu Sahnesine Geçi?
        SceneManager.LoadScene(0);
    }
    public void Settings() {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
