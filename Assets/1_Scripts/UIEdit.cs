using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIEdit : MonoBehaviour
{
    public GameObject grid;

    public GameObject GridObject;
    public GameObject gridAtStart;
    private void Start()
    {
        Time.timeScale = 0f;
       
    }

    

    public void CleanAll() {

        CleanByString("ball");
        CleanByString("base");
        CleanByString("baseskipl");
        CleanByString("baseskipl2");
        CleanByString("baseskipr2");
        CleanByString("baseskipr");
        CleanByString("spike");
        CleanByString("star");

    }

    public void CleanByString(string text) {
        GameObject[] balls = GameObject.FindGameObjectsWithTag(text);
        foreach (GameObject o in balls)
        {

            Destroy(o);
        }


    }
    public void StartGameEditMode() {

        if (Time.timeScale == 0f)
        {
            Debug.Log("gOLA?");
            Time.timeScale = 1f;
            foreach (Transform child in grid.transform)
            {
                Debug.Log("gOLSDASDA?");
                child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }

        }
        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            foreach (Transform child in grid.transform)
            {

                child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

    }
}
