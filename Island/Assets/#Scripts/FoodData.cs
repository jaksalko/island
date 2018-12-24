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
    public List<Foodd> FoodList = new List<Foodd>();
    public List<Foodd> ChangeList = new List<Foodd>();
    public Foodd fd;

    bool isPaused = false;
    int recovery;
    int count;

    // Use this for initialization
    void Start ()
    {

        StartCoroutine(FoodLoad());

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

        for (int i = 0; i <12; i++)
        {
            //recovery = InventoryManager.Instance.FData.FoodList[i].Recovery;
            //name = InventoryManager.Instance.FData.FoodList[i].Name;

            //count = InventoryManager.Instance.FData.FoodList[i].Count;

            fd = new Foodd(FoodList[i].Recovery, FoodList[i].Count);

            FoodList.Add(fd);

        }

        JsonData FoodJson = JsonMapper.ToJson(FoodList);

        File.WriteAllText(Application.dataPath + "/Resources/FoodData.json", FoodJson.ToString());

        yield return null;
    }

    IEnumerator FoodClear()
    {

        for (int i = 0; i < 12; i++)
        {
            //recovery = InventoryManager.Instance.FData.FoodList[i].Recovery;
            //name = InventoryManager.Instance.FData.FoodList[i].Name;

            //count = InventoryManager.Instance.FData.FoodList[i].Count;

            fd = new Foodd(0, 0);

            FoodList.Add(fd);

        }

        JsonData FoodJson = JsonMapper.ToJson(FoodList);

        File.WriteAllText(Application.dataPath + "/Resources/FoodData.json", FoodJson.ToString());

        yield return null;
    }


    // Update is called once per frame

    IEnumerator FoodLoad()
    {

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


