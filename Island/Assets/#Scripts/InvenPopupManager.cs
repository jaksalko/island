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
            case "MButton":
                {
                    MaterialNameText.text = MaterialData.Instance.Name[0];
                    MaterialInfoText.text = MaterialData.Instance.Text[0];
                    Debug.Log(MaterialData.Instance.Text[0]);
                    break;
                }
            case "MButton (1)":
                {
                    MaterialNameText.text = MaterialData.Instance.Name[1];
                    MaterialInfoText.text = MaterialData.Instance.Text[1];
                    break;
                }
            case "MButton (2)":
                {
                    MaterialNameText.text = MaterialData.Instance.Name[2];
                    MaterialInfoText.text = MaterialData.Instance.Text[2];
                    break;
                }
            case "MButton (3)":
                {
                    MaterialNameText.text = MaterialData.Instance.Name[3];
                    MaterialInfoText.text = MaterialData.Instance.Text[3];
                    break;
                }
            case "MButton (4)":
                {
                    MaterialNameText.text = MaterialData.Instance.Name[4];
                    MaterialInfoText.text = MaterialData.Instance.Text[4];
                    break;
                }
           
            case "MButton (5)":
                {
                    MaterialNameText.text = MaterialData.Instance.Name[5];
                    MaterialInfoText.text = MaterialData.Instance.Text[5];
                    break;
                }
            case "MButton (6)":
                {
                    MaterialNameText.text = MaterialData.Instance.Name[6];
                    MaterialInfoText.text = MaterialData.Instance.Text[6];
                    break;
                }
            case "TButton (0)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[0];
                    MaterialInfoText.text = ToolData.Instance.Text[0];
                    break;
                }
            case "TButton (1)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[1];
                    MaterialInfoText.text = ToolData.Instance.Text[1];
                    break;
                }
            case "TButton (2)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[2];
                    MaterialInfoText.text = ToolData.Instance.Text[2];
                    break;
                }
            case "TButton (3)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[3];
                    MaterialInfoText.text = ToolData.Instance.Text[3];
                    break;
                }
            case "TButton (4)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[4];
                    MaterialInfoText.text = ToolData.Instance.Text[4];
                    break;
                }
            case "TButton (5)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[5];
                    MaterialInfoText.text = ToolData.Instance.Text[5];
                    break;
                }
            case "TButton (6)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[6];
                    MaterialInfoText.text = ToolData.Instance.Text[6];
                    break;
                }
            case "TButton (7)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[7];
                    MaterialInfoText.text = ToolData.Instance.Text[7];
                    break;
                }
            case "TButton (8)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[8];
                    MaterialInfoText.text = ToolData.Instance.Text[8];
                    break;
                }
            case "TButton1 (0)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[9];
                    MaterialInfoText.text = ToolData.Instance.Text[9];
                    break;
                }
            case "TButton1 (1)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[10];
                    MaterialInfoText.text = ToolData.Instance.Text[10];
                    break;
                }
            case "TButton1 (2)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[11];
                    MaterialInfoText.text = ToolData.Instance.Text[11];
                    break;
                }
            case "TButton1 (3)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[12];
                    MaterialInfoText.text = ToolData.Instance.Text[12];
                    break;
                }
            case "TButton1 (4)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[13];
                    MaterialInfoText.text = ToolData.Instance.Text[13];
                    break;
                }
            case "TButton1 (5)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[14];
                    MaterialInfoText.text = ToolData.Instance.Text[14];
                    break;
                }
            case "TButton1 (6)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[15];
                    MaterialInfoText.text = ToolData.Instance.Text[15];
                    break;
                }
            case "TButton1 (7)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[16];
                    MaterialInfoText.text = ToolData.Instance.Text[16];
                    break;
                }
            case "TButton1 (8)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[17];
                    MaterialInfoText.text = ToolData.Instance.Text[17];
                    break;
                }
            case "TButton2 (0)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[18];
                    MaterialInfoText.text = ToolData.Instance.Text[18];
                    break;
                }
            case "TButton2 (1)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[19];
                    MaterialInfoText.text = ToolData.Instance.Text[19];
                    break;
                }
            case "TButton2 (2)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[20];
                    MaterialInfoText.text = ToolData.Instance.Text[20];
                    break;
                }
            case "TButton2 (3)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[21];
                    MaterialInfoText.text = ToolData.Instance.Text[21];
                    break;
                }
            case "TButton2 (4)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[22];
                    MaterialInfoText.text = ToolData.Instance.Text[22];
                    break;
                }
            case "TButton2 (5)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[23];
                    MaterialInfoText.text = ToolData.Instance.Text[23];
                    break;
                }
            case "TButton2 (6)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[24];
                    MaterialInfoText.text = ToolData.Instance.Text[24];
                    break;
                }
            case "TButton2 (7)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[25];
                    MaterialInfoText.text = ToolData.Instance.Text[25];
                    break;
                }
            case "TButton2 (8)":
                {
                    MaterialNameText.text = ToolData.Instance.Name[26];
                    MaterialInfoText.text = ToolData.Instance.Text[26];
                    break;
                }
            case "CButton (0)":
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
