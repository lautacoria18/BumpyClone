using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Ui : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused;
    public void PauseMenu() {

        if (!isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            isPaused = true;
        }
        else {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            isPaused = false;
        }
    
    }

    public void ReturnToMainMenu() {

        SceneManager.LoadScene("MainMenu");
    
    }
}
