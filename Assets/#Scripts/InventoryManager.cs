using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Security.Cryptography;
using UnityEngine;
using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;
using System;
using TMPro;

//public class Tool
//{

//    [XmlElement("이름")]
//    public string Name;

//    [XmlElement("등급")]
//    public int Grade;

//    [XmlElement("갯수")]
//    public int Count;


//}

//[XmlRoot("ToolInfo")]
//public class ToolInfo
//{

//    [XmlIgnore]
//    List<Tool> Tlist = null;

//    [XmlElement("Tool")]
//    public Tool[] ToolList
//    {
//        get
//        {
//            return Tlist.ToArray();
//        }
//        set
//        {
//            Tlist = new List<Tool>(value);
//        }
//    }

//}

public class Food
{

    [XmlElement("Name")]
    public string Name;

    [XmlElement("Count")]
    public int Count = 0;

    [XmlElement("Recovery")]
    public int Recovery = 0;




}

[XmlRoot("FoodInfo")]
public class FoodInfo
{

    [XmlIgnore]
    List<Food> Flist = null;

    [XmlElement("Food")]
    public Food[] FoodList
    {
        get
        {
            return Flist.ToArray();
        }
        set
        {
            Flist = new List<Food>(value);
        }
    }

}

//public class Material
//{

//    [XmlElement("Name")]
//    public string Name;

//    [XmlElement("Count")]
//    public int Count;

//    [XmlElement("Text")]
//    public string Text;




//}

//[XmlRoot("MaterialInfo")]
//public class MaterialInfo
//{

//    [XmlIgnore]
//    List<Material> list = null;

//    [XmlElement("Material")]
//    public Material[] MaterialList
//    {
//        get
//        {
//            return list.ToArray();
//        }
//        set
//        {
//            list = new List<Material>(value);
//        }
//    }

//}

public class InventoryManager : SingleTon<InventoryManager>
{
    
   
    bool isPaused;
    //public MaterialInfo mData;
    //public ToolInfo TData;
    public FoodInfo FData;
    int i = 0;
    void Oncreate()
    {
        //inout();
    }



    public void Awake()
    {
       
        Load();
    }


    void Update()
    {
        //mData.MaterialList[0].Count++;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //for (int i = 0; i < mdata.materiallist.length; i++)
        //    //    mdata.materiallist[i].count++;
        //    for (int i = 0; i < FData.MaterialList.Length; i++)
        //        FData.MaterialList[i].Count++;

           
        //    //Load();


        //}



    }

    //void OnApplicationPause(bool pause)
    //{
    //    if (pause)
    //    {
    //        //for (int i = 0; i < mData.MaterialList.Length; i++)
    //        //    mData.MaterialList[i].Count++;
    //        for (int i = 0; i < FData.FoodList.Length; i++)
    //            FData.FoodList[i].Count++;
            
    //        Save();
    //        isPaused = true;
            
    //    }

    //    else
    //    {
    //        if (isPaused)
    //        {
    //            isPaused = false;
    //            /* 앱이 활성화 되었을 때 처리 */
    //            Load();
                
    //        }
    //    }
    //}

    

     void OnApplicationQuit()
    {
        
        Debug.Log("강제종료2");

    }
    public void Load()//불러오기
    {
       
        TextAsset FtextAsset = Resources.Load("FoodInventory") as TextAsset;
        
        
        print(FtextAsset.text);

        
        XmlSerializer Fser = new XmlSerializer(typeof(FoodInfo));
        

        FData = Fser.Deserialize(new StringReader(FtextAsset.text)) as FoodInfo;


    }
    

    
}













/*
void Save()
{
    TextAsset FtextAsset = (TextAsset)Resources.Load("C:/Users/wlgusdn/AppData/LocalLow/com_DBF/Island" + "FoodInventory");

    XmlDocument xmlDoc = new XmlDocument();
    //string filepath = Application.persistentDataPath + "/Resources/FoodInventory.xml";
    //xmlDoc.Load(filepath);
    xmlDoc.LoadXml(FtextAsset.text);

    XmlNodeList foods = xmlDoc.SelectNodes("FoodInfo/Food");

    Debug.Log(foods.Count);
    int i = 0;


    foreach (XmlNode node in foods)
    {
        //Debug.Log(FData.FoodList[i].Count);

        node.SelectSingleNode("Count").InnerText = FData.FoodList[i].Count.ToString();

        i++;
    }
    Debug.Log(foods[0].SelectSingleNode("Count").InnerText);
    //for (int i = 0; i < foods.Count; i++)
    //{
    //    foods[i].SelectSingleNode("Count").InnerText = FData.FoodList[i].Count.ToString();
    //}


    isPaused = true;
    xmlDoc.Save(Application.persistentDataPath + "FoodInventory");
    isPaused = false;
}*/



//public void Save() // 수정
//{
//    //List<Material> list = new List<Material>();
//    //List<Tool> Tlist = new List<Tool>();
//    //List<Food> Flist = new List<Food>();


//    ////for (int i = 0; i < mData.MaterialList.Length; i++)
//    ////{



//    ////    Material m = new Material();
//    ////    m.Name = mData.MaterialList[i].Name;
//    ////    m.Count = mData.MaterialList[i].Count;
//    ////    m.Text = mData.MaterialList[i].Text;
//    ////    list.Add(m);


//    ////}

//    ////for (int i = 0; i < TData.ToolList.Length; i++)
//    ////{
//    ////    Tool t = new Tool();
//    ////    t.Name = TData.ToolList[i].Name;
//    ////    t.Count = TData.ToolList[i].Count;
//    ////    t.Grade = TData.ToolList[i].Grade;

//    ////    Tlist.Add(t);
//    ////}

//    //for (int i = 0; i < FData.FoodList.Length; i++)
//    //{
//    //    Food f = new Food();
//    //    f.Name = FData.FoodList[i].Name;
//    //    f.Count = FData.FoodList[i].Count;
//    //    f.Recovery = FData.FoodList[i].Recovery;
//    //    Flist.Add(f);
//    //}

//    //MaterialInfo minfo = new MaterialInfo();
//    //ToolInfo tinfo = new ToolInfo();
//    //FoodInfo finfo = new FoodInfo();

//    //minfo.MaterialList = list.ToArray();
//    //tinfo.ToolList = Tlist.ToArray();
//    //finfo.FoodList = Flist.ToArray();

//    //XmlSerializer ser = new XmlSerializer(typeof(MaterialInfo));
//    //XmlSerializer Tser = new XmlSerializer(typeof(ToolInfo));
//    //XmlSerializer Fser = new XmlSerializer(typeof(FoodInfo));

//    //TextWriter textWriter = new StreamWriter("./Assets/Resources/MaterialInventory.xml");
//    //TextWriter TtextWriter = new StreamWriter("./Assets/Resources/ToolInventory.xml");
//    //TextWriter FtextWriter = new StreamWriter("./Assets/Resources/FoodInventory.xml");

//    //ser.Serialize(textWriter, minfo);
//    //Tser.Serialize(TtextWriter, tinfo);
//    //Fser.Serialize(FtextWriter, finfo);

//    ////var serializer = new XmlSerializer(typeof(MaterialInfo));
//    ////using (var stream = new StreamWriter(new FileStream("./Assets/Resources/MaterialInventory.xml", FileMode.Create), Encoding.UTF8))
//    ////{
//    ////    serializer.Serialize(stream, this);
//    ////}

//    //XmlDocument xmlDoc = new XmlDocument();
//    //string filepath = Application.dataPath.ToString() + "/Resources/FoodInventory.xml";
//    //xmlDoc.Load(filepath);
//    //XmlElement elmRoot = xmlDoc.DocumentElement;

//    ////string data;
//    ////복호화
//    ////data = Decrypt(elmRoot.InnerText);
//    ////elmRoot.InnerXml = data;
//    ////xmlDoc.Save(filepath);

//    //XmlNodeList child = xmlDoc.SelectNodes("FoodInfo/Food");





//    //Debug.Log(child[0].SelectSingleNode("Name").InnerText);

//}
/*
public static string encryData(string toEncrypt)
{
    byte[] keyArray = UTF8Encoding.UTF8.GetBytes("dotdopdeep");

    byte[] toEmcryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
    RijndaelManaged rDel = new RijndaelManaged();

    rDel.Key = keyArray;
    rDel.Mode = CipherMode.ECB;

    rDel.Padding = PaddingMode.PKCS7;

    ICryptoTransform cTransform = rDel.CreateEncryptor();

    byte[] resultArray = cTransform.TransformFinalBlock(toEmcryptArray, 0, toEmcryptArray.Length);

    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
}

void CreateXml()
{
    XmlDocument xmlDoc = new XmlDocument();

    xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

    //루트 노드 생성
    XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "FoodInfo", string.Empty);
    xmlDoc.AppendChild(root);






    xmlDoc.Save("./Assets/Resources/FoodInventory.xml");

}

public void xmlmod()
{
    TextAsset textAsset = (TextAsset)Resources.Load("Character");


    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(textAsset.text);


    //노드 선택   -> 루트/선택할노드
    XmlNodeList child = xmlDoc.SelectNodes("CharacterInfo/Character");
    XmlNode character = child[0];

    //디버그문 출력
    Debug.Log(character.SelectSingleNode("Name").InnerText);

    //노드의 원소 데이터 변경
    character.SelectSingleNode("Name").InnerText = "wlgusdn9";

    character.SelectSingleNode("Level").InnerText = "10";
    character.SelectSingleNode("Experience").InnerText = "100";

    xmlDoc.Save("./Assets/Resources/CharacterInfo.xml");


}

void inout()
{
    TextAsset FtextAsset = Resources.Load("FoodInventory") as TextAsset;
    //XmlDocument xmlDoc = new XmlDocument();
    //xmlDoc.LoadXml(FtextAsset.text);




    //TextAsset textAsset = Resources.Load("MaterialInventory") as TextAsset;

    //TextAsset TtextAsset = Resources.Load("ToolInventory") as TextAsset;
    //TextAsset FtextAsset = Resources.Load("FoodInventory") as TextAsset;
    print(FtextAsset.text);

    //XmlSerializer ser = new XmlSerializer(typeof(MaterialInfo));

    //XmlSerializer Tser = new XmlSerializer(typeof(ToolInfo));
    XmlSerializer Fser = new XmlSerializer(typeof(FoodInfo));

    //mData = ser.Deserialize(new StringReader(textAsset.text)) as MaterialInfo;

    //TData = Tser.Deserialize(new StringReader(TtextAsset.text)) as ToolInfo;

    FData = Fser.Deserialize(new StringReader(FtextAsset.text)) as FoodInfo;

   // TextAsset FtextAsset = (TextAsset)Resources.Load("FoodInventory");
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(FtextAsset.text);







   // xmlDoc.Save("./Assets/Resources/FoodInventory.xml");


    string filepath = Application.dataPath.ToString() + "/Resources/FoodInventory.xml";
    xmlDoc.Load(filepath);
    XmlElement elmRoot = xmlDoc.DocumentElement;

    string data;
    //복호화

    data = Decrypt(elmRoot.InnerText);
    elmRoot.InnerXml = data;
    xmlDoc.Save(filepath);

    XmlNodeList foods = xmlDoc.SelectNodes("FoodInfo/Food");


    for (int i = 0; i < foods.Count; i++)
    {
        foods[i].SelectSingleNode("Count").InnerText = "0";
        Debug.Log(foods[i].SelectSingleNode("Count").InnerText);
    }







   // 암호화
    data = encryData(elmRoot.InnerXml);
    elmRoot.RemoveAll();
    elmRoot.InnerText = data;
    xmlDoc.Save(filepath);
}

public static string Decrypt(string toDecrypt)
{
    byte[] keyArray = UTF8Encoding.UTF8.GetBytes("dotdopdeep");

    byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

    RijndaelManaged rDel = new RijndaelManaged();
    rDel.Key = keyArray;
    rDel.Mode = CipherMode.ECB;

    rDel.Padding = PaddingMode.PKCS7;

    ICryptoTransform cTransform = rDel.CreateDecryptor();

    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

    return UTF8Encoding.UTF8.GetString(resultArray);
}*/
