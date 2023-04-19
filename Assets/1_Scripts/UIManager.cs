using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject WinPanel;
    public GameObject LostPanel;
    public GameObject LifePanel;
    public Text level;
    public Text lives;

    private LifeSystem lifeSystem;
    private void Awake()
    {
        instance = this;
        level.text = SceneManager.GetActiveScene().name.ToString();
    }

    private void Start()
    {
        lifeSystem = LifeSystem.instance;
    }
    private void Update()
    {
        lives.text = lifeSystem.GetLives().ToString();
    }
    public void LevelWin() {

        WinPanel.SetActive(true);    

    }
    public void LevelLost()
    {
       lifeSystem.RemoveLive();
       LostPanel.SetActive(true);

    }

    public void LoadSelectLevel() {
        
        SceneManager.LoadScene("SelectLevel");
    }
    public void LoadNextLevel() {
        //Debug.Log((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString());
        GameManager.instance.SetLevelLoad((GameManager.instance.GetLevelInt() + 1).ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString() );

    }
    

    public void LoadMainMenu() {

        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel() {
        if (lifeSystem.GetLives() < 1)
        {
            OpenLifePanel();
            Debug.Log("A esperar papi");

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OpenLifePanel()
    {
        LifePanel.SetActive(true);


    }
    public void CloseLifePanel()
    {


        LifePanel.SetActive(false);

    }

}
