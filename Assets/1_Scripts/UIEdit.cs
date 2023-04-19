using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UIEdit : MonoBehaviour
{
    public GameObject grid;


    public GameObject GridObject;
    public GameObject gridAtStart;

    public CellBehaviour c0x0;


    public List<GameObject> cellList = new List<GameObject>();

    public Dictionary<string, List<string>> cell1Sample =
           new Dictionary<string, List<string>>();

    public List<string> listOfJson = new List<string>();

    private Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
  



    private void Start()
    {
        Time.timeScale = 0f;
        cell1Sample.Add("c0X0", new List<string>() { "Ball", "Star", "Base" });
        string json = JsonConvert.SerializeObject(cell1Sample);
        var values = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
        Debug.Log(values["c0X0"][0]);
        if (c0x0.gameObject.transform.Find(values["c0X0"][0])) {


            c0x0.gameObject.transform.Find(values["c0X0"][0]).gameObject.SetActive(true);


        }
        string word = File.ReadAllText(Application.dataPath + "/listOfJson.json");
        List<string> jsonList = JsonConvert.DeserializeObject<List<string>>(word);
        foreach (string jason in jsonList)
            Debug.Log(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jason));
        //Debug.Log(jason);
        //Debug.Log(word);

    }

    public void SaveLevelInJson() {

        foreach (GameObject singleCell in cellList) {

            SaveCell(singleCell);
        }
   
        string json = JsonConvert.SerializeObject(dict);
        if (!PlayerPrefs.HasKey("levelSaved"))
        {
            PlayerPrefs.SetInt("levelSaved", 1);
        }

        File.WriteAllText(Application.dataPath + "/level" + PlayerPrefs.GetInt("levelSaved").ToString() + ".json", json);
        PlayerPrefs.SetInt("levelSaved", PlayerPrefs.GetInt("levelSaved") + 1);

    }

    public void SaveCell(GameObject cell) {


        List<string> list = new List<string>();

        foreach (Transform child in cell.transform) { 
        
            if (child.gameObject.activeSelf && child.name != "Circle" && child.name != "Empty")
                list.Add(child.name);
        
        }
        dict.Add(cell.name, list);
        string json = JsonConvert.SerializeObject(dict);
        listOfJson.Add(json);



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
