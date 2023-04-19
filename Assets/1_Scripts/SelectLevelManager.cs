using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lifePanel;

    public void LoadScene(int level) {
        if (LifeSystem.instance.lives == 0)
        {

            lifePanel.SetActive(true);

        }
        else
        {
            GameManager.instance.SetLevelLoad(level.ToString());
            SceneManager.LoadScene("Level");
            //SceneManager.LoadScene(level.ToString());
        }

    
    }

    public void ClosePanel() {


        GameObject.FindGameObjectWithTag("StagePanel").SetActive(false);
    
    }
    public void CloseLifePanel() {


        lifePanel.SetActive(false);


    }
    public void GoToMenu() {

        SceneManager.LoadScene("MainMenu");
    
    }
}
