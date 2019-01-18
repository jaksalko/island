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
    public string[] Name= { "쌀","밥1", "밥2", "밥3", "고기", "고기요리1", "고기요리2", "고기요리3", "물고기", "물고기요리1", "물고기요리2", "물고기요리3" };
    public string[] Text= { "농사를 지어 얻어낸 쌀이다. 생으로 먹을 순 없을 것 같다. 요리를 통해 밥을 지어 먹을 수 있을 것 같다.",
    "따끈따끈해 보이는 밥이다. 먹으면 포만감이 ()만큼 회복된다.",
    "따끈따끈해 보이는 밥이다. 먹으면 포만감이 ()만큼 회복된다.",
    "따끈따끈해 보이는 밥이다. 먹으면 포만감이 ()만큼 회복된다.",
    "동물을 잡아 얻어낸 고기이다. 생으로 먹을 수 있을 것 같다. 요리를 통해 먹으면 포만감이 더욱 회복된다. 먹으면 포만감이 ()만큼 회복된다.",
    "먹음직스러워 보이는 고기요리이다. 먹으면 포만감이 ()만큼 회복된다.",
    "먹음직스러워 보이는 고기요리이다. 먹으면 포만감이 ()만큼 회복된다.",
    "먹음직스러워 보이는 고기요리이다. 먹으면 포만감이 ()만큼 회복된다.",
    "바다에서 잡아온 물고기이다. 생으로 먹을 수 있을 것 같다. 요리를 통해 먹으면 포만감이 더욱 회복된다. 먹으면 포만감이 ()만큼 회복된다.",
        "먹음직스러워 보이는 물고기요리이다. 먹으면 포만감이 ()만큼 회복된다.",
    "먹음직스러워 보이는 물고기요리이다. 먹으면 포만감이 ()만큼 회복된다.",
    "먹음직스러워 보이는 물고기요리이다. 먹으면 포만감이 ()만큼 회복된다."};

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
            //StartCoroutine(FoodSave());
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
        //StartCoroutine(FoodSave());

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


