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
        Debug.Log((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString());
        SceneManager.LoadScene((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString() );
    
    }
    

    public void LoadMainMenu() {

        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel() {
        if (lifeSystem.GetLives() < 1)
        {

            Debug.Log("A esperar papi");

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
