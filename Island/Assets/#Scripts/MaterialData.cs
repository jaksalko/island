using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Materiall
{

  
    


    public int Count;

    

    public Materiall(int count)
    {
       
        Count = count;
       
    }

}

public class MaterialData : SingleTon<MaterialData> {
    public string[] Text = { "옷을 만드는데에 사용됩니다. 1개당 10의 일을 합니다.",
        "배을 만드는데에 사용됩니다. 1개당 10의 일을 합니다.",
        "낚시를 하는데에 사용됩니다. (낚시하기)능력치 10당 미끼를 1개를 사용할 수 있습니다.",
        "쌀을 수확하는데에 사용됩니다. (농사하기)능력치 10당 씨앗 1개를 심을 수 있습니다.",
        "집을 만드는데에 사용됩니다. 1개당 10의 일을 합니다.",
        "통신장치을 만드는데에 사용됩니다. 1개당 10의 일을 합니다.",
        "약을 만드는데에 사용됩니다. 5개로 약을 하나 만듭니다." };
    public string[] Name = { "옷재료","배재료","미끼","씨앗","집재료","통신장치재료","약재료"};
    public List<Materiall> MaterialList = new List<Materiall>();
    public List<Materiall> ChangeList = new List<Materiall>();
    public Materiall mt;

    string name;
    string text;
    int count;
    bool isPaused = false;
    // Use this for initialization
    void Start ()
    {

        StartCoroutine(MaterialClear());
        StartCoroutine(MaterialLoad());
    }

    public void Press(Button bu)
    {
       

        switch (bu.ToString())
        {
              

            case "Text (UnityEngine.UI.Button)":
                {
                    
                    break;
                }

        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            MaterialList[1].Count++;
            StartCoroutine(MaterialSave());


        }

    }
    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            //for (int i = 0; i < mData.MaterialList.Length; i++)
            //    mData.MaterialList[i].Count++;
            StartCoroutine(MaterialSave());
            isPaused = true;

        }

        else
        {
            if (isPaused)
            {
                StartCoroutine(MaterialLoad());

            }
        }
    }

    void OnApplicationQuit()
    {

        Debug.Log("강제종료MaterialData");
        StartCoroutine(MaterialSave());

    }
   

   

   

    IEnumerator MaterialSave()
    {
        string sa = "";
        List<Materiall> TempList = new List<Materiall>();

        for (int i = 0; i < MaterialList.Count; i++)
        {
            //text = Text[i];
            //name = Name[i];

            count = 0;

            mt = new Materiall(count);

            //sa += ToKor(mt);

            TempList.Add(mt);

        }
        ChangeList = TempList;

        JsonData MaterialJson = JsonMapper.ToJson(ChangeList);

        File.WriteAllText(Application.dataPath + "/Resources/MaterialData.json", MaterialJson.ToString());

        yield return null;
    }

    IEnumerator MaterialClear()
    {

        List<Materiall> TempList = new List<Materiall>();

        for (int i = 0; i < 7; i++)
        {
            

            mt = new Materiall(0);

            //sa += ToKor(mt);

            TempList.Add(mt);

        }
        

        JsonData MaterialJson = JsonMapper.ToJson(TempList);

        File.WriteAllText(Application.dataPath + "/Resources/MaterialData.json", MaterialJson.ToString());

        yield return null;
    }
    // Update is called once per frame

    IEnumerator MaterialLoad()
    {

        string MaterialString = File.ReadAllText(Application.dataPath + "/Resources/MaterialData.json");

        Debug.Log(MaterialString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(MaterialString);
        //태그로 정렬 가능?
        
        ParsingMaterial(itemData);
        



        yield return null;

    }

    private void ParsingMaterial(JsonData Data)
    {
        Materiall mtt;
        for (int i = 0; i < Data.Count; i++)
        {


            //text = Data[i]["Text"].ToString();
            //Debug.Log(Data[i]["Text"]);

            //name = Data[i]["Name"].ToString();
            //Debug.Log(Data[i]["Name"]);
            //count = int.Parse(Data[i]["Count"].ToString());

            mtt = new Materiall(int.Parse(Data[i]["Count"].ToString()));

            MaterialList.Add(mtt);




        }
    }
}
