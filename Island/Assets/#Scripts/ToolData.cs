using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Tooll
{





    public int Count;



    public Tooll(int count)
    {

        Count = count;

    }

}

public class ToolData : SingleTon<ToolData>
{
    public string[] Name;
    public string[] Text;
    public List<Tooll> ToolList = new List<Tooll>();
    public List<Tooll> ChangeList = new List<Tooll>();
    public Tooll t;
    

    bool isPaused = false;
    int count;
    // Use this for initialization
    void Start()
    {



        clear();
       load();
        
        
    }
   
    
    void OnApplicationQuit()
    {

        Debug.Log("강제종료ToolData");
        StartCoroutine(ToolSave());

    }
    public void save()
    {
        StartCoroutine(ToolSave());
    }

    public void load()
    {
        StartCoroutine(ToolLoad());
    }
    public void clear()
    {
        StartCoroutine(ToolClear());
    }


    
    IEnumerator ToolClear()
    {

        List<Tooll> TempList = new List<Tooll>();

        for (int i = 0; i < 27; i++)
        {
            //text = Text[i];
            //name = Name[i];

            count = 0;

            t = new Tooll(count);

            //sa += ToKor(mt);

            TempList.Add(t);

        }
        

        JsonData ToolJson = JsonMapper.ToJson(TempList);
        //File.WriteAllText(Application.persistentDataPath + "/ToolData.json", ToolJson.ToString());
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/ToolData.json", ToolJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/ToolData.json", ToolJson.ToString());

        yield return null;
    }
    IEnumerator ToolSave()
    {

        List<Tooll> TempList = new List<Tooll>();

        for (int i = 0; i < ToolList.Count; i++)
        {
            //text = Text[i];
            //name = Name[i];

            count = ToolList[i].Count;

            t = new Tooll(count);

            //sa += ToKor(mt);

            TempList.Add(t);

        }


        JsonData ToolJson = JsonMapper.ToJson(TempList);
        //File.WriteAllText(Application.persistentDataPath + "/ToolData.json", ToolJson.ToString());
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/ToolData.json", ToolJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/ToolData.json", ToolJson.ToString());


        yield return null;
    }
    // Update is called once per frame

    IEnumerator ToolLoad()
    {

        //string ToolString = File.ReadAllText(Application.persistentDataPath + "/ToolData.json");
        string ToolString;

        if (EndingEvent.Instance.path == Application.persistentDataPath)
            ToolString = File.ReadAllText(Application.persistentDataPath + "/ToolData.json");
        else
            ToolString = File.ReadAllText(EndingEvent.Instance.path + "/Resources/ToolData.json");


        Debug.Log(ToolString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(ToolString);
        //태그로 정렬 가능?

        ParsingTool(itemData);

        yield return null;

    }

    private void ParsingTool(JsonData Data)
    {
        Tooll tl;
        for (int i = 0; i < Data.Count; i++)
        {


            //text = Data[i]["Text"].ToString();
            //Debug.Log(Data[i]["Text"]);

            //name = Data[i]["Name"].ToString();
            //Debug.Log(Data[i]["Name"]);
            //count = int.Parse(Data[i]["Count"].ToString());

            tl = new Tooll(int.Parse(Data[i]["Count"].ToString()));

            ToolList.Add(tl);




        }
    }
}
