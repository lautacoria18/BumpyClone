using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadFromFile : MonoBehaviour
{
    public List<GameObject> listOfCells = new List<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {
        string levelToLoad = GameManager.instance.GetLevelToLoad();
        string word = File.ReadAllText(Application.dataPath + "/" + levelToLoad + ".json");
        var dict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(word);


        foreach (GameObject singleCell in listOfCells)
        {

            ActiveObjectsInCell(singleCell.name, dict[singleCell.name]);

        }
    }


    public void ActiveObjectsInCell(string cellName, List<string> listOfObjects) {

       var cellInGame =  GameObject.Find(cellName);
        foreach (string obj in listOfObjects) {

            cellInGame.transform.Find(obj).gameObject.SetActive(true);

        }

    
    }
    public void DeserializeDictionary(string stringDict ) {

        string word = File.ReadAllText(Application.dataPath + "/level1.json");
        var dict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(word);
     

        foreach (GameObject singleCell in listOfCells) {

            Debug.Log(dict[singleCell.name]);
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
