using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Foodd
{
    public int Recovery;


    public int Count;

    public Foodd(int recovery,int count)
    {
        Recovery = recovery; //음식을 만들었을 때 캐릭터의 요리 능력치로 초기화시켜 줘야함


        Count = count;
    }
}

public class FoodData : SingleTon<FoodData>
{
    public string[] Name;
    public string[] Text;

    public List<Foodd> FoodList = new List<Foodd>();
    public List<Foodd> ChangeList = new List<Foodd>();
    public Foodd fd;

    bool isPaused = false;
    int recovery;
    int count;

    // Use this for initialization
    void Start ()
    {
        
        
            StartCoroutine(FoodClear());
            PlayerPrefs.SetInt("Count", 1);
            StartCoroutine(FoodLoad());
        

       
            
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //MaterialList[1].Count++;
            //ToolData.Instance.ToolList[1].Count++;
            //ToolData.Instance.save();
            //FoodData.Instance.FoodList[1].Count++;
            //FoodData.Instance.save();
            //StartCoroutine(MaterialSave());


        }

    }
    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            //for (int i = 0; i < mData.MaterialList.Length; i++)
            //    mData.MaterialList[i].Count++;
            StartCoroutine(FoodSave());
            isPaused = true;

        }

        else
        {
            if (isPaused)
            {
                StartCoroutine(FoodLoad());

            }
        }
    }

    void OnApplicationQuit()
    {

        Debug.Log("강제종료FoodData");
        StartCoroutine(FoodSave());

    }
    public void save()
    {
        StartCoroutine(FoodSave());
    }

    //private string ToKor(Foodd f)
    //{

    //    JsonData ch1 = JsonMapper.ToJson(fd);

    //    string tmpstring = ch1.ToString();

    //    string[] tmpcomma = tmpstring.Split(',');

    //    string[] tmpcolon = tmpcomma[1].Split(':');

    //    string res = tmpcolon[0] + ":" + "'" + fd.Name + "'";

    //    string ress = tmpcomma[0] + "," + res + "," + tmpcomma[2];

    //    return ress;

    //}



    IEnumerator FoodSave()
    {
         List<Foodd> TempList = new List<Foodd>();
        for (int i = 0; i <FoodList.Count; i++)
        {
            //recovery = InventoryManager.Instance.FData.FoodList[i].Recovery;
            //name = InventoryManager.Instance.FData.FoodList[i].Name;

            //count = InventoryManager.Instance.FData.FoodList[i].Count;

            fd = new Foodd(FoodList[i].Recovery, FoodList[i].Count);

            TempList.Add(fd);

        }

        ChangeList = TempList;
        JsonData FoodJson = JsonMapper.ToJson(ChangeList);
        File.WriteAllText(Application.dataPath + "/Resources/FoodData.json", FoodJson.ToString());
        //File.WriteAllText(Application.persistentDataPath + "/FoodData.json", FoodJson.ToString());//안드로이드
        //컴퓨터


        yield return null;
    }

    IEnumerator FoodClear()
    {
        List<Foodd> TempList = new List<Foodd>();
        for (int i = 0; i < 12; i++)
        {
            //recovery = InventoryManager.Instance.FData.FoodList[i].Recovery;
            //name = InventoryManager.Instance.FData.FoodList[i].Name;

            //count = InventoryManager.Instance.FData.FoodList[i].Count;

            fd = new Foodd(0, 0);

            TempList.Add(fd);

        }

        JsonData FoodJson = JsonMapper.ToJson(TempList);

        //File.WriteAllText(Application.persistentDataPath + "/FoodData.json", FoodJson.ToString());
        File.WriteAllText(Application.dataPath + "/Resources/FoodData.json", FoodJson.ToString());

        yield return null;
    }


    // Update is called once per frame

    IEnumerator FoodLoad()
    {

        //string FoodString = File.ReadAllText(Application.persistentDataPath + "/FoodData.json");
        string FoodString = File.ReadAllText(Application.dataPath + "/Resources/FoodData.json");

        Debug.Log(FoodString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(FoodString);
        //태그로 정렬 가능?

        ParsingFood(itemData);

        yield return null;

    }

    private void ParsingFood(JsonData Data)
    {

        Foodd fd;
        for (int i = 0; i < Data.Count; i++)
        {


            //text = Data[i]["Text"].ToString();
            //Debug.Log(Data[i]["Text"]);

            //name = Data[i]["Name"].ToString();
            //Debug.Log(Data[i]["Name"]);
            //count = int.Parse(Data[i]["Count"].ToString());
            
                fd = new Foodd(int.Parse(Data[i]["Recovery"].ToString()),int.Parse(Data[i]["Count"].ToString()));


            
            FoodList.Add(fd);




        }

    }

    


}


