using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class ScriptTest : MonoBehaviour
{
  public  Dictionary<string, List<string>> openWith =
            new Dictionary<string, List<string>>();
    // Start is called before the first frame update
    void Start()
    {
        
        openWith.Add("c0X0", new List<string>() { "ball", "coin", "base" });
        string json = JsonConvert.SerializeObject(openWith);
        Debug.Log(JsonConvert.SerializeObject(openWith));

        var values = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
        Debug.Log(values["c0X0"][0]);
        Debug.Log(values);
        Debug.Log(JsonUtility.ToJson(this));
        //Scene newScene = SceneManager.CreateScene("My New Scene");
        //string jason=  JsonUtility.ToJson(newScene, true);

        //File.WriteAllText(Application.dataPath + "/Weapon.json", jason);
        //Scene dobleScene = JsonUtility.FromJson<Scene>(jason);

        //SceneManager.LoadScene(dobleScene.name);
        //Debug.Log(jason);

        //LoadFromJson();
    }

    void LoadFromJson() {

        string json = File.ReadAllText(Application.dataPath + "/Weapon.json");
        string s = JsonUtility.FromJson<string>(json);
        Debug.Log(json);
       // Scene dobleScene = SceneManager.CreateScene();
        //dobleScene.

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
