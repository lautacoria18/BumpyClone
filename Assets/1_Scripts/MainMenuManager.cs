using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Text lives;
    [SerializeField]
    private GameObject lifePanel;
    public void StartGame() {

        if (LifeSystem.instance.lives == 0)
        {

            lifePanel.SetActive(true);

        }
        else
        {
            SceneManager.LoadScene("1");
        }
    }
    public void LoadSelectLevel() {


        SceneManager.LoadScene("SelectLevel");

    }
    public void CloseLifePanel() {


        lifePanel.SetActive(false);
    }
    private void Update()
    {
        lives.text = LifeSystem.instance.GetLives().ToString();
    }

    public void DeleteData() {

        PlayerPrefs.DeleteAll();
    }
}
