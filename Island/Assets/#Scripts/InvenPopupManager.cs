using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

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
    public TextMeshProUGUI MaterialNameText;
    public TextMeshProUGUI MaterialInfoText;

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

        switch (str)
        {
            
            case "CButton":
                {
                    MaterialNameText.text = FoodData.Instance.Name[0];
                    MaterialInfoText.text = FoodData.Instance.Text[0];
                    break;
                }
            case "CButton (1)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[1];
                    MaterialInfoText.text = FoodData.Instance.Text[1];
                    break;
                }
            case "CButton (2)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[2];
                    MaterialInfoText.text = FoodData.Instance.Text[2];
                    break;
                }
            case "CButton (3)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[3];
                    MaterialInfoText.text = FoodData.Instance.Text[3];
                    break;
                }
            case "CButton (4)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[4];
                    MaterialInfoText.text = FoodData.Instance.Text[4];
                    break;
                }
            case "CButton (5)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[5];
                    MaterialInfoText.text = FoodData.Instance.Text[5];
                    break;
                }
            case "CButton (6)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[6];
                    MaterialInfoText.text = FoodData.Instance.Text[6];
                    break;
                }
            case "CButton (7)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[7];
                    MaterialInfoText.text = FoodData.Instance.Text[7];
                    break;
                }
            case "CButton (8)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[8];
                    MaterialInfoText.text = FoodData.Instance.Text[8];
                    break;
                }
            case "CButton (9)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[9];
                    MaterialInfoText.text = FoodData.Instance.Text[9];
                    break;
                }
            case "CButton (10)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[10];
                    MaterialInfoText.text = FoodData.Instance.Text[10];
                    break;
                }
            case "CButton (11)":
                {
                    MaterialNameText.text = FoodData.Instance.Name[11];
                    MaterialInfoText.text = FoodData.Instance.Text[11];
                    break;
                }
        }

    }

    public void ToolUpClicked() {
        sidePopup.SetActive(false);
        toolUpgradePop.SetActive(true);
    }

}
