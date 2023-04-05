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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        if (gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)"))
        {
            GameObject objToDestroy = gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)").gameObject;
            Destroy(objToDestroy);
            return;
        }
        else
        {
            GameObject obj = Instantiate(DropObjectManager.instance.objectSelected);
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localScale = new Vector3(0.3290634f, 0.3488765f, 0.6944444f);
            obj.transform.localPosition = new Vector3(0, 0, 0);
        }


    }
    void CheckIfIsBall()
    {
        if (gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)"))
        {
            GameObject objToDestroy = gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)").gameObject;
            Destroy(objToDestroy);
            return;
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("ball"))
            {
                Destroy(GameObject.FindGameObjectWithTag("ball"));

            }
            GameObject obj = Instantiate(DropObjectManager.instance.objectSelected);
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localScale = new Vector3(0.3290634f, 0.3488765f, 0.6944444f);
            obj.transform.localPosition = new Vector3(0, 0, 0);
        }


    }
    void NormalObject() {

        if (DropObjectManager.instance.objectSelected)
        {
            Debug.Log(DropObjectManager.instance.objectSelected.name + "(Clone)");
            if (gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)"))
            {
                GameObject objToDestroy = gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)").gameObject;
                Destroy(objToDestroy);
                return;
            }
            else
            {
                Debug.Log("obnjetooo");
                GameObject obj = Instantiate(DropObjectManager.instance.objectSelected);
                if (currentBase)
                {
                    Destroy(currentBase);
                }
                currentBase = obj;
                obj.transform.SetParent(gameObject.transform);
                obj.transform.localScale = new Vector3(0.8837325f, 0.05037692f, 0.9259259f);
                if (obj.tag == "base")
                {

                    obj.transform.localPosition = new Vector3(0, -0.4f, 0);
                }
                else if (obj.tag == "baseskipl" || obj.tag == "baseskipr" || obj.tag == "baseskipl2" || obj.tag == "baseskipr2" ) {

                    obj.transform.localPosition = new Vector3(0, -0.3f, 0);
                }
                else if (obj.tag == "spike")
                {

                    obj.transform.localPosition = new Vector3(0, -0.4f, 0);
                }
                if (obj.tag == "star" || obj.tag == "winportal")
                {

                    obj.transform.localPosition = new Vector3(0, 0f, 0);
                    obj.transform.localScale = new Vector3(0.38f, 0.21f, 0.39f);
                }


            }

        }

    }
}
/*if (DropObjectManager.instance.objectSelected) {
           Debug.Log(DropObjectManager.instance.objectSelected.name + "(Clone)");
           if (gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)"))
           {
               GameObject objToDestroy = gameObject.transform.Find(DropObjectManager.instance.objectSelected.name + "(Clone)").gameObject;
               Destroy(objToDestroy);
               return;
           }
           else
           {
               Debug.Log("obnjetooo");
               GameObject obj = Instantiate(DropObjectManager.instance.objectSelected);
               obj.transform.SetParent(gameObject.transform);
               obj.transform.localScale = new Vector3(0.8837325f, 0.05037692f, 0.9259259f);
               obj.transform.localPosition = new Vector3(0, -0.4f, 0);
           }

       }
       */
