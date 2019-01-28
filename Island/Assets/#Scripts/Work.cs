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

    public bool[] isWork = { false,};
    public int temp;
    public GameObject workPopup;//일 선택창 팝업
    public GameObject workSelectPopup;//일 선택시 팝업 백그라운드
    public Button Yes;//일수행 yes
    public Button No;//no
    public Button[] AdArea;//지역 ABC버튼
    public GameObject mapBack;//지도 그림
    public GameObject goAreaPopup;//탐험지역선택시 나오는 팝업
    public GameObject[] popupMode;//0.Normal 1.Medicine 2.Fishing 3.Hunting 4.Cook 5.Farming 6.Adventure
    public Button[] MatQuanUp;//재료 수량 업
    public Button[] MatQuanDown;//다운
    public GameObject normalModeMatImg;//노말모드 재료이미지
    public TextMeshProUGUI MatCountText;
    public GameObject BeforeImg;
    public GameObject AfterImg;
    public TextMeshProUGUI[] CookMatCounText;
    public TextMeshProUGUI[] CookCounText;
    public TextMeshProUGUI FishMatCountText;
    public TextMeshProUGUI FishCountText;
    public TextMeshProUGUI FarmMatCountText;
    public TextMeshProUGUI FarmCountText;
    public TextMeshProUGUI MediMatCountText;
    public TextMeshProUGUI MediCountText;
    public GameObject[] Char;
    public int Toolmax = 0;
    public int NowWorkNum;
    public int[] UseMat= { 0, };

    public int[] UseFood= new int[3];

    public List<Something> SomethingList = new List<Something>();


    public Slider expSlider;
    public GameObject expGage;
    // Use this for initialization


    public void Start()
    {
        PlayerPrefs.SetInt("Day", 1);

        StartCoroutine(SomethingLoad());

        isWork[1] = true;
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
        int now = MyCharacterData.Instance.NowCharacterName;
        for (int i=0;i<isWork.Length;i++)
        {
            switch (i)
            {
                case 1:
                    {
                        if (isWork[i] == true)
                        {
                            MaterialData.Instance.MaterialList[0].Count -= UseMat[NowWorkNum];

                            SomethingList[0].Perfection += UseMat[NowWorkNum] * 10;

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
                        }
                        break;
                    }
                case 2:
                    {
                        if (isWork[i] == true)
                        {
                            MaterialData.Instance.MaterialList[1].Count -= UseMat[NowWorkNum];

                            SomethingList[1].Perfection += UseMat[NowWorkNum] * 10;

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
                        }
                        break;
                    }
                case 3:
                    {
                        if (isWork[i] == true)
                        {
                            FoodData.Instance.FoodList[0].Count -= UseFood[0];
                            FoodData.Instance.FoodList[4].Count -= UseFood[1];
                            FoodData.Instance.FoodList[8].Count -= UseFood[2];
                            switch (Toolmax)
                            {
                                case 1:
                                    {
                                        for (int j = 0; j < 3; j++)
                                        {
                                            FoodData.Instance.FoodList[j * 4 + 1].Count += UseFood[j];
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        for (int j = 0; j < 3; j++)
                                        {
                                            FoodData.Instance.FoodList[j * 4 + 2].Count += UseFood[j];
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        for (int j = 0; j < 3; j++)
                                        {
                                            FoodData.Instance.FoodList[j * 4 + 3].Count += UseFood[j];
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        if (isWork[i] == true)
                        {
                            MaterialData.Instance.MaterialList[2].Count -= UseMat[NowWorkNum];

                            for (int j = 0; j < UseMat[NowWorkNum]; j++)
                            {
                                FoodData.Instance.FoodList[8].Count += (CharacterData.Instance.AllCharacter[now].Work4 + ToolAbility(Toolmax)) / 10;
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        if (isWork[i] == true)
                        {
                            MaterialData.Instance.MaterialList[3].Count -= UseMat[NowWorkNum];

                            for (int j = 0; j < UseMat[NowWorkNum]; j++)
                            {
                                FoodData.Instance.FoodList[0].Count += (CharacterData.Instance.AllCharacter[now].Work5 + ToolAbility(Toolmax)) / 10;
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        if (isWork[i] == true)
                        {
                            MaterialData.Instance.MaterialList[4].Count -= UseMat[NowWorkNum];

                            SomethingList[3].Perfection += UseMat[NowWorkNum] * 10;





                            if (SomethingList[3].Perfection > 299 && SomethingList[3].Perfection < 1000)
                            {
                                SomethingList[3].Grade = 1;
                                //1단계 옷 생성
                            }
                            else if (SomethingList[3].Perfection > 999 && SomethingList[3].Perfection < 2000)
                            {
                                SomethingList[3].Grade = 2;
                            }
                            else if (SomethingList[3].Perfection > 1999 && SomethingList[3].Perfection < 3000)
                            {
                                SomethingList[3].Grade = 3;
                            }
                            else if (SomethingList[3].Perfection > 2999 && SomethingList[3].Perfection < 5000)
                            {
                                SomethingList[3].Grade = 4;
                            }
                            else if (SomethingList[3].Perfection > 4999)
                            {
                                SomethingList[3].Grade = 5;
                            }
                        }
                        break;
                    }
                case 7:
                    {
                        if (isWork[i] == true)
                        {
                            MaterialData.Instance.MaterialList[5].Count -= UseMat[NowWorkNum];

                            SomethingList[4].Perfection += UseMat[NowWorkNum] * 10;

                            if (UnityEngine.Random.Range(0, 100) < 1)
                            {
                                SomethingList[4].Grade = 6;
                                //타임머신 생성될 것같은 루트로 빠진다.
                                //변수 필요

                            }//타임머신 생성

                            else
                            {

                                if (SomethingList[4].Perfection > 199 && SomethingList[4].Perfection < 500)
                                {
                                    SomethingList[4].Grade = 1;
                                    //1단계 통신장치 생성
                                }
                                else if (SomethingList[4].Perfection > 499 && SomethingList[4].Perfection < 1000)
                                {
                                    SomethingList[4].Grade = 2;
                                }
                                else if (SomethingList[4].Perfection > 999 && SomethingList[4].Perfection < 2000)
                                {
                                    SomethingList[4].Grade = 3;
                                }
                                else if (SomethingList[4].Perfection > 1999 && SomethingList[4].Perfection < 3000)
                                {
                                    SomethingList[4].Grade = 4;
                                }
                                else if (SomethingList[4].Perfection > 2999)
                                {
                                    SomethingList[4].Grade = 5;
                                }
                            }
                        }
                        break;
                    }
                case 8:
                    {
                        if (isWork[i] == true)
                        {
                            MaterialData.Instance.MaterialList[6].Count -= UseMat[NowWorkNum];

                            //약 생성
                            Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                        }
                        break;
                    }
                case 9:
                    {
                        if (isWork[i] == true)
                        {
                            if (UnityEngine.Random.Range(0, 100) < (CharacterData.Instance.AllCharacter[now].Work8 + ToolAbility(Toolmax)))
                            {

                                FoodData.Instance.FoodList[4].Count += 10;//고기 10개 획득


                            }
                        }
                        break;
                    }
                case 10:
                    {
                        if (isWork[i] == true)
                        {
                            for (int j = 0; j < MaterialData.Instance.MaterialList.Count; j++)
                            {
                                MaterialData.Instance.MaterialList[j].Count += 10;

                            }
                            for (int j = 0; j < ToolData.Instance.ToolList.Count; j++)
                            {
                                ToolData.Instance.ToolList[j].Count += 10;

                            }
                        }
                        break;
                    }
            }
        }
        for (int i = 0; i < isWork.Length; i++)
        {
            isWork[i] = false;
            
        }
        for (int i = 0; i < UseMat.Length; i++)
        {
            UseMat[i] = 0;
        }
        for (int i = 0; i < UseFood.Length; i++)
        {
            UseFood[i] = 0;
        }
        SomethingSave();
        NowWorkNum = 0;
    }

    public void YesButton()//제작버튼
    {
        int now = MyCharacterData.Instance.NowCharacterName; // 선택한 캐릭터 번호
        
        //workSelectPopup.SetActive(false);
        switch (NowWorkNum)
        {
            case 1://옷
                {
                   



                    if (MaterialData.Instance.MaterialList[0].Count < 0 || temp <0)//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        //확률따져서 날개옷 생성


                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "옷(00+00/100)을 만드시겠습니까?";

                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);

                    }
                    
                   
                    //popupMode[0].SetActive(false);
                    break;

                }//case 1

            case 2://배
                {
                    

                    Toolmax = Math.Max(ToolData.Instance.ToolList[(1 * 3) + 0].Count, ToolData.Instance.ToolList[(1 * 3) + 1].Count);
                    Toolmax = Math.Max(Toolmax, ToolData.Instance.ToolList[(1 * 3) + 2].Count);

                    if (MaterialData.Instance.MaterialList[1].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "배(00+00/100)을 만드시겠습니까?";


                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    }
                   
                    
                    break;
                }//case 2

            case 3://요리
                {
                    /*************************************************************************************************************
                    //요리에서 각각의 재료를 ++하는 버튼을 눌렀을 때 어느 변수에다가 저장해둬야만 요리가 몇개만들어지는지 확인 가능
                    *************************************************************************************************************/

                    
                   
                    int fdtemp = FoodData.Instance.FoodList[0].Count + FoodData.Instance.FoodList[4].Count + FoodData.Instance.FoodList[8].Count;
                    if (fdtemp<1 || temp < 1)// 또한 물고기, 고기, 쌀이 없을 때 안됨
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        Debug.Log(CharacterData.Instance.AllCharacter[now].Name + "일이 가능합니다" + CharacterData.Instance.AllCharacter[now].Work3);
                        //도구 단계에 따라 + 능력치 해줘야함


                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "밥 0 개  고기요리 0 개 생선요리 0 개를 만드시겠습니까?";

                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    }
                  
                    UseFood[0] = UseFood[1] = UseFood[2] = 0;
                    break;
                }

            case 4://낚시
                {
                    //확률 따져서 인어맨 엔딩 시작 -> EndingEvent Script 참고
                    

                    
                    if (MaterialData.Instance.MaterialList[2].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        EndingEvent.Instance.MerTF = true;
                        EndingEvent.Instance.fishing = true;
                        EndingEvent.Instance.MerEvent();

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "물고기 0 마리를 잡으러 가시겠습니까?";


                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);

                    }
                  
                    EndingEvent.Instance.fishing = false;
                    break;
                }//case 4

            case 5://농사
                {

                    


                    
                    if (MaterialData.Instance.MaterialList[3].Count < 1 || temp < 1)//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = " 벼를 0개 수확하러 가시겠습니까?";


                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                        //else 일을 안한다는 버튼
                    }
                  
                    break;
                }//case 5

            case 6://건축
                {
                    

                   
                    if (MaterialData.Instance.MaterialList[4].Count < 1 || temp < 1)//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "집(00+00/100)을 만드시겠습니까?";




                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);

                        //else 일을 안한다는 버튼
                    }
                   
                    break;
                }//case 6

            case 7://통신
                {
                    //확률따져서 타임머신 생성

                   
                    if (MaterialData.Instance.MaterialList[5].Count < 1 || temp < 1)//도구,재료가 없을때(일을 못함)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);


                    }
                    else
                    {
                        isWork[NowWorkNum] = true;

                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "통신기계(00+00/100)을 만드시겠습니까?";

                        Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                        



                        //else 일을 안한다는 버튼
                    }
                 
                    break;
                }//case 7

            case 8://제약
                {
                   
                    if (MaterialData.Instance.MaterialList[6].Count<1 || temp < 1)// 또한 물고기, 고기, 쌀이 없을 때 안됨
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        iTween.ShakePosition(workSelectPopup, new Vector3(0.5f, 0, 0), 0.5f);
                    }
                    else
                    {
                        isWork[NowWorkNum] = true;
                        goAreaPopup.SetActive(true);
                        workYesClickTxt.text = "약을 0개  제조하시겠습니까?";
                    }
                   
                    break;
                }//case 8

            case 9://수렵
                {
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(8 * 3) + i].Count;
                        if (ToolData.Instance.ToolList[(8 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }
                    }

                    if (temp < 1)
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
                    break;
                }//case 9

            case 10://탐험
                {
                    isWork[NowWorkNum] = true;


                    EndingEvent.Instance.adven = true;
                    EndingEvent.Instance.BottleEvent();
                    
                   
                   
                    Char[MyCharacterData.Instance.CharacterName.IndexOf(now)].SetActive(false);
                    break;
                }//case 10
        }

        //UseMat = 0;
        
        temp = 0;
    }
    public void NoClicked()                                                             //제작취소
    {
        /*public TextMeshProUGUI[] CookMatCounText;
    public TextMeshProUGUI[] CookCounText;
    public TextMeshProUGUI FishMatCountText;
    public TextMeshProUGUI FishCountText;
    public TextMeshProUGUI FarmMatCountText;
    public TextMeshProUGUI FarmCountText;
    public TextMeshProUGUI MediMatCountText;
    public TextMeshProUGUI MediCountText;*/

        MatCountText.text = "0";
        CookMatCounText[0].text = CookMatCounText[1].text = CookMatCounText[2].text = "0";
        CookCounText[0].text = CookCounText[1].text = CookCounText[2].text = "0";

        FishMatCountText.text= "0";
        FishCountText.text = "0";
        FarmMatCountText.text = "0";
        FarmCountText.text = "0";
        MediMatCountText.text = "0";
        MediCountText.text = "0";
        for (int i = 0; i < 11; i++)
        {
            UseMat[i] = 0;
        }
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
        MatCountText.text = "0";
        CookMatCounText[0].text = CookMatCounText[1].text = CookMatCounText[2].text = "0";
        CookCounText[0].text = CookCounText[1].text = CookCounText[2].text = "0";

        FishMatCountText.text = "0";
        FishCountText.text = "0";
        FarmMatCountText.text = "0";
        FarmCountText.text = "0";
        MediMatCountText.text = "0";
        MediCountText.text = "0";
        for (int i = 0; i < 11; i++)
        {
            UseMat[i] = 0;
        }

    }
    public void WorkNo() {                                                      //마지막 팝업창에서 취소버튼 이전창으로만 돌아가면 되는데 탐험을선택했을때는 지도를 꺼버림
        goAreaPopup.SetActive(false);
        if (popupMode[6].activeSelf == true)
            popupMode[6].SetActive(false);
    }//마지막 일할지 안할지 선택할 떄 No 버튼

    public void MatQuanUpClicked()
    {
        //각각의 PopupMode의 Up/Down 버튼마다 TextMesh가 다르기 때문에 메소드도 각각 만들어줘야한다
        Debug.Log("Matup");
        string str = EventSystem.current.currentSelectedGameObject.name;
        int now = MyCharacterData.Instance.NowCharacterName;
        int min=0;
        switch (NowWorkNum)
        {
            case 1://옷
                {
                    for (int i = 0; i < 3; i++)
                    {
                        /*****************************************************************
                        //어떤 도구를 사용할지는 ToolData Json을 확인하여 능력치를 올려준다
                        *******************************************************************/

                        temp += ToolData.Instance.ToolList[(0 * 3) + i].Count;
                        if (ToolData.Instance.ToolList[(0 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }

                    }//도구가 존재하는지 확인한다


                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work1 + ToolAbility(Toolmax)) / 10, MaterialData.Instance.MaterialList[0].Count);

                    if (UseMat[NowWorkNum] < min )
                    {
                        UseMat[NowWorkNum]++;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                        //TextMash.text = UseMat[NowWorkNum] ;
                    }

                
                    break;

                }//case 1

            case 2://배
                {
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(1 * 3) + i].Count;
                        if (ToolData.Instance.ToolList[(1 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }
                    }

                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work2 + ToolAbility(Toolmax)) / 10, MaterialData.Instance.MaterialList[1].Count);

                    if (UseMat[NowWorkNum] < min)
                    {
                        UseMat[NowWorkNum]++;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                        //TextMash.text = UseMat[NowWorkNum] ;
                    }


                    break;
                }//case 2

            case 3://요리
                {

                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(2 * 3) + i].Count;
                        if (ToolData.Instance.ToolList[(2 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }
                    }

                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work2 + ToolAbility(Toolmax)) / 10, 
                        (FoodData.Instance.FoodList[0].Count + FoodData.Instance.FoodList[4].Count + FoodData.Instance.FoodList[8].Count));

                    if ((UseFood[0] + UseFood[1] + UseFood[2]) < min)
                    {
                        if (str == "UpButton")
                        {
                            if (UseFood[0] < FoodData.Instance.FoodList[0].Count)
                            {
                                UseFood[0]++;
                                CookMatCounText[0].text = UseFood[0].ToString();
                                CookCounText[0].text = UseFood[0].ToString();
                            }
                            //else
                            //안됨

                        }
                        else if (str == "UpButton (1)")
                        {
                            if (UseFood[1] < FoodData.Instance.FoodList[4].Count)
                            {
                                UseFood[1]++;
                                CookMatCounText[1].text = UseFood[1].ToString();
                                CookCounText[1].text = UseFood[1].ToString();
                            }
                            //else
                            //안됨
                        }
                        else if (str == "UpButton (2)")
                        {
                            if (UseFood[2] < FoodData.Instance.FoodList[8].Count)
                            {
                                UseFood[2]++;
                                CookMatCounText[2].text = UseFood[2].ToString();
                                CookCounText[2].text = UseFood[2].ToString();
                            }
                            //else
                            //안됨
                        }
                    }
                    else
                    {
                        Debug.Log("재료가 1개도 없습니다.");
                    }
                    break;
                }

            case 4://낚시
                {
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(3 * 3) + i].Count;
                        if (ToolData.Instance.ToolList[(3 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }
                    }

                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work4 + ToolAbility(Toolmax)) / 10, MaterialData.Instance.MaterialList[2].Count);

                    if (UseMat[NowWorkNum] < min)
                    {
                        UseMat[NowWorkNum]++;
                        FishMatCountText.text = UseMat[NowWorkNum].ToString();
                    }
                    break;
                }//case 4

            case 5://농사
                {
                    for (int i = 0; i < 3; i++)
                    {
                        /*****************************************************************
                        //어떤 도구를 사용할지는 ToolData Json을 확인하여 능력치를 올려준다
                        *******************************************************************/

                        temp += ToolData.Instance.ToolList[(4 * 3) + i].Count;
                        if (ToolData.Instance.ToolList[(4 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }
                    }//도구가 존재하는지 확인한다

                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work5 + ToolAbility(Toolmax)) / 10, MaterialData.Instance.MaterialList[3].Count);

                    if (UseMat[NowWorkNum] < min)
                    {
                        UseMat[NowWorkNum]++;
                        FarmMatCountText.text = UseMat[NowWorkNum].ToString();
                        //TextMash.text = UseMat[NowWorkNum] ;
                    }
                    break;
                }//case 5

            case 6://건축
                {
                    for (int i = 0; i < 3; i++)
                    {
                        /*****************************************************************
                        //어떤 도구를 사용할지는 ToolData Json을 확인하여 능력치를 올려준다
                        *******************************************************************/

                        temp += ToolData.Instance.ToolList[(5 * 3) + i].Count;

                        if (ToolData.Instance.ToolList[(5 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }

                    }//도구가 존재하는지 확인한다

                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work6 + ToolAbility(Toolmax)) / 10, MaterialData.Instance.MaterialList[4].Count);

                    if (UseMat[NowWorkNum] < min)
                    {
                        UseMat[NowWorkNum]++;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                        //TextMash.text = UseMat[NowWorkNum] ;
                    }

                    break;
                }//case 6

            case 7://통신
                {
                    for (int i = 0; i < 3; i++)
                    {
                        /*****************************************************************
                        //어떤 도구를 사용할지는 ToolData Json을 확인하여 능력치를 올려준다
                        *******************************************************************/

                        temp += ToolData.Instance.ToolList[(6 * 3) + i].Count;

                        if (ToolData.Instance.ToolList[(6 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }

                    }//도구가 존재하는지 확인한다

                   

                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work7 + ToolAbility(Toolmax)) / 10, MaterialData.Instance.MaterialList[4].Count);

                    if (UseMat[NowWorkNum] < min)
                    {
                        UseMat[NowWorkNum]++;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                        //TextMash.text = UseMat[NowWorkNum] ;
                    }
                    break;
                }//case 7

            case 8://제약
                {
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(7 * 3) + i].Count;
                        if (ToolData.Instance.ToolList[(7 * 3) + i].Count > 0)
                        {
                            Toolmax = i + 1;
                        }
                    }

                    min = Math.Min((CharacterData.Instance.AllCharacter[now].Work8 + ToolAbility(Toolmax)) / 10, MaterialData.Instance.MaterialList[6].Count);

                    if (UseMat[NowWorkNum] < min)
                    {
                        UseMat[NowWorkNum]++;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        MediMatCountText.text = UseMat[NowWorkNum].ToString();
                    }
                    break;
                }//case 8

            case 9://수렵
                {
                    

                    
                    break;
                }//case 9

            case 10://탐험
                {


                    //탐험 구현
                    //지도열어야함
                    //지도에 각각 지역당 얻을 수 있는 것들을 Text로 표시



                    goAreaPopup.SetActive(false);//지도 닫기
                    popupMode[6].SetActive(false);
                    break;
                }//case 10
        }

    }
    public void MatQuanDownClicked()
    {

        Debug.Log("MatDown");
        string str = EventSystem.current.currentSelectedGameObject.name;
        switch (NowWorkNum)
        {
            case 1://옷
                {




                    if (UseMat[NowWorkNum] > 0)
                    {
                        UseMat[NowWorkNum]--;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                    }


                    break;

                }//case 1

            case 2://배
                {
                    if (UseMat[NowWorkNum] > 0)
                    {
                        UseMat[NowWorkNum]--;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                    }

                    break;
                }//case 2

            case 3://요리
                {

                    
                    
                        if (str == "DownButton")
                        {
                            if (UseFood[0] > 0)
                            {
                                UseFood[0]--;
                                CookMatCounText[0].text = UseFood[0].ToString();
                                CookCounText[0].text = UseFood[0].ToString();
                            }
                        //else
                        //안됨

                    }
                        else if (str == "DownButton (1)")
                        {
                            if (UseFood[1] > 0)
                            {
                                UseFood[1]--;
                                CookMatCounText[1].text = UseFood[1].ToString();
                                CookCounText[1].text = UseFood[1].ToString();
                            }
                        //else
                        //안됨
                    }
                        else if (str == "DownButton (2)")
                        {
                            if (UseFood[2] > 0)
                            {
                                UseFood[2]--;
                                CookMatCounText[2].text = UseFood[2].ToString();
                                CookCounText[2].text = UseFood[2].ToString();
                            }
                        //else
                        //안됨
                    }
                    
                   
                    break;
                }

            case 4://낚시
                {
                    if (UseMat[NowWorkNum] > 0)
                    {
                        UseMat[NowWorkNum]--;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        FishMatCountText.text = UseMat[NowWorkNum].ToString();
                    }
                    break;
                }//case 4

            case 5://농사
                {
                    if (UseMat[NowWorkNum] > 0)
                    {
                        UseMat[NowWorkNum]--;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        FarmMatCountText.text = UseMat[NowWorkNum].ToString();
                    }
                    break;
                }//case 5

            case 6://건축
                {
                    if (UseMat[NowWorkNum] > 0)
                    {
                        UseMat[NowWorkNum]--;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                    }

                    break;
                }//case 6

            case 7://통신
                {
                    if (UseMat[NowWorkNum] > 0)
                    {
                        UseMat[NowWorkNum]--;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        MatCountText.text = UseMat[NowWorkNum].ToString();
                    }
                    break;
                }//case 7

            case 8://제약
                {
                    if (UseMat[NowWorkNum] > 0)
                    {
                        UseMat[NowWorkNum]--;
                        //TextMash.text = UseMat[NowWorkNum] ;
                        MediMatCountText.text = UseMat[NowWorkNum].ToString();
                    }
                    break;
                }//case 8

            case 9://수렵
                {



                    break;
                }//case 9

            case 10://탐험
                {


                    //탐험 구현
                    //지도열어야함
                    //지도에 각각 지역당 얻을 수 있는 것들을 Text로 표시



                  
                    break;
                }//case 10
        }

    }


    public void work()
    {
        
        string str = EventSystem.current.currentSelectedGameObject.name;
        
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
                    switch (SomethingList[0].Grade)
                    {
                        case 0:
                            {
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes1");
                                break;
                            }
                        case 1:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes1");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes2");
                                break;
                            }
                        case 2:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes2");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes3");
                                break;
                            }
                        case 3:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes3");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes4");
                                break;
                            }
                        case 4:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes4");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes5");
                                break;
                            }
                        case 5:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes5");
                                
                                break;
                            }
                    }
                    
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/cloth");
                    NowWorkNum = 1;

                    float nowWorked = 3000;//현재 한 일의 양(누적)

                    float nowNeed = 4000;//지금 레벨업에 필요한 양

                    float beforeNeed = 200;//지금 레벨까지의 필요한 양

                    float todayWorked = 500;//Work.Instance.UseMat[1]*10;
                    float x = 395 * (nowWorked - beforeNeed) / (nowNeed - beforeNeed);


                    var gageTransform = expGage.transform as RectTransform;
                    gageTransform.sizeDelta = new Vector2(x, gageTransform.sizeDelta.y);
                    expGage.transform.localPosition = new Vector3((x / 2 - 305), gageTransform.localPosition.y, 0);
                    expSlider.value = ((nowWorked + todayWorked - beforeNeed) / (nowNeed - beforeNeed));



                    break;
                }

            case "WorkButton2"://배만들기
                {
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    switch (SomethingList[1].Grade)
                    {
                        case 0:
                            {
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship1");
                                break;
                            }
                        case 1:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship1");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship2");
                                break;
                            }
                        case 2:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship2");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship3");
                                break;
                            }
                        case 3:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship3");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship4");
                                break;
                            }
                        case 4:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship4");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship5");
                                break;
                            }
                        case 5:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship5");

                                break;
                            }
                    }
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/steal");
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
                    switch (SomethingList[3].Grade)
                    {
                        case 0:
                            {
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house1");
                                break;
                            }
                        case 1:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house1");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house2");
                                break;
                            }
                        case 2:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house2");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house3");
                                break;
                            }
                        case 3:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house3");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house4");
                                break;
                            }
                        case 4:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house4");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house5");
                                break;
                            }
                        case 5:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house5");

                                break;
                            }
                    }
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/brick");
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    NowWorkNum = 6;
                    
                    break;
                }
            case "WorkButton7"://통신장치만
                {
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    switch (SomethingList[4].Grade)
                    {
                        case 0:
                            {
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine1");
                                break;
                            }
                        case 1:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine1");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine2");
                                break;
                            }
                        case 2:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine2");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine3");
                                break;
                            }
                        case 3:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine3");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine4");
                                break;
                            }
                        case 4:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine4");
                                AfterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine5");
                                break;
                            }
                        case 5:
                            {
                                BeforeImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine5");

                                break;
                            }
                    }
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/elecline");
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
        File.WriteAllText(Application.dataPath + "/Resources/Something.json", SomethingJson.ToString());

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
        File.WriteAllText(Application.dataPath + "/Resources/Something.json", SomethingJson.ToString());
        //File.WriteAllText(Application.persistentDataPath + "/Something.json", SomethingJson.ToString());//안드로이드
        //컴퓨터


        yield return null;
    }

    IEnumerator SomethingLoad()
    {

        //string SomethingString = File.ReadAllText(Application.persistentDataPath + "/Something.json");
        string SomethingString = File.ReadAllText(Application.dataPath + "/Resources/Something.json");

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
