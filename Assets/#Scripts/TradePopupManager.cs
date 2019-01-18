using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    }
}
