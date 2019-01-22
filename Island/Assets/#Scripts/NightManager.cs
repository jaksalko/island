using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class NightManager : MonoBehaviour {

    public Button nextButton;
    public GameObject[] nightPage;
    public GameObject mapBack;
    public GameObject goNightAdPopup;
    public GameObject toggle;
    public GameObject[] workedGage;//이미 수행한 일의 양
    public Slider[] workSlider;

    int pagenum = 0;
    int adventureClick = 0;//어드벤쳐 모드 캐릭터 -> 맵 -> 팝업 순
    float x = 0;


    private void Start() //////////////**********************Work Mode Method*****************************
    {
        for (int i = 0; i < 3; i++)
        {
            float nowWorked = 3000;//현재 한 일의 양(누적)
            float nowNeed = 3500;//지금 레벨업에 필요한 양
            float beforeNeed = 800;//지금 레벨까지의 필요한 양
            float todayWorked = 200;
            x = 500 * (nowWorked - beforeNeed) / (nowNeed - beforeNeed);


            var gageTransform = workedGage[i].transform as RectTransform;
            gageTransform.sizeDelta = new Vector2(x, gageTransform.sizeDelta.y);
            workedGage[i].transform.localPosition = new Vector3((x / 2 - 155), gageTransform.localPosition.y, 0);
            workSlider[i].value = ((nowWorked + todayWorked - beforeNeed) / (nowNeed - beforeNeed));
        }
        //Debug.Log(workSlider.value);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void NextButtonClicked() {
        pagenum++;
        if (pagenum != 0)
            nightPage[pagenum - 1].SetActive(false);
        nightPage[pagenum].SetActive(true);
        
        if (pagenum == 3)
            nextButton.interactable = false;
        
    }
  
    
    //////////////**********************Adventure Mode Method*****************************
    public void ToggleClicked(Toggle toggle)
    {
        if (toggle.isOn)//토글(어떤 캐릭터 선택했는지)
            Debug.Log(toggle);
        adventureClick = 1;//캐릭터 선택완료 의미
    }
    
    public void AreaClicked()
    {
        if (adventureClick == 1)//캐릭터 선택됐으면 맵선택
        {
            string str = EventSystem.current.currentSelectedGameObject.name;//어떤 지역이 선택됐는지
            Debug.Log(str);
            if (str == "Area1") { mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedA"); adventureClick = 2; }
            else if (str == "Area2") { mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedB"); adventureClick = 2; }
            else if (str == "Area3") { mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedC"); adventureClick = 2; }
        } else { iTween.ShakePosition(toggle ,new Vector3(0.5f,0,0), 0.5f); }//캐릭터 선택이 안된상태에서 맵클릭하면 캐릭터 진동
        if (adventureClick == 2)
        {
            goNightAdPopup.SetActive(true);
        }

    }
    public void AdventureYesClicked() {//탐험 하러 가기
        goNightAdPopup.SetActive(false);
       
        nightPage[pagenum].SetActive(false);
        
        pagenum++;
        nightPage[pagenum].SetActive(true);
        
    }
    public void AdventureNoClicked() {//다시 선택
        goNightAdPopup.SetActive(false);
        mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack");
        adventureClick = 0;
    }
    ////////////////////////////////////////////////////

}
