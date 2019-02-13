using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;



public class Manu
{
    public int Grade;

    public Manu(int grade)
    {
        Grade = grade;
    }
}

public class ManufactureData : SingleTon<ManufactureData> {
    
    public List<Manu> ManuList = new List<Manu>();

    public Manu m;
    public GameObject[] Manuarr;
    public List<GameObject> Manu = new List<GameObject>();

    bool isPaused = false;
    int count;
    int temp=0;
    // Use this for initialization
    void Start()
    {

        
        load();
        

    }


    void OnApplicationQuit()
    {
        

    }
    public void save()
    {
        StartCoroutine(ManuSave());
    }

    public void load()
    {
        StartCoroutine(ManuLoad());
    }
    public void clear()
    {
        StartCoroutine(ManuClear());
    }

    public void UseManu(Button button)
    {
        switch (button.ToString())
        {
            case ("Button1 (UnityEngine.UI.Button)"):
                {
                    //옷
                    if (ManuList[0].Grade == 6)
                    {
                        //날개옷 사용
                        EndingEvent.Instance.WingTF = true;
                        EndingEvent.Instance.already = false;
                        EndingEvent.Instance.WingEvent();
                    }
                    
                    //모든 case마다 사용하시겠습니까? 팝업 넣기
                    break;
                }
            case ("Button2 (UnityEngine.UI.Button)"):
                {
                    //배
                    EndingEvent.Instance.ShipTF = true;
                    EndingEvent.Instance.already = false;
                    
                    //배가 바다에 떠있는 만화컷,ship1 text
                    EndingEvent.Instance.ShipEvent();
                    break;
                }
            case ("Button3 (UnityEngine.UI.Button)"):
                {
                    //집
                    //설명
                    break;
                }
            case ("Button4 (UnityEngine.UI.Button)"):
                {

                    if (ManuList[3].Grade == 6)
                    {
                        //타임머신 사용
                        EndingEvent.Instance.TimeTF = true;
                        EndingEvent.Instance.already = false;
                        EndingEvent.Instance.TimeEvent();
                    }

                    //통신장치
                    EndingEvent.Instance.EngineTF = true;
                    EndingEvent.Instance.already = false;
                    EndingEvent.Instance.EngineDay = PlayerPrefs.GetInt("Day");
                    //작동 만화컷,engine1 text
                    EndingEvent.Instance.EngineEvent();

                    break;
                }
            case ("Button5 (UnityEngine.UI.Button)"):
                {
                    //물병
                    EndingEvent.Instance.BottleTF = true;
                    EndingEvent.Instance.already = false;
                    EndingEvent.Instance.BottleDay = PlayerPrefs.GetInt("Day");
                    break;
                }
            case ("Button6 (UnityEngine.UI.Button)"):
                {
                    //랜턴
                    //야간 탐험에 사용할 수 있다. 팝업창 띄우기
                    break;
                }
            case ("Button7 (UnityEngine.UI.Button)"):
                {
                    //독수리
                    //거대 독수리는 다른 섬을 탐험하거나 탈출할 때 쓰입니다. 탈출에 사용하시겠습니까? 팝업
                    EndingEvent.Instance.EagleTF = true;
                    EndingEvent.Instance.EagleEvent();
                    break;
                }
            case ("Button8 (UnityEngine.UI.Button)"):
                {
                    //빙산
                    if (FoodData.Instance.FoodList[8].Count > 99)
                    {
                        //빙판을 사용하시겠습니까? 팝업
                        EndingEvent.Instance.IceTF = true;
                        EndingEvent.Instance.already = false;
                        EndingEvent.Instance.IceEvent();
                    }
                    else
                    {
                        //가지고 있는 물고기 수가 빙판을 끌기에는 부족합니다. 팝업
                    }
                    break;
                }
            case ("Button9 (UnityEngine.UI.Button)"):
                {
                    //나뭇잎
                    EndingEvent.Instance.LeafTF = true;
                    EndingEvent.Instance.already = false;
                    EndingEvent.Instance.LeafEvent();
                    break;
                }
        }
    }

    public void FreshManu()
    {
        GameObject gmtemp;
        Vector3 vc;
        for (int i = 0; i < ManuList.Count; i++)
        {

            
                switch (i)
                {
                    case 0:
                        {
                            if(ManuList[i].Grade==1)
                        {   Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes1");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if(ManuList[i].Grade == 2)
                        {       Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes2");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 3)
                        {       Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes3");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 4)
                        {       Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes4");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 5)
                        {       Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/clothes5");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 6)
                        {       Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/timemachine");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        break;
                        }
                case 1:
                    {
                        if (ManuList[i].Grade == 1)
                        {
                            Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship1");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 2)
                        {   Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship2");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 3)
                        {    Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship3");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 4)
                        {    Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship4");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 5)
                        {    Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/ship5");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        break;
                    }
                case 2:
                    {
                        if (ManuList[i].Grade == 1)
                        { Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house1");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 2)
                        {    Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house2");
                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 3)
                        {    Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house3");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 4)
                        {    Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house4");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 5)
                        {    Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/house5");
                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        
                        break;
                    }
                case 3:
                    {
                        if (ManuList[i].Grade == 1)
                        {
                            Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine1");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 2)
                        { Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine2");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 3)
                        { Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine3");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 4)
                        { Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine4");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        else if (ManuList[i].Grade == 5)
                        { Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/machine5");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        
                        break;
                    }
                case 4:
                    {
                        if (ManuList[i].Grade == 1)
                        {
                            Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/bottle");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }
                        
                        break;
                    }
                case 5:
                    {
                        if (ManuList[i].Grade == 1)
                        {
                            Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/lantern 2");
                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }

                        break;
                    }
                case 6:
                    {
                        if (ManuList[i].Grade == 1)
                        {
                            Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/hawk");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }

                        break;
                    }
                case 7:
                    {
                        if (ManuList[i].Grade == 1)
                        {
                            Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/iceplace");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }

                        break;
                    }
                case 8:
                    {
                        if (ManuList[i].Grade == 1)
                        {
                            Manuarr[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("MainSceneImage/Manufacture/bigleaf");

                            vc = new Vector3(Manuarr[i].transform.localPosition.x, Manuarr[i].transform.localPosition.y);
                            Manuarr[i].transform.localPosition = Manuarr[temp].transform.localPosition;
                            Manuarr[temp].transform.localPosition = vc;
                            Manuarr[i].SetActive(true);
                            temp++;
                        }

                        break;
                    }
            }

            

        }
        temp = 0;
    }

    IEnumerator ManuClear()
    {

        List<Manu> TempList = new List<Manu>();

        for (int i = 0; i < 9; i++) //일반맵은 8개 빙산,더운 맵은 9개 (빙산, 나뭇잎)
        {
            //text = Text[i];
            //name = Name[i];


            m = new Manu(0);

            //sa += ToKor(mt);

            TempList.Add(m);

        }


        JsonData ManuJson = JsonMapper.ToJson(TempList);
        //File.WriteAllText(Application.persistentDataPath + "/ManuData.json", ManuJson.ToString());
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/ManuData.json", ManuJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/ManuData.json", ManuJson.ToString());

        yield return null;
    }
    IEnumerator ManuSave()
    {

        List<Manu> TempList = new List<Manu>();

        for (int i = 0; i < ManuList.Count; i++)
        {
            //text = Text[i];
            //name = Name[i];

            count = ManuList[i].Grade;

            m = new Manu(count);

            //sa += ToKor(mt);

            TempList.Add(m);

        }


        JsonData ManuJson = JsonMapper.ToJson(TempList);
        //File.WriteAllText(Application.persistentDataPath + "/ManuData.json", ManuJson.ToString());
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/ManuData.json", ManuJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/ManuData.json", ManuJson.ToString());

        yield return null;
    }
    // Update is called once per frame

    IEnumerator ManuLoad()
    {

        //string ManuString = File.ReadAllText(Application.persistentDataPath + "/ManuData.json");
        string ManuString;

        if (EndingEvent.Instance.path == Application.persistentDataPath)
            ManuString = File.ReadAllText(Application.persistentDataPath + "/ManuData.json");
        else
            ManuString = File.ReadAllText(EndingEvent.Instance.path + "/Resources/ManuData.json");


        Debug.Log(ManuString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(ManuString);
        //태그로 정렬 가능?

        ParsingManu(itemData);

        yield return null;

    }

    private void ParsingManu(JsonData Data)
    {
        Manu mn;
        for (int i = 0; i < Data.Count; i++)
        {


            //text = Data[i]["Text"].ToString();
            //Debug.Log(Data[i]["Text"]);

            //name = Data[i]["Name"].ToString();
            //Debug.Log(Data[i]["Name"]);
            //count = int.Parse(Data[i]["Count"].ToString());

            mn = new Manu(int.Parse(Data[i]["Grade"].ToString()));

            ManuList.Add(mn);




        }
    }
}
