using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Character
{

    public int Name;
    public int Work1,Work2, Work3, Work4, Work5, Work6, Work7, Work8, Work9, Work10;
    public int Form;

    public Character(int name,int work1, int work2, int work3, int work4, int work5
        , int work6, int work7, int work8, int work9, int work10,int form)
    {
        Name = name;
        Work1 = work1;
        Work2 = work2;
        Work3 = work3;
        Work4 = work4;
        Work5 = work5;
        Work6 = work6;
        Work7 = work7;
        Work8 = work8;
        Work9 = work9;
        Work10 = work10;
        Form = form;
    }

}

public class CharacterData : SingleTon<CharacterData>
{
   
    public List<Character> AllCharacter = new List<Character>();
    Character ch;



    int main, sub, etc, name;
    string form;
    string path;
    void Start()
    {

        StartCoroutine(CharacterLoad());
    }

    

    IEnumerator CharacterSave()
    {
        List<Character> TempCharacter = new List<Character>();
        for (int i = 0; i < AllCharacter.Count; i++)
        {
            
            ch = new Character(AllCharacter[i].Name, AllCharacter[i].Work1
                , AllCharacter[i].Work2, AllCharacter[i].Work3
                , AllCharacter[i].Work4, AllCharacter[i].Work5
                , AllCharacter[i].Work6, AllCharacter[i].Work7
                , AllCharacter[i].Work8, AllCharacter[i].Work9, AllCharacter[i].Work10
                , AllCharacter[i].Form);

           TempCharacter.Add(ch);
        }




    

    

    JsonData CharacterJson = JsonMapper.ToJson(TempCharacter);

        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/CharacterData.json", CharacterJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/CharacterData.json", CharacterJson.ToString());

        yield return null;
        
    }
// Update is called once per frame

IEnumerator CharacterLoad()
{

        string CharacterString;

        if (EndingEvent.Instance.path == Application.persistentDataPath)
            CharacterString = File.ReadAllText(Application.persistentDataPath + "/CharacterData.json");
        else
            CharacterString = File.ReadAllText(EndingEvent.Instance.path + "/Resources/CharacterData.json");


        Debug.Log(CharacterString); // 첫 줄 출력

    JsonData itemData = JsonMapper.ToObject(CharacterString);
        //태그로 정렬 가능?



        ParsingCharacter(itemData);

        yield return null;

    }

    private void ParsingCharacter(JsonData Data)
    {
        Character ch;
        for (int i = 0; i < Data.Count; i++)
        {


            //text = Data[i]["Text"].ToString();
            //Debug.Log(Data[i]["Text"]);

            //name = Data[i]["Name"].ToString();
            //Debug.Log(Data[i]["Name"]);
            //count = int.Parse(Data[i]["Count"].ToString());

            ch = new Character(int.Parse(Data[i]["Name"].ToString()), int.Parse(Data[i]["Work1"].ToString())
                , int.Parse(Data[i]["Work2"].ToString()), int.Parse(Data[i]["Work3"].ToString())
                , int.Parse(Data[i]["Work4"].ToString()), int.Parse(Data[i]["Work5"].ToString())
                , int.Parse(Data[i]["Work6"].ToString()), int.Parse(Data[i]["Work7"].ToString())
                , int.Parse(Data[i]["Work8"].ToString()), int.Parse(Data[i]["Work9"].ToString())
                , int.Parse(Data[i]["Work10"].ToString()), int.Parse(Data[i]["Form"].ToString()));

            AllCharacter.Add(ch);




        }
    }
}

