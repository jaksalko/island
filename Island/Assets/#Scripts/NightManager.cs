using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using TMPro;

public class NightManager : MonoBehaviour {
    public GameObject nightPop;
    public Button nextButton;
    public GameObject[] nightPage;
    public GameObject[] WorkGageOb;
    public GameObject mapBack;
    public GameObject goNightAdPopup;
    public GameObject toggle;
    public GameObject[] workedGage;//이미 수행한 일의 양
    public TextMeshProUGUI DayText;
    public TextMeshProUGUI[] WorkNameText;
    public TextMeshProUGUI[] WorkText;
    public TextMeshProUGUI[] BeforeLvText;
    public TextMeshProUGUI[] AfterLvText;
    public Slider[] workSlider;
    float[] clothgage = { 0,200,500,1000,2000,3000};
    float[] shipgage = { 0,300, 100, 2000, 3000, 5000 };
    float farmgage = 100;
    float[] housegage = { 0,300, 100, 2000, 3000, 5000 };
    float[] enginegage = { 0,300, 100, 2000, 3000, 5000 };
    int gagenum = 0;
    int pagenum = 0;
    int adventureClick = 0;//어드벤쳐 모드 캐릭터 -> 맵 -> 팝업 순
    float x = 0;


    public void Next() //////////////**********************Work Mode Method*****************************
    {

        if(Work.Instance.isWork[1])
        {
            float nowWorked = Work.Instance.SomethingList[0].Perfection;//현재 한 일의 양(누적)
            
            float nowNeed = clothgage[Work.Instance.SomethingList[0].Grade + 1];//지금 레벨업에 필요한 양
            
            float beforeNeed = clothgage[Work.Instance.SomethingList[0].Grade];//지금 레벨까지의 필요한 양
            
            float todayWorked = 100;//Work.Instance.UseMat[1]*10;
            x = 500 * (nowWorked - beforeNeed) / (nowNeed - beforeNeed);
            

            var gageTransform = workedGage[gagenum].transform as RectTransform;
            gageTransform.sizeDelta = new Vector2(x, gageTransform.sizeDelta.y);
            workedGage[gagenum].transform.localPosition = new Vector3((x / 2 - 155), gageTransform.localPosition.y, 0);
            workSlider[gagenum].value = ((nowWorked + todayWorked - beforeNeed) / (nowNeed - beforeNeed));
            
            WorkNameText[gagenum].text = "옷만들기";
            BeforeLvText[gagenum].text = "Lv"+Work.Instance.SomethingList[0].Grade.ToString();
            AfterLvText[gagenum].text = "Lv" + (Work.Instance.SomethingList[0].Grade + 1).ToString();
            gagenum++;
        }

        if (Work.Instance.isWork[2])
        {
            float nowWorked = Work.Instance.SomethingList[1].Perfection;//현재 한 일의 양(누적)
            float nowNeed = shipgage[Work.Instance.SomethingList[1].Grade + 1];//지금 레벨업에 필요한 양
            float beforeNeed = shipgage[Work.Instance.SomethingList[1].Grade];//지금 레벨까지의 필요한 양
            float todayWorked = Work.Instance.UseMat[2] * 10;
            x = 500 * (nowWorked - beforeNeed) / (nowNeed - beforeNeed);


            var gageTransform = workedGage[gagenum].transform as RectTransform;
            gageTransform.sizeDelta = new Vector2(x, gageTransform.sizeDelta.y);
            workedGage[gagenum].transform.localPosition = new Vector3((x / 2 - 155), gageTransform.localPosition.y, 0);
            workSlider[gagenum].value = ((nowWorked + todayWorked - beforeNeed) / (nowNeed - beforeNeed));
            
            WorkNameText[gagenum].text = "배만들기";
            BeforeLvText[gagenum].text = "Lv" + Work.Instance.SomethingList[1].Grade.ToString();
            AfterLvText[gagenum].text = "Lv" + (Work.Instance.SomethingList[1].Grade + 1).ToString();
            gagenum++;
        }

        if (Work.Instance.isWork[5])
        {
            float nowWorked = Work.Instance.SomethingList[2].Perfection;//현재 한 일의 양(누적)
            float nowNeed = 100;//지금 레벨업에 필요한 양
            float beforeNeed = 0;//지금 레벨까지의 필요한 양
            float todayWorked = Work.Instance.UseMat[5] * 10;
            x = 500 * (nowWorked - beforeNeed) / (nowNeed - beforeNeed);


            var gageTransform = workedGage[gagenum].transform as RectTransform;
            gageTransform.sizeDelta = new Vector2(x, gageTransform.sizeDelta.y);
            workedGage[gagenum].transform.localPosition = new Vector3((x / 2 - 155), gageTransform.localPosition.y, 0);
            workSlider[gagenum].value = ((nowWorked + todayWorked - beforeNeed) / (nowNeed - beforeNeed));
            
            WorkNameText[gagenum].text = "농사짓기";
            BeforeLvText[gagenum].text = "씨앗에서";
            AfterLvText[gagenum].text = "이삭까지";
            gagenum++;
        }

        if (Work.Instance.isWork[6])
        {
            float nowWorked = Work.Instance.SomethingList[3].Perfection;//현재 한 일의 양(누적)
            float nowNeed = housegage[Work.Instance.SomethingList[3].Grade + 1];//지금 레벨업에 필요한 양
            float beforeNeed = housegage[Work.Instance.SomethingList[3].Grade];//지금 레벨까지의 필요한 양
            float todayWorked = Work.Instance.UseMat[6] * 10;
            x = 500 * (nowWorked - beforeNeed) / (nowNeed - beforeNeed);


            var gageTransform = workedGage[gagenum].transform as RectTransform;
            gageTransform.sizeDelta = new Vector2(x, gageTransform.sizeDelta.y);
            workedGage[gagenum].transform.localPosition = new Vector3((x / 2 - 155), gageTransform.localPosition.y, 0);
            workSlider[gagenum].value = ((nowWorked + todayWorked - beforeNeed) / (nowNeed - beforeNeed));
            
            WorkNameText[gagenum].text = "건축하기";
            BeforeLvText[gagenum].text = "Lv" + Work.Instance.SomethingList[3].Grade.ToString();
            AfterLvText[gagenum].text = "Lv" + (Work.Instance.SomethingList[3].Grade + 1).ToString();
            gagenum++;
        }

        if (Work.Instance.isWork[7])
        {
            float nowWorked = Work.Instance.SomethingList[4].Perfection;//현재 한 일의 양(누적)
            float nowNeed = enginegage[Work.Instance.SomethingList[4].Grade + 1];//지금 레벨업에 필요한 양
            float beforeNeed = enginegage[Work.Instance.SomethingList[4].Grade];//지금 레벨까지의 필요한 양
            float todayWorked = Work.Instance.UseMat[7] * 10;
            x = 500 * (nowWorked - beforeNeed) / (nowNeed - beforeNeed);


            var gageTransform = workedGage[gagenum].transform as RectTransform;
            gageTransform.sizeDelta = new Vector2(x, gageTransform.sizeDelta.y);
            workedGage[gagenum].transform.localPosition = new Vector3((x / 2 - 155), gageTransform.localPosition.y, 0);
            workSlider[gagenum].value = ((nowWorked + todayWorked - beforeNeed) / (nowNeed - beforeNeed));
           
            WorkNameText[gagenum].text = "통신장치 제작하기";
            BeforeLvText[gagenum].text = "Lv" + Work.Instance.SomethingList[4].Grade.ToString();
            AfterLvText[gagenum].text = "Lv" + (Work.Instance.SomethingList[4].Grade + 1).ToString();
            gagenum++;
        }

        for (int i = gagenum; i < 3; i++)
        {
            WorkGageOb[i].SetActive(false);
        }
        
        //Debug.Log(workSlider.value);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void NextButtonClicked() {
        Debug.Log(pagenum);
        // pagenum++;
        if (pagenum == 3)//마지막페이지에서 '다음' 버튼을 눌렀을 때
        {
            nightPop.SetActive(false);
            nightPage[3].SetActive(false);
            nightPage[0].SetActive(true);
            pagenum = 0;
            gagenum = 0;
            for (int i = 0; i < 3; i++)
            {
                WorkGageOb[i].SetActive(true);
            }
            Work.Instance.NewDay();

            PlayerPrefs.SetInt("Day", PlayerPrefs.GetInt("Day") + 1);
            DayText.text = "Day " + PlayerPrefs.GetInt("Day").ToString();
        }
        else
        {
            pagenum++;
            nightPage[pagenum - 1].SetActive(false);
            nightPage[pagenum].SetActive(true);
        }
        
        
        
        
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
