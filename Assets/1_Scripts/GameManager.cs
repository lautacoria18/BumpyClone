using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string levelToLoad;
    [SerializeField]
    private int levelToLoadInt;
    public static GameManager instance;

            void Awake()
    {

        if (instance == null)
        {

            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void SetLevelLoad(string level) {

        levelToLoadInt = int.Parse(level);
        levelToLoad = "level" + level;
    }
    public string GetLevelToLoad() {

        return levelToLoad;
    
    }
    public int GetLevelInt()
    {

        return levelToLoadInt;

    }

}
