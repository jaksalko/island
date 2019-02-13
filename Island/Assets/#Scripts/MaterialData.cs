﻿using System.Collections;
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

public class MaterialData : SingleTon<MaterialData>
{



    public string[] Text;
    public string[] Name;
    public List<Materiall> MaterialList = new List<Materiall>();
    public List<Materiall> ChangeList = new List<Materiall>();
    public Materiall mt;

    string name;
    string text;
    int count;
    string path;
    bool isPaused = false;
    // Use this for initialization
    void Start ()
    {



        
        StartCoroutine(MaterialLoad());
    }

    public void Save()
    {
        StartCoroutine(MaterialSave());
    }
    public void Load()
    {
        StartCoroutine(MaterialLoad());
    }
    public void Clear()
    {
        StartCoroutine(MaterialClear());
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
            ToolData.Instance.ToolList[1].Count++;
           
            FoodData.Instance.FoodList[1].Count++;
          

            
        }

    }
   

    void OnApplicationQuit()
    {
        

    }
   

   

   

    IEnumerator MaterialSave()
    {

        List<Materiall> TempList = new List<Materiall>();

        for (int i = 0; i < MaterialList.Count; i++)
        {
            //text = Text[i];
            //name = Name[i];

            count = MaterialList[i].Count;

            mt = new Materiall(count);

            //sa += ToKor(mt);

            TempList.Add(mt);

        }
       

        JsonData MaterialJson = JsonMapper.ToJson(TempList);

        //File.WriteAllText(Application.persistentDataPath + "/MaterialData.json", MaterialJson.ToString());
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/MaterialData.json", MaterialJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/MaterialData.json", MaterialJson.ToString());

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

        //File.WriteAllText(Application.persistentDataPath + "/MaterialData.json", MaterialJson.ToString());
        
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/MaterialData.json", MaterialJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/MaterialData.json", MaterialJson.ToString());

        yield return null;
    }
    // Update is called once per frame

    IEnumerator MaterialLoad()
    {

        //string MaterialString = File.ReadAllText(Application.persistentDataPath + "/MaterialData.json");
        string MaterialString;
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            MaterialString = File.ReadAllText(Application.persistentDataPath + "/MaterialData.json");
        else
            MaterialString = File.ReadAllText(EndingEvent.Instance.path + "/Resources/MaterialData.json");


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
