using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class MyCharacter
{

    public int Hungry;
    public int Thirsty;
    public int Ill;
    public string Condition;

    public MyCharacter(int hungry, int thirsty, int ill,string condition)
    {
        Hungry = hungry;
        Thirsty = thirsty;
        Ill = ill;
        Condition = condition;
    }

}

public class Character
{

    public int Name;
    public int MainStat;
    public int SubStat;
    public int EtcStat;
    public string Form;

    public Character(int name, int mainstat, int substat, int etcstat, string form)
    {
        Name = name;
        MainStat = mainstat;
        SubStat = substat;
        EtcStat = etcstat;
        Form = form;
    }

}

public class CharacterData : SingleTon<CharacterData>
{
    public List<int> MyCharacter = new List<int>();
    //다른 스크립트에서 캐릭터 3개를 뽑으면 그의 Name번호를 저장해놓는다.
    public List<Character> AllCharacter = new List<Character>();
    public List<MyCharacter> MyCharacterList = new List<MyCharacter>();
    Character ch;
    MyCharacter mch;



    int main, sub, etc, name;
    string form;

    int hungry, thirsty, ill;
    string condition;

    void Start()
    {
        StartCoroutine(MyCharacterSave());
    }

    IEnumerator MyCharacterSave()//캐릭터 선택창 후에 내 캐릭터 정보 저장
    {
        //    for (int i = 0; i < CharacterManager.Instance.CData.CharacterList.Length; i++)
        //    {
        //        form = CharacterManager.Instance.CData.CharacterList[i].Form;
        //        name = int.Parse(CharacterManager.Instance.CData.CharacterList[i].Name);
        //        main = CharacterManager.Instance.CData.CharacterList[i].MStat);
        //    sub = CharacterManager.Instance.CData.CharacterList[i].Sstat;
        //    etc = CharacterManager.Instance.CData.CharacterList[i].Estat;

        //}
        for (int i = 0; i < 3; i++)//맨처음 시작시 초기화
        {
            hungry = 50;
           thirsty = 50;
            ill = 0;
            condition = "normal";
            

            mch = new MyCharacter(hungry,thirsty,ill,condition);

            MyCharacterList.Add(mch);
        }








        JsonData CharacterJson = JsonMapper.ToJson(MyCharacterList);

        File.WriteAllText(Application.dataPath + "/Resources/MyCharacterData.json", CharacterJson.ToString());

        yield return null;

    }

    IEnumerator CharacterSave()
    {
        //    for (int i = 0; i < CharacterManager.Instance.CData.CharacterList.Length; i++)
        //    {
        //        form = CharacterManager.Instance.CData.CharacterList[i].Form;
        //        name = int.Parse(CharacterManager.Instance.CData.CharacterList[i].Name);
        //        main = CharacterManager.Instance.CData.CharacterList[i].MStat);
        //    sub = CharacterManager.Instance.CData.CharacterList[i].Sstat;
        //    etc = CharacterManager.Instance.CData.CharacterList[i].Estat;

        //}
        for (int i = 0; i < CharacterManager.Instance.CData.CharacterList.Length; i++)
        {
            form = CharacterManager.Instance.CData.CharacterList[i].Form;
            name = int.Parse(CharacterManager.Instance.CData.CharacterList[i].Name);
            main = CharacterManager.Instance.CData.CharacterList[i].MStat;
            sub = CharacterManager.Instance.CData.CharacterList[i].Sstat;
            etc = CharacterManager.Instance.CData.CharacterList[i].Estat;
            ch = new Character(name, main, sub, etc, form);

            AllCharacter.Add(ch);
        }




    

    

    JsonData CharacterJson = JsonMapper.ToJson(AllCharacter);

    File.WriteAllText(Application.dataPath + "/Resources/CharacterData.json", CharacterJson.ToString());

       yield return null;
        
    }
// Update is called once per frame

IEnumerator CharacterLoad()
{

    string ToolString = File.ReadAllText(Application.dataPath + "/Resources/CharacterData.json");

    Debug.Log(ToolString); // 첫 줄 출력

    //JsonData itemData = JsonMapper.ToObject(ToolString);
    //태그로 정렬 가능?



    yield return null;

}

    IEnumerator MyCharacterLoad()
    {

        string ToolString = File.ReadAllText(Application.dataPath + "/Resources/MyCharacterData.json");

        Debug.Log(ToolString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(ToolString);
        //태그로 정렬 가능?

        ParsingMyCharacter(itemData);

        yield return null;

    }

    private void ParsingMyCharacter(JsonData Data)
    {

        MyCharacter mch;
        for (int i = 0; i < Data.Count; i++)
        {


            //text = Data[i]["Text"].ToString();
            //Debug.Log(Data[i]["Text"]);

            //name = Data[i]["Name"].ToString();
            //Debug.Log(Data[i]["Name"]);
            //count = int.Parse(Data[i]["Count"].ToString());

            mch = new MyCharacter(int.Parse(Data[i]["Hungry"].ToString()),
                int.Parse(Data[i]["Thirsty"].ToString()),
                int.Parse(Data[i]["Ill"].ToString()),
                Data[i]["Condition"].ToString());

            MyCharacterList.Add(mch);




        }

    }
}

