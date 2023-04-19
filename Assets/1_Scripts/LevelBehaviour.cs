using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    public static LevelBehaviour instance;
    public int starsTaken;
    public int starsInLevel;

    public GameObject grid;

    public GameObject winPortal;
    private void Awake()
    {
        Time.timeScale = 1f;
        instance = this;


       // foreach (Transform child in grid.transform)
        {
        //    Debug.Log("gOLSDASDA?");
          //  child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        winPortal = GameObject.FindGameObjectWithTag("winportal");
        winPortal.SetActive(false);
        GameObject[] stars = GameObject.FindGameObjectsWithTag("star");
        starsInLevel = stars.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (starsTaken == starsInLevel) {

            if (winPortal)
            {
                winPortal.SetActive(true);
            }

        }
    }



}
