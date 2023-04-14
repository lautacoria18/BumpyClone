using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIEdit : MonoBehaviour
{
    public GameObject grid;


    public GameObject GridObject;
    public GameObject gridAtStart;
    #region Rows 
    [Header("0 Row")]
    public GameObject c0x0;
    public GameObject c0x1, c0x2, c0x3, c0x4, c0x5;
    [Header("1 Row")]
    public GameObject c1x0;
    public GameObject c1x1, c1x2, c1x3, c1x4, c1x5;
    [Header("2 Row")]
    public GameObject c2x0;
    public GameObject c2x1, c2x2, c2x3, c2x4, c2x5;
    [Header("3 Row")]
    public GameObject c3x0;
    public GameObject c3x1, c3x2, c3x3, c3x4, c3x5;
    [Header("4 Row")]
    public GameObject c4x0;
    public GameObject c4x1, c4x2, c4x3, c4x4, c4x5;
    [Header("5 Row")]
    public GameObject c5x0;
    public GameObject c5x1, c5x2, c5x3, c5x4, c5x5;
    [Header("6 Row")]
    public GameObject c6x0;
    public GameObject c6x1, c6x2, c6x3, c6x4, c6x5;
    [Header("7 Row")]
    public GameObject c7x0;
    public GameObject c7x1, c7x2, c7x3, c7x4, c7x5;
    #endregion

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
