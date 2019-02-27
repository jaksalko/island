using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using TMPro;

public class Something
{
    public string Name;
    public int Perfection;
    public int Grade;

    public Something(string name, int perfection, int grade)
    {
        Name = name;
        Perfection = perfection;
        Grade = grade;
    }
}

public class Work : SingleTon<Work>
{
    public TextMeshProUGUI workYesClickTxt;// WorkSelect 에서 yes 클릭했을 때 나오는 팝업창 텍스트
    public TextMeshProUGUI DayText;
    public static bool[] isWork =new bool[11];
    public static bool[] PersonWork =new bool[3];
    public int temp;
    public GameObject workPopup;//일 선택창 팝업
    public GameObject workSelectPopup;//일 선택시 팝업 백그라운드
    public Button Yes;//일수행 yes
    public Button No;//no
    public Button[] AdArea;//지역 ABC버튼
    public GameObject mapBack;//지도 그림
    public GameObject goAreaPopup;//탐험지역선택시 나오는 팝업
    public GameObject[] popupMode;//0.Normal 1.Medicine 2.Fishing 3.Hunting 4.Cook 5.Farming 6.Adventure
    
   
   
    public TextMeshProUGUI[] CookMatCounText;
    public TextMeshProUGUI[] CookCounText;
    public TextMeshProUGUI FishMatCountText;
    public TextMeshProUGUI FishCountText;
    public TextMeshProUGUI FarmMatCountText;
    public TextMeshProUGUI FarmCountText;
    public TextMeshProUGUI MediMatCountText;
    public TextMeshProUGUI MediCountText;
    public GameObject[] Char;
    public int NowWorkNum;
    

    public List<Something> SomethingList = new List<Something>();

    string path;
    int now;
    public Slider expSlider;
    public GameObject expGage;
    // Use this for initialization


    public void Awake()
    {
       // DontDestroyOnLoad(this);
        
    }

    public void Start()
    {
        if (!PlayerPrefs.HasKey("Start"))//저장되지 않았을 때
        {
            MyCharacterData.Instance.Clear();
            Work.Instance.Clear();
            ManufactureData.Instance.clear();
            EndingEvent.Instance.Clear();
            FoodData.Instance.Clear();
            CharacterData.Instance.Load();
            PlayerPrefs.SetInt("Start", 1);
            PlayerPrefs.DeleteKey("Now");
            Debug.Log("클리어");
        }
        // PlayerPrefs.DeleteKey("Start");


        //if (!PlayerPrefs.HasKey("Now"))
        //{

        //}
        //else
        //{
        //    Debug.Log(PlayerPrefs.GetInt("Now"));
        //    Char[PlayerPrefs.GetInt("Now")].SetActive(false);
        //    PlayerPrefs.DeleteKey("Now");
        //}

        if (PlayerPrefs.HasKey("ClickCount"))
        {
            switch (PlayerPrefs.GetInt("NowWorkNum"))
            {
                case 2:
                    {
                        //배 진행률++

                        break;
                    }
                case 4:
                    {
                        //집 진행률++

                        break;
                    }
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(PersonWork[i]);
            if (PersonWork[i])
                Char[i].SetActive(false);
        }


        StartCoroutine(SomethingLoad());
        
        DayText.text = "Day " + PlayerPrefs.GetInt("Day");

    }

    public void Save()
    {
        StartCoroutine(SomethingSave());
    }
    public void Load()
    {
        StartCoroutine(SomethingLoad());
    }
    public void Clear()
    {
        StartCoroutine(SomethingClear());
    }

    public int ToolAbility(int max)
    {
        switch (max)
        {
            
            case 1:
                {
                    return 5;
                  
                }
            case 2:
                {
                    return 10;
                }
            case 3:
                {
                    return 20;
                }
            default:
                {
                    return 0;
                }
        }
    }


    public void NewDay()
    {
        Debug.Log("뉴데이");
        EndingEvent.Instance.Save();
        EndingEvent.Instance.Load();

        DayText.text = "Day " + PlayerPrefs.GetInt("Day");

        ManufactureData.Instance.FreshManu();

        EndingEvent.Instance.WhaleEvent();
        EndingEvent.Instance.BottleEvent();
        EndingEvent.Instance.EngineEvent();
        EndingEvent.Instance.ShipEvent();
        EndingEvent.Instance.MerEvent();
        EndingEvent.Instance.HeroEvent();
        EndingEvent.Instance.DreamEvent();
        EndingEvent.Instance.RainBowEvent();

        //if(빙판맵)
        //EndingEvent.Instance.IceEvent();
        //if(더운맵)
        //EndingEvent.Instance.LeafEvent();
        for (int i = 0; i < 3; i++)
        {
            Char[i].SetActive(true);
        }
        int now = MyCharacterData.Instance.NowCharacterName;
        for (int i=0;i<isWork.Length;i++)
        {
            switch (i)
            {
                case 1:
                    {
                        if (isWork[i] == true)
                        {
                            //MaterialData.Instance.MaterialList[0].Count -= UseMat[NowWorkNum];

                           
                            if (UnityEngine.Random.Range(0, 100) < 3)
                            {
                                SomethingList[0].Grade = 6;

                            }//날개옷 생성

                            else
                            {

                                if (SomethingList[0].Perfection > 199 && SomethingList[0].Perfection < 500)
                                {
                                    SomethingList[0].Grade = 1;
                                    //1단계 옷 생성
                                }
                                else if (SomethingList[0].Perfection > 499 && SomethingList[0].Perfection < 1000)
                                {
                                    SomethingList[0].Grade = 2;
                                }
                                else if (SomethingList[0].Perfection > 999 && SomethingList[0].Perfection < 2000)
                                {
                                    SomethingList[0].Grade = 3;
                                }
                                else if (SomethingList[0].Perfection > 1999 && SomethingList[0].Perfection < 3000)
                                {
                                    SomethingList[0].Grade = 4;
                                }
                                else if (SomethingList[0].Perfection > 2999)
                                {
                                    SomethingList[0].Grade = 5;
                                }

                            }
                            ManufactureData.Instance.ManuList[0].Grade = SomethingList[0].Grade;
                        }
                        break;
                    }
                case 2:
                    {
                        if (isWork[i] == true)
                        {
                            //MaterialData.Instance.MaterialList[1].Count -= UseMat[NowWorkNum];

                            
                            if (SomethingList[1].Perfection > 299 && SomethingList[1].Perfection < 1000)
                            {
                                SomethingList[1].Grade = 1;
                                //1단계 배 생성
                            }
                            else if (SomethingList[1].Perfection > 999 && SomethingList[1].Perfection < 2000)
                            {
                                SomethingList[1].Grade = 2;
                            }
                            else if (SomethingList[1].Perfection > 1999 && SomethingList[1].Perfection < 3000)
                            {
                                SomethingList[1].Grade = 3;
                            }
                            else if (SomethingList[1].Perfection > 2999 && SomethingList[1].Perfection < 5000)
                            {
                                SomethingList[1].Grade = 4;
                            }
                            else if (SomethingList[1].Perfection > 4999)
                            {
                                SomethingList[1].Grade = 5;
                            }
                            ManufactureData.Instance.ManuList[1].Grade = SomethingList[1].Grade;
                        }
                        break;
                    }
                case 3:
                    {
                        if (isWork[i] == true)
                        {
                           
                            
                            
                            
                        }
                        break;
                    }
                case 4:
                    {
                        if (isWork[i] == true)
                        {
                            //MaterialData.Instance.MaterialList[2].Count -= UseMat[NowWorkNum];

                            
                        }
                        break;
                    }
                case 5:
                    {
                        if (isWork[i] == true)
                        {

                           
                            
                        }
                        break;
                    }
                case 6:
                    {
                        if (isWork[i] == true)
                        {
                            //MaterialData.Instance.MaterialList[4].Count -= UseMat[NowWorkNum];

                        }
                        break;
                    }
                case 7:
                    {
                        if (isWork[i] == true)
                        {
                            //MaterialData.Instance.MaterialList[5].Count -= UseMat[NowWorkNum];

                            
                        }
                        break;
                    }
                case 8:
                    {
                        if (isWork[i] == true)
                        {
                           
                        }
                        break;
                    }
                case 9:
                    {
                        if (isWork[i] == true)
                        {
                           
                        }
                        break;
                    }
                case 10:
                    {
                        if (isWork[i] == true)
                        {
                            
                        }
                        break;
                    }
            }
        }
        for (int i = 0; i < isWork.Length; i++)
        {
            isWork[i] = false;
            
        }
        
        SomethingSave();
        NowWorkNum = 0;
    }

    public void YesButton()//제작버튼
    {
        
        //workSelectPopup.SetActive(false);
        switch (NowWorkNum)
        {
            case 1://옷
                {
                   



                    if (isWork[NowWorkNum])//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {

                        //확률따져서 날개옷 생성


                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "옷(00+00/100)을 만드시겠습니까?";
                        

                    }
                    
                   
                    //popupMode[0].SetActive(false);
                    break;

                }//case 1

            case 2://배
                {
                    
                    

                    if (isWork[NowWorkNum])
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "배(00+00/100)을 만드시겠습니까?";

                        
                    }
                   
                    
                    break;
                }//case 2

            case 3://요리
                {
                    /*************************************************************************************************************
                    //요리에서 각각의 재료를 ++하는 버튼을 눌렀을 때 어느 변수에다가 저장해둬야만 요리가 몇개만들어지는지 확인 가능
                    *************************************************************************************************************/

                    
                   
                    int fdtemp = FoodData.Instance.FoodList[0].Count + FoodData.Instance.FoodList[4].Count + FoodData.Instance.FoodList[8].Count;
                    if (isWork[NowWorkNum])// 또한 물고기, 고기, 쌀이 없을 때 안됨
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {


                        //도구 단계에 따라 + 능력치 해줘야함


                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "밥 0 개  고기요리 0 개 생선요리 0 개를 만드시겠습니까?";

                    }
                  
                    break;
                }

            case 4://낚시
                {
                    //확률 따져서 인어맨 엔딩 시작 -> EndingEvent Script 참고
                    

                    
                    if (isWork[NowWorkNum])
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {


                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "물고기 0 마리를 잡으러 가시겠습니까?";

                        

                    }
                  
                    break;
                }//case 4

            case 5://농사
                {

                    


                    
                    if (isWork[NowWorkNum])//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = " 벼를 0개 수확하러 가시겠습니까?";

                        
                        //else 일을 안한다는 버튼
                    }
                  
                    break;
                }//case 5

            case 6://건축
                {
                    

                   
                    if (isWork[NowWorkNum])//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "집(00+00/100)을 만드시겠습니까?";




                        

                        //else 일을 안한다는 버튼
                    }
                   
                    break;
                }//case 6

            case 7://통신
                {
                    //확률따져서 타임머신 생성

                   
                    if (isWork[NowWorkNum])//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "통신기계(00+00/100)을 만드시겠습니까?";
                        
                        


                        
                    }
                 
                    break;
                }//case 7

            case 8://제약
                {
                   
                    if (isWork[NowWorkNum])// 또한 물고기, 고기, 쌀이 없을 때 안됨
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {
                        
                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "약을 0개  제조하시겠습니까?";
                    }
                   
                    break;
                }//case 8

            case 9://수렵
                {
                    
                    break;
                }//case 9

            case 10://탐험
                {
                    
                    break;
                }//case 10
        }

        //UseMat = 0;
        
        temp = 0;
    }
    public void NoClicked()                                                             //제작취소
    {
        
        CookMatCounText[0].text = CookMatCounText[1].text = CookMatCounText[2].text = "0";
        CookCounText[0].text = CookCounText[1].text = CookCounText[2].text = "0";

        FishMatCountText.text= "0";
        FishCountText.text = "0";
        FarmMatCountText.text = "0";
        FarmCountText.text = "0";
        MediMatCountText.text = "0";
        MediCountText.text = "0";
        
        workSelectPopup.SetActive(false);
        for (int i = 0; i < 7; i++)
        {
            if (popupMode[i].activeSelf == true)
            {
                if (i == 6)
                {
                    goAreaPopup.SetActive(false);
                }
                popupMode[i].SetActive(false);
                break;
            }
        }
    }
    public void WorkYes() {                                                          //여기서 이제 갯수랑 게이지같은게 변화시켜야함

        int now = MyCharacterData.Instance.NowCharacterName; // 선택한 캐릭터 번호
        Debug.Log(now +"캐릭터이며"+NowWorkNum+"번째 일이다");
        switch (NowWorkNum)
        {
            case 1:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;

                        Debug.Log(MyCharacterData.Instance.CharacterName.IndexOf(now));
                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 2:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;
                        Save();
                        AutoFade.LoadLevel("ClickerGame", 1, 1, Color.black);
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 3:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;

                        AutoFade.LoadLevel("CookGame", 1, 1, Color.black);
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 4:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;

                        EndingEvent.instance.MerP = 0;
                    EndingEvent.Instance.MerTF = true;
                    EndingEvent.Instance.fishing = true;
                    EndingEvent.Instance.MerEvent();

                    EndingEvent.Instance.fishing = false;


                        
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 5:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;

                    Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 6:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;


                        Save();
                        AutoFade.LoadLevel("ClickerGame", 1, 1, Color.black);
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 7:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;

                    Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 8:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;

                    Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 9:
                { 
                if (isWork[NowWorkNum] == false)
                {
                        isWork[NowWorkNum] = true;
                        

                    if (isWork[NowWorkNum])
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        EndingEvent.Instance.hunting = true;
                        EndingEvent.Instance.EagleEvent();



                        //Text로 능력치에 따라 얻어 올 수 있는 고기의 수 표시
                        //Text로 능력치에 따라 수렵에 성공할 확률 표시?


                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    }
                    popupMode[3].SetActive(false);
                        // MaterialData.Instance.MaterialList[NowWorkNum - 1].Count -= UseMat[NowWorkNum];
                    }
                    else
                    {
                        Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                    }
                    break;
                }
            case 10:
                {
                    if (isWork[NowWorkNum] == false)
                    {
                        isWork[NowWorkNum] = true;

                    Debug.Log("탐험버튼 누름");

                    EndingEvent.Instance.adven = true;

                    EndingEvent.Instance.BottleEvent();



                    Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                        // MaterialData.Instance.MaterialList[NowWorkNum - 1].Count -= UseMat[NowWorkNum];
                    }
                    else
                    {
                            Debug.Log("이미 다른 캐릭터가 진행한 일입니다.");
                        }
                        break;
                }
            case 11:
                {
                   // MaterialData.Instance.MaterialList[NowWorkNum - 1].Count -= UseMat[NowWorkNum];
                    break;
                }
        }
        PersonWork[MyCharacterData.Instance.CharacterName.IndexOf(now)] = true;
        PlayerPrefs.SetInt("Now", MyCharacterData.Instance.CharacterName.IndexOf(now));
        PlayerPrefs.SetInt("NowWorkNum", NowWorkNum);

        //SomethingList[0].Perfection += UseMat[NowWorkNum] * 10;


        for (int i = 0; i < 7; i++)
        {
            if (popupMode[i].activeSelf == true)
            {
                popupMode[i].SetActive(false);
                break;
            }
        }
        goAreaPopup.SetActive(false);
        workSelectPopup.SetActive(false);
        workPopup.SetActive(false);

        
        

    }
    public void WorkNo() {                                                      //마지막 팝업창에서 취소버튼 이전창으로만 돌아가면 되는데 탐험을선택했을때는 지도를 꺼버림
        goAreaPopup.SetActive(false);
        if (popupMode[6].activeSelf == true)
            popupMode[6].SetActive(false);
    }//마지막 일할지 안할지 선택할 떄 No 버튼

    

    public void work()
    {
        
        string str = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(str);
        switch (str)//일을 선택했을 시 도구 / 재료가 없으면 팝업창이 나와야함
        {
            //재료가 필요한 일 
            //1->0
            //2->1
            //4->2
            //5->3
            //6->4
            //7->5
            //8->6
            //-1 / +0
            
            case "WorkButton1"://옷만들기
                {
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    NowWorkNum = 1;
                   
                    break;
                }

            case "WorkButton2"://배만들기
                {
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    NowWorkNum = 2;

                    break;
                }
            case "WorkButton3"://요리 -> 새 팝업창에서 요리를 클릭가능하게 하고 없으면 안된다는 팝업
                {
                    workSelectPopup.SetActive(true);
                    popupMode[4].SetActive(true);
                    NowWorkNum = 3;
                    
                    break;
                }
            case "WorkButton4"://낚시
                {
                    workSelectPopup.SetActive(true);
                    popupMode[2].SetActive(true);
                    NowWorkNum = 4;
                    
                    break;
                }
            case "WorkButton5"://농사
                {
                    workSelectPopup.SetActive(true);
                    popupMode[5].SetActive(true);
                    NowWorkNum = 5;

                    

                    break;
                }
            case "WorkButton6"://집짓기
                {
                   
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    NowWorkNum = 6;

                   

                    break;
                }
            case "WorkButton7"://통신장치만
                {
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    
                    NowWorkNum = 7;

                   
                    break;
                }
            case "WorkButton8"://제약
                {
                    workSelectPopup.SetActive(true);
                    popupMode[1].SetActive(true);
                    NowWorkNum = 8;
                    
                    break;
                }
            case "WorkButton9"://수렵
                {
                    workSelectPopup.SetActive(true);
                    popupMode[3].SetActive(true);
                    NowWorkNum = 9;
                    
                    break;
                }
            case "WorkButton10"://탐험
                {
                    popupMode[6].SetActive(true);
                    
                    NowWorkNum = 10;
                    
                    break;
                }
            case "WorkButton11"://쉬기
                {

                    break;
                }
        }

    }


  
    public void AreaClicked() {
        string str = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(str);
        if (str == "Area1") {   mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedA");}
        else if (str == "Area2") { mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedB"); }
        else if (str == "Area3") { mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedC"); }
        str = str.Replace("Area", "");
        workYesClickTxt.text = str + "지역을 탐험하시겠습니까?";
        goAreaPopup.SetActive(true);
        
    }

    IEnumerator SomethingClear()
    {
        List<Something> TempList = new List<Something>();
        Something st;
        for (int i = 0; i < 5; i++)
        {
            if (i == 0)
                st = new Something("cloth", 0, 0);
            else if(i==1)
                st = new Something("ship", 0, 0);
            else if(i==2)
                st = new Something("farm", 0, 0);
            else if(i==3)
                st = new Something("gouse", 0, 0);
            else
                st = new Something("engine", 0, 0);



            TempList.Add(st);

        }

        JsonData SomethingJson = JsonMapper.ToJson(TempList);

        //File.WriteAllText(Application.persistentDataPath + "/Something.json", SomethingJson.ToString());
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/Something.json", SomethingJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/Something.json", SomethingJson.ToString());


        yield return null;
    }

    IEnumerator SomethingSave()
    {
        List<Something> TempList = new List<Something>();
        Something st;
        for (int i = 0; i < SomethingList.Count; i++)
        {
            //recovery = InventoryManager.Instance.FData.FoodList[i].Recovery;
            //name = InventoryManager.Instance.FData.FoodList[i].Name;

            //count = InventoryManager.Instance.FData.FoodList[i].Count;

            st = new Something(SomethingList[i].Name, SomethingList[i].Perfection, SomethingList[i].Grade);

            TempList.Add(st);

        }

        
        JsonData SomethingJson = JsonMapper.ToJson(TempList);
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/Something.json", SomethingJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/Something.json", SomethingJson.ToString());



        yield return null;
    }

    IEnumerator SomethingLoad()
    {

        //string SomethingString = File.ReadAllText(Application.persistentDataPath + "/Something.json");
        string SomethingString;

        if (EndingEvent.Instance.path == Application.persistentDataPath)
            SomethingString = File.ReadAllText(Application.persistentDataPath + "/Something.json");
        else
            SomethingString = File.ReadAllText(EndingEvent.Instance.path + "/Resources/Something.json");


        Debug.Log(SomethingString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(SomethingString);
        //태그로 정렬 가능?

        ParsingSomething(itemData);

        yield return null;

    }

    private void ParsingSomething(JsonData Data)
    {

        Something st;
        for (int i = 0; i < Data.Count; i++)
        {


            

            st = new Something(Data[i]["Name"].ToString(), int.Parse(Data[i]["Perfection"].ToString()), int.Parse(Data[i]["Grade"].ToString()));



            SomethingList.Add(st);




        }

    }

}
