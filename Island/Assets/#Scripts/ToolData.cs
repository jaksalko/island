using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Tooll
{





    public int Count;

    public string Name;
    public int Grade;

    public Tooll(int count, string name, int grade)
    {

        Count = count;
        Name = name;
        Grade = grade;
    }

}

public class ToolData : SingleTon<ToolData>
{

    public List<Tooll> ToolList = new List<Tooll>();
    public List<Tooll> ChangeList = new List<Tooll>();
    public Tooll mt;

    string name;
    int grade;
    int count;
    // Use this for initialization
    void Start()
    {

    }

    public void save()
    {
        StartCoroutine(ToolSave());
    }

    public void load()
    {
        StartCoroutine(ToolLoad());
    }

    public void change()
    {
        StartCoroutine(ToolChange());
    }

    private string ToKor(Tooll m)
    {

        JsonData ch1 = JsonMapper.ToJson(m);

        string tmpstring = ch1.ToString();

        string[] tmpcomma = tmpstring.Split(',');



        string[] tmpcolon = tmpcomma[1].Split(':');



        string res = tmpcolon[0] + ":" + "'" + m.Name + "'";



        string ress = tmpcomma[0] + "," + res+tmpcomma[2]+',';

        

        return ress;

    }

    IEnumerator ToolChange()
    {

        string ToolString = File.ReadAllText(Application.dataPath + "/Resources/ToolData.json");

        string sa = "";

        JsonData ch = JsonMapper.ToObject(ToolString);

        Debug.Log(ch.Count);
        for (int i = 0; i < ch.Count; i++)
        {

            name = ch[i]["Name"].ToString();

            count = int.Parse(0.ToString());

            grade = int.Parse(ch[i]["Grade"].ToString());

            mt = new Tooll(count, name, grade);

            sa += ToKor(mt);


            //ChangeList.Add(fd);
        }




        File.WriteAllText(Application.dataPath + "/Resources/ToolData.json", sa.ToString());

        yield return null;

    }

    IEnumerator ToolSave()
    {

        //for (int i = 0; i < InventoryManager.Instance.FData.ToolList.Length; i++)
        //{
        //    grade = InventoryManager.Instance.FData.ToolList[i].Grade;
        //    name = InventoryManager.Instance.FData.ToolList[i].Name;

        //    count = InventoryManager.Instance.FData.ToolList[i].Count;

        //    mt = new Tooll(count, name, grade);

        //    ToolList.Add(mt);

        //}

        JsonData ToolJson = JsonMapper.ToJson(ToolList);

        File.WriteAllText(Application.dataPath + "/Resources/ToolData.json", ToolJson.ToString());

        yield return null;
    }
    // Update is called once per frame

    IEnumerator ToolLoad()
    {

        string ToolString = File.ReadAllText(Application.dataPath + "/Resources/ToolData.json");

        Debug.Log(ToolString); // 첫 줄 출력

        //JsonData itemData = JsonMapper.ToObject(ToolString);
        //태그로 정렬 가능?



        yield return null;

    }
}
