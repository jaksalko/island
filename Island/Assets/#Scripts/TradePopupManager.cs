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
    public GameObject tradeOkPopup;

    public TextMeshProUGUI outputUser;
    public TextMeshProUGUI outputTrader;

    public GameObject[] userDrag;
    public GameObject[] traderDrag;
    private string user;
    private string trader;
    private List<int> userNum = new List<int>();
    private void Start() {
        
    }
    public void UserItemClicked()
    {
        user = EventSystem.current.currentSelectedGameObject.name;
        user = user.Replace("Button", "");
        Debug.Log("useritemselect : " + user);
        background.SetActive(false);
        traderItem.SetActive(false);
        userBack.SetActive(true);
        rightNum.SetActive(true);

    }
    public void TraderItemClicked()
    {
        trader = EventSystem.current.currentSelectedGameObject.name;
        trader = trader.Replace("TButton", "");
        background.SetActive(false);
        userItem.SetActive(false);
        traderBack.SetActive(true);
        leftNum.SetActive(true);

    }
    public void ExitButtonClick()
    {
        
        background.SetActive(true);
        userItem.SetActive(true);
        traderItem.SetActive(true);
        userBack.SetActive(false);
        traderBack.SetActive(false);
        leftNum.SetActive(false);
        rightNum.SetActive(false);
        tradePopup.SetActive(false);
    }
    public void NumberClicked() {
        string str = EventSystem.current.currentSelectedGameObject.name;
        str = str.Replace("NumberButton", "");
        if (userBack.activeSelf == true)
        { outputUser.text = ""; }
        else { outputTrader.text = ""; }
        
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
                if(userNum.Count !=0)
                    userNum.RemoveAt(userNum.Count-1);
                //outputUser.text =  userNum.Peek().ToString();
                break; 
        }

        for (int i = 0; i < userNum.Count; i++)
        {
            if (userBack.activeSelf == true)
            { outputUser.text += userNum[i].ToString(); }
            else { outputTrader.text += userNum[i].ToString(); }
            
           
        }
           
            
        
    }
    public void OkButtonClicked() {//유저의 아이템 거래화면
        if (userBack.activeSelf == true)
        {//if 수량이 충분하다면

            background.SetActive(true);
            userBack.SetActive(false);
            rightNum.SetActive(false);
            traderItem.SetActive(true);
            for (int i = 0; i < 7; i++)
            {
                if (userDrag[i].activeSelf == false)
                {
                    userDrag[i].SetActive(true);
                    switch (user) {
                        case "1":

                            userDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/bait");
                            break;
                        case "2":
                            userDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/brick");
                            break;
                        case "3":
                            userDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/cloth");
                            break;
                        case "4":
                            userDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/elecline");
                            break;
                        case "5":
                            userDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/medicineMaterial");
                            break;
                        case "6":
                            userDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/seed");
                            break;
                        case "7":
                            userDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/steal");
                            break;
                    }
                    break;
                }
            }
            outputUser.text = "";
            userNum.Clear();
            //부족하다면?
        }
        else {//교환상점의 아이템거래화면
            //if 수량이 충분하다면
            background.SetActive(true);
            traderBack.SetActive(false);
            leftNum.SetActive(false);
            userItem.SetActive(true);
            for (int i = 0; i < 7; i++)
            {
                if (traderDrag[i].activeSelf == false)
                {
                    traderDrag[i].SetActive(true);
                    switch (trader)
                    {
                        case "1":
                            traderDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/bait");
                            break;
                        case "2":
                            traderDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/brick");
                            break;
                        case "3":
                            traderDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/cloth");
                            break;
                        case "4":
                            traderDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/elecline");
                            break;
                        case "5":
                            traderDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/medicineMaterial");
                            break;
                        case "6":
                            traderDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/seed");
                            break;
                        case "7":
                            traderDrag[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/steal");
                            break;
                    }
                    break;
                }
            }
            outputTrader.text = "";
            userNum.Clear();
            //부족하다면?
        }
    }

    public void TradeOkButton() {
        tradeOkPopup.SetActive(true);
    }
    public void TradeOkClicked() {//트레이드창복구시킴. 교환결과보여주기(선택)
        tradeOkPopup.SetActive(false);
        background.SetActive(true);
        userItem.SetActive(true);
        traderItem.SetActive(true);
        userBack.SetActive(false);
        traderBack.SetActive(false);
        leftNum.SetActive(false);
        rightNum.SetActive(false);
       
       
        tradePopup.SetActive(false);
    }
    public void TradeNoClicked() {
        tradeOkPopup.SetActive(false);//팝업창만 닫음
    }
}
