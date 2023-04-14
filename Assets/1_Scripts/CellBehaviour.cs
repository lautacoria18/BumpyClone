using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    public GameObject leftCell, rightCell, upCell, downCell;
    public GameObject currentObject;

    public GameObject currentBase;

    public bool isWall;
  

    private void OnMouseDown()
    {
        if (!isWall)
        {
            Debug.Log("Toca");
            if (DropObjectManager.instance.objectSelected)
            {
                if (DropObjectManager.instance.objectSelected.name == "Ball")
                {

                    CheckIfIsBall();
                    Debug.Log("ball");

                }
                else if (DropObjectManager.instance.objectSelected.name == "Star")
                {

                    CheckIfIsStar();

                }
                else if (DropObjectManager.instance.objectSelected.name == "WinPortal")
                {

                    CheckIfIsStar();

                }
                else
                {
                    NormalObject();
                    Debug.Log("NotBall");
                }



            }
        }
        
    }
    void CheckIfIsStar()
    {
        if (transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.activeSelf)
        {
            transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.SetActive(false);
        }
        else
        {
            transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.SetActive(true);

        }


    }
    void CheckIfIsBall()
    {
        if (transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.activeSelf)
        {
            transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.SetActive(false);

        }
        else
        {
            if (GameObject.FindGameObjectWithTag("ball"))
            {
                Destroy(GameObject.FindGameObjectWithTag("ball"));
                GameObject.FindGameObjectWithTag("ball").SetActive(false);

            }
            transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.SetActive(true);

        }


    }
    void NormalObject() {

        if (DropObjectManager.instance.objectSelected)
        {
            if (transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.activeSelf)

            {
                Debug.Log("nmo");
                transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.SetActive(false);

            }
            else
            {
                if (currentBase && currentBase.activeSelf)
                {
                    currentBase.SetActive(false);
                }
                currentBase = transform.Find(DropObjectManager.instance.objectSelected.name).gameObject;
                transform.Find(DropObjectManager.instance.objectSelected.name).gameObject.SetActive(true);
                Debug.Log("si");


            }

        }

    }
}
