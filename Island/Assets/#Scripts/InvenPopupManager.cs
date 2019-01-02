using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class InvenPopupManager : MonoBehaviour {
    public GameObject invenPopup;
    public GameObject matPop;
    public GameObject toolPop;
    public GameObject cookPop;
    public Button exitbutton1;
    public Button exitbutton2;
    public Button exitbutton3;
    public GameObject sidePopup;
    public GameObject toolUpgradePop;
    public GameObject[] page;
    public Button toolLeft;
    public Button toolRight;
    public Button toolUpButton;
    private int pagenum = 0;
    public Button[] matButton;
    public Button[] toolButton;
    public Button[] cookButton;
    public Image icon;
    public Image tool_icon1;
    public Image tool_icon2;

    // Use this for initialization
    public void ExitButtonClick() {
        toolUpgradePop.SetActive(false);
        sidePopup.SetActive(false);
        invenPopup.SetActive(false);
    }
    public void MatClick() {
        toolUpgradePop.SetActive(false);
        sidePopup.SetActive(false);
        toolPop.SetActive(false);
        matPop.SetActive(true);
        cookPop.SetActive(false);
    }
    public void ToolClick()
    {
        toolUpgradePop.SetActive(false);
        sidePopup.SetActive(false);
        toolPop.SetActive(true);
        matPop.SetActive(false);
        cookPop.SetActive(false);
    }
    public void CookClick()
    {
        toolUpgradePop.SetActive(false);
        sidePopup.SetActive(false);
        cookPop.SetActive(true);
        toolPop.SetActive(false);
        matPop.SetActive(false);
    }


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

    public void IconClicked() {
        
        string str = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(str);


        if (toolUpgradePop.activeSelf == true)
        {
            //sidePopup.SetActive(false);
            tool_icon1.overrideSprite = GameObject.Find(str).GetComponent<Image>().sprite;
            tool_icon2.overrideSprite = GameObject.Find(str).GetComponent<Image>().sprite;
        }
        else {
            sidePopup.SetActive(true);
            icon.overrideSprite = GameObject.Find(str).GetComponent<Image>().sprite;
        }
    }

    public void ToolUpClicked() {
        sidePopup.SetActive(false);
        toolUpgradePop.SetActive(true);
    }

}
