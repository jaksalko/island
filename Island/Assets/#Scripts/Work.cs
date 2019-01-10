using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
public class Work : MonoBehaviour
{
    public bool[] isWork = { false, };
    public int temp;
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
    // Use this for initialization
    public void work()
    {
        int now = MyCharacterData.Instance.NowCharacterName;
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
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/cloth");
                    for (int i = 0; i< 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(0 * 3) + i].Count;
                    }
                    if (MaterialData.Instance.MaterialList[0].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");

                        
                    }
                    else
                    {

                        //if(일을 한다는 버튼)
                        Debug.Log(CharacterData.Instance.AllCharacter[now].Name + "일이 가능합니다" + CharacterData.Instance.AllCharacter[now].Work1);
                        //도구 단계에 따라 + 능력치 해줘야함

                        //가지고 있고, 사용할 수 있는 재료의 최대치를 사용한다
                        if ((CharacterData.Instance.AllCharacter[now].Work1) / 10 > MaterialData.Instance.MaterialList[0].Count)//재료가 적을경우
                        {
                            Debug.Log("최대" + MaterialData.Instance.MaterialList[0].Count + "개의 재료 사용가능");
                        }
                        else
                        {
                            Debug.Log("최대" + (CharacterData.Instance.AllCharacter[now].Work1) / 10 + "개의 재료 사용가능");
                        }



                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton2"://배만들기
                {
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/steal");
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(1 * 3) + i].Count;
                    }
                    
                    if (MaterialData.Instance.MaterialList[1].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton3"://요리 -> 새 팝업창에서 요리를 클릭가능하게 하고 없으면 안된다는 팝업
                {
                    workSelectPopup.SetActive(true);
                    popupMode[4].SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(2 * 3) + i].Count;
                    }
                    if (temp < 1)// 또한 물고기, 고기, 쌀이 없을 때 안됨
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton4"://낚시
                {
                    workSelectPopup.SetActive(true);
                    popupMode[2].SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(3 * 3) + i].Count;
                    }
                    if (MaterialData.Instance.MaterialList[2].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton5"://농사
                {
                    workSelectPopup.SetActive(true);
                    popupMode[5].SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(4 * 3) + i].Count;
                    }
                    if (MaterialData.Instance.MaterialList[3].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton6"://집짓기
                {
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/brick");
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(5 * 3) + i].Count;
                    }
                    if (MaterialData.Instance.MaterialList[4].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton7"://통신장치만
                {
                    workSelectPopup.SetActive(true);
                    popupMode[0].SetActive(true);
                    normalModeMatImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/elecline");
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(6 * 3) + i].Count;
                    }
                    if (MaterialData.Instance.MaterialList[5].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton8"://제약
                {
                    workSelectPopup.SetActive(true);
                    popupMode[1].SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(7 * 3) + i].Count;
                    }
                    if (MaterialData.Instance.MaterialList[6].Count < 1 || temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton9"://수렵
                {
                    workSelectPopup.SetActive(true);
                    popupMode[3].SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(8 * 3) + i].Count;
                    }
                    if (temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton10"://탐험
                {
                    popupMode[6].SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        temp += ToolData.Instance.ToolList[(9 * 3) + i].Count;
                    }
                    if (temp < 1)
                    {
                        //일을 못합니다. 팝업 창 띄우기
                        Debug.Log("일을 못합니다.");
                    }
                    else
                    {
                        //if(일을 한다는 버튼)

                        //else 일을 안한다는 버튼
                    }
                    break;
                }
            case "WorkButton11"://쉬기
                {

                    break;
                }
        }

    }

    public void YesClicked() {
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
    public void NoClicked() {
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
    public void AreaClicked() {
        string str = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(str);
        if (str == "Area1") {   mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedA");}
        else if (str == "Area2") { mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedB"); }
        else if (str == "Area3") { mapBack.GetComponent<Image>().sprite = Resources.Load<Sprite>("mapBack_selectedC"); }
        goAreaPopup.SetActive(true);
    }
    public void MatQuanUpClicked() { Debug.Log("Matup"); }
    public void MatQuanDownClicked() { Debug.Log("MatDown"); }
}
