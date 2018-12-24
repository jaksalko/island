using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

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
    Character ch;



    int main, sub, etc, name;
    string form;

    void Start()
    {
        StartCoroutine(CharacterSave());
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

IEnumerator ToolLoad()
{

    string ToolString = File.ReadAllText(Application.dataPath + "/Resources//CharacterData.json");

    Debug.Log(ToolString); // 첫 줄 출력

    //JsonData itemData = JsonMapper.ToObject(ToolString);
    //태그로 정렬 가능?



    yield return null;

}
}

