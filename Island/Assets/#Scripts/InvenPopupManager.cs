using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InvenPopupManager : MonoBehaviour {
    public GameObject invenPopup;
    public GameObject matPop;
    public GameObject toolPop;
    public GameObject cookPop;
    public Button exitbutton1;
    public Button exitbutton2;
    public Button exitbutton3;
<<<<<<< HEAD
    public GameObject[] page;
    public Button toolLeft;
    public Button toolRight;
    private int pagenum = 0;
=======

>>>>>>> 7757d3909465e301273b8f2303f16a9705ea9461
    // Use this for initialization
    public void ExitButtonClick() {
        invenPopup.SetActive(false);
    }
    public void MatClick() {
        toolPop.SetActive(false);
        matPop.SetActive(true);
        cookPop.SetActive(false);
    }
    public void ToolClick()
    {
        toolPop.SetActive(true);
        matPop.SetActive(false);
        cookPop.SetActive(false);
    }
    public void CookClick()
    {
        cookPop.SetActive(true);
        toolPop.SetActive(false);
        matPop.SetActive(false);
    }
<<<<<<< HEAD

    public void ToolLeftClicked() {
        Debug.Log(pagenum);
        if (pagenum == 0)
        {
            pagenum = 0;
        }
        else {
            page[pagenum].SetActive(false);
            pagenum--;
            page[pagenum].SetActive(true);
        }
    }
    public void ToolRightClicked() {
        Debug.Log(pagenum);
        if (pagenum == 2)
        {
            pagenum = 2;
        }
        else
        {
            page[pagenum].SetActive(false);
            pagenum++;
            page[pagenum].SetActive(true);
        }

    }
=======
>>>>>>> 7757d3909465e301273b8f2303f16a9705ea9461
}
