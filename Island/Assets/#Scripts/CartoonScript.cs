using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartoonScript : SingleTon<CartoonScript>
{
   

    public GameObject cartoon;//만화이미지
    public Button nextTextButton;//텍스트넘기는 버튼.
    public TextMeshProUGUI cartoonText;//텍스트
    public TextMeshProUGUI leftText;//왼쪽버튼텍스트
    public TextMeshProUGUI rightText;//오른쪽버튼텍스트
    public TextMeshProUGUI popupText;//팝업텍스트
    public GameObject selectPopup;//선택창
    public Button leftButton;//왼쪽선택버튼
    public Button rightButton;//오른쪽선택버튼
    string text;
    
    // Use this for initialization

    void Awake()
    {
        
    }

    void Start ()
    {

        CartoonScript.Instance.cartoon = this.cartoon;
        CartoonScript.Instance.nextTextButton = this.nextTextButton;
        CartoonScript.Instance.cartoonText = this.cartoonText;
        CartoonScript.Instance.leftText = this.leftText;
        CartoonScript.Instance.rightText = this.rightText;
        CartoonScript.Instance.popupText = this.popupText;
        CartoonScript.Instance.selectPopup = this.selectPopup;
        CartoonScript.Instance.leftButton = this.leftButton;
        CartoonScript.Instance.rightButton = this.rightButton;
        //CartoonScript.Instance.cartoonText.text = text;
        this.cartoonText.text = CartoonScript.Instance.text;
        
    }

    public void Event(string str)
    {


        text = str;
        Debug.Log(str);
        Debug.Log(text);
        Debug.Log(this);


        FoodData.Instance.FoodList[0].Count = 100;
        EndingEvent.Instance.Save();
        EndingEvent.Instance.Load();

    }
	
	// Update is called once per frame
	void Update () {

       
    }

    public void next()
    {
        AutoFade.LoadLevel("MainScene 3", 1, 1, Color.black);
    }

    public void NextTextButtonClicked() {
        //여기에 버튼 클릭했을 떄 텍스트 바뀌게 & 마지막 텍스트 다음에는 selectPopup.setActive(true); 선택없으면 다시 원래 씬으로
    }
    public void LeftClicked() { }
    public void RightClicked() { }



}
