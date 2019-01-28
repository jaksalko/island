using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
public class TradePopupManager : MonoBehaviour {
    public GameObject tradePopup;
    public Button exitButton;
    public GameObject rightNum;
    public GameObject leftNum;
    public GameObject userItem;
    public GameObject traderItem;
    public GameObject background;
    public GameObject userBack;
    public GameObject traderBack;
    public Button[] number;
    public TextMeshProUGUI outputUser;
    public TextMeshProUGUI outputTrader;
    //private Stack userNum;
    private List<int> userNum = new List<int>();
    private void Start() {
        
    }
    public void UserItemClicked()
    {
        background.SetActive(false);
        traderItem.SetActive(false);
        userBack.SetActive(true);
        rightNum.SetActive(true);

    }
    public void TraderItemClicked()
    {
        background.SetActive(false);
        userItem.SetActive(false);
        traderBack.SetActive(true);
        leftNum.SetActive(true);

    }
    public void ExitButtonClick()
    {
        tradePopup.SetActive(false);
        background.SetActive(true);
        userBack.SetActive(false);
        traderBack.SetActive(false);
        leftNum.SetActive(false);
        rightNum.SetActive(false);
    }
    public void NumberClicked() {
        string str = EventSystem.current.currentSelectedGameObject.name;
        str = str.Replace("NumberButton", "");
        int pushCount = userNum.Count;

        switch (str) {
            case "0":
                userNum.Add(0);
                //outputUser.text += "0";
                break;
            case "1":
                userNum.Add(1);
                //outputUser.text += "1";
                break;
            case "2":
                userNum.Add(2);
                //outputUser.text += "2";
                break;
            case "3":
                userNum.Add(3);
                //outputUser.text += "3";
                break;
            case "4":
                userNum.Add(4);
                //outputUser.text += "4";
                break;
            case "5":
                userNum.Add(5);
                //outputUser.text += "5";
                break;
            case "6":
                userNum.Add(6);
                //outputUser.text += "6";
                break; 
            case "7":
                userNum.Add(7);
                //outputUser.text += "7";
                break; 
            case "8":
                userNum.Add(8);
                //outputUser.text += "8";
                break; 
            case "9":
                userNum.Add(9);
                //outputUser.text += "9";
                break; 
            case "Back":
               
                //outputUser.text =  userNum.Peek().ToString();
                break; 
        }
        
        foreach (int i in userNum)
        {
            outputUser.text = "";
            outputUser.text += userNum[i].ToString();
        }
           
            
        
    }
}
