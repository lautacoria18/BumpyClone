using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public Text timeLeft;
    public static LifeSystem instance;
    [SerializeField]
    private int maxLives;

    //Each life replenishes in 15minutes or 900 seconds
    public float lifeReplenishTime;

    // The number of lives that the player has
    int _lives;
    public int lives
    {
        set
        {
            _lives = value;
            PlayerPrefs.SetInt("Lives", _lives);
        }
        get
        {
            return _lives;
        }
    }
    public double timerForLife;


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

        if (!PlayerPrefs.HasKey("Lives"))
        {
            PlayerPrefs.SetString("LifeUpdateTime", DateTime.Now.ToString());
        }
        lives = PlayerPrefs.GetInt("Lives", maxLives);

        //update life counter only if lives are less than maxLives
        if (lives < maxLives)
        {
            //timerToAdd calculates the time lapsed till since the game was last shut down
            float timerToAdd = (float)(System.DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("LifeUpdateTime"))).TotalSeconds;
            //update life counter depending upon how much time has been lapsed
            UpdateLives(timerToAdd);
        }
    }

    DateTime timeOfPause;
    void OnApplicationPause(bool isPause)
    {
        if (isPause)
        {
            //save the system time at which the application went in background 
            timeOfPause = System.DateTime.Now;
        }
        else
        {
            if (timeOfPause == default(DateTime))
            {
                timeOfPause = System.DateTime.Now;
            }
            float timerToAdd = (float)(System.DateTime.Now - timeOfPause).TotalSeconds;
            timerForLife += timerToAdd;
            UpdateLives(timerForLife);
        }
    }

    public string showLifeTimeInMinutes()
    {
        float timeLeft = lifeReplenishTime - (float)timerForLife;
        int min = Mathf.FloorToInt(timeLeft / 60);
        int sec = Mathf.FloorToInt(timeLeft % 60);
        return min + ":" + sec.ToString("00");
    }

    private void Update()
    {
        // life counter needs update only if lives are less than maxLives
        if (lives < maxLives)
        {
            timerForLife += Time.deltaTime;
            //when timerForLife becomes greater than 900sec, we update a life
            if (timerForLife > lifeReplenishTime)
            {
                //lives++; //you get a life after 15 minutes
                //It is advised to use UpdateLives(timerForLife) here instead of lives++;
                UpdateLives(timerForLife);
            }
        }
        Debug.Log(showLifeTimeInMinutes());
        if (!timeLeft)
        {
           
                timeLeft = GameObject.Find("timeLeft_2").GetComponent<Text>();
           

        }
        if (lives < maxLives)
        {
            if (GameObject.Find("timeLeft"))
            {
                GameObject.Find("timeLeft").GetComponent<Text>().text = showLifeTimeInMinutes();
            }
            timeLeft.text = showLifeTimeInMinutes();
           
        }
        else timeLeft.text = "";
    }

    void UpdateLives(double timerToAdd)
    {
        if (lives < maxLives)
        {
            int livesToAdd = Mathf.FloorToInt((float)timerToAdd / lifeReplenishTime);
            timerForLife = (float)timerToAdd % lifeReplenishTime;
            lives += livesToAdd;
            if (lives > maxLives)
            {
                lives = maxLives;
                timerForLife = 0;
            }
        }
        PlayerPrefs.SetString("LifeUpdateTime", DateTime.Now.ToString());
    }

    public int GetLives() {

        return lives;
    }

    public void AddLive(int cant) {

        lives += cant;
    
    }

    public void RemoveLive() {

        lives--;

    }

}
