using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Text lives;
    public void StartGame() {


        SceneManager.LoadScene("1");
    }
    public void LoadSelectLevel() {


        SceneManager.LoadScene("SelectLevel");

    }

    private void Start()
    {
        
    }
    private void Update()
    {
        lives.text = LifeSystem.instance.GetLives().ToString();
    }

    public void DeleteData() {

        PlayerPrefs.DeleteAll();
    }
}
