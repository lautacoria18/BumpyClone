using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjectManager : MonoBehaviour
{
    public static DropObjectManager instance;

    public GameObject objectSelected;


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
