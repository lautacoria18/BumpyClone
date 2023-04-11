using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_UI : MonoBehaviour
{
    public Button s1, s2, s3, s4, s5, s6;
    public GameObject ps1, ps2, ps3, ps4, ps5, ps6;

    private void Start()
    {
        s1.onClick.AddListener(delegate { OpenStagePanel(1); });
        s2.onClick.AddListener(delegate { OpenStagePanel(2); });
        s3.onClick.AddListener(delegate { OpenStagePanel(3); });
        s4.onClick.AddListener(delegate { OpenStagePanel(4); });
        s5.onClick.AddListener(delegate { OpenStagePanel(5); });
        s6.onClick.AddListener(delegate { OpenStagePanel(6); });
    }


    public void OpenStagePanel(int numero) {

        switch (numero) {

            case 1:
                ps1.SetActive(true);
                break;
            case 2:
                ps2.SetActive(true);
                break;
            case 3:
                ps3.SetActive(true);
                break;
            case 4:
                ps4.SetActive(true);
                break;
            case 5:
                ps5.SetActive(true);
                break;
            case 6:
                ps6.SetActive(true);
                break;

        }
    
    }
}
