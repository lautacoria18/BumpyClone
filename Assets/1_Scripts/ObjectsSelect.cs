using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectsSelect : MonoBehaviour
{
    public GameObject frame;
    public GameObject objectToSelect;
    public GameObject objectSelected;

    public bool isSelected;
    private void OnMouseDown()
    {
        if (isSelected)
        {
            frame.SetActive(false);
            isSelected = false;
            DropObjectManager.instance.objectSelected = null;
        }
        else
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("frame");
            Debug.Log(gos.Length);
            for (int i = 0; i < gos.Length; i++)
            {
                gos[i].SetActive(false);
                gos[i].transform.parent.GetComponent<ObjectsSelect>().isSelected = false;
                DropObjectManager.instance.objectSelected = null;
            }

            DropObjectManager.instance.objectSelected = objectToSelect;
            
            isSelected = true;
            
         
            frame.SetActive(true);
        }
    }
  
}
