using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;
using System;

public class ItemParse : MonoBehaviour
{

//    public class Tool
//{

//    [XmlElement("이름")]
//    public string Name = "";

//    [XmlElement("단계")]
//    public int Grade = 0;

//    [XmlElement("갯수")]
//    public int Count = 0;




//}

//[XmlRoot("ToolInfo")]
//    public class ToolInfo
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

//    public class Material
//{

//    [XmlElement("Name")]
//    public string Name = "";

//    [XmlElement("Count")]
//    public int Count = 0;

//    [XmlElement("Text")]
//    public string Text = "";


//}

//[XmlRoot("MaterialInfo")]
//    public class MaterialInfo
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


    //protected static T instance = null;

    //public static T Instance
    //{
    //    get
    //    {
    //        instance = FindObjectOfType(typeof(T)) as T;
            
    //        if (instance == null)
    //        {
    //            instance = new GameObject("@" + typeof(T).ToString(),
    //                                       typeof(T)).GetComponent<T>();
    //            DontDestroyOnLoad(instance);
    //        }
    //        return instance;
    //    }
    //}

    //public MaterialInfo mData;
    //public ToolInfo TData;
    //int i = 0;

    void Start()
    {
      //NewBehaviourScript.Instance.
    }

    //void Load()//불러오기
    //{
       

    //    TextAsset textAsset = Resources.Load("MaterialInventory") as TextAsset;

    //    TextAsset TtextAsset = Resources.Load("ToolInventory") as TextAsset;
    //    print(textAsset.text);

    //    XmlSerializer ser = new XmlSerializer(typeof(MaterialInfo));

    //    XmlSerializer Tser = new XmlSerializer(typeof(ToolInfo));

    //    mData = ser.Deserialize(new StringReader(textAsset.text)) as MaterialInfo;

    //    TData = Tser.Deserialize(new StringReader(TtextAsset.text)) as ToolInfo;

    //    foreach (Material mat in mData.MaterialList)
    //    {
    //        Debug.Log("name :" + mat.Name);
    //        Debug.Log("Count :" + mat.Count);
    //        Debug.Log("Text :" + mat.Text);
    //    }
    //    foreach (Tool too in TData.ToolList)
    //    {
    //        Debug.Log("이름 :" + too.Name);
    //        Debug.Log("Grade :" + too.Grade);
    //        Debug.Log("Count :" + too.Count);

    //    }
    //}

    //void Save() // 수정
    //{
    //    List<Material> list = new List<Material>();
    //    for(int i=0;i< mData.MaterialList.Length;i++)
    //    {



    //        Material m = new Material();
    //        m.Name = mData.MaterialList[i].Name;
    //        m.Count = 1;
    //        m.Text = mData.MaterialList[i].Text;
    //        list.Add(m);
    //    }

    //    MaterialInfo minfo = new MaterialInfo();
    //    minfo.MaterialList = list.ToArray();

    //    XmlSerializer ser = new XmlSerializer(typeof(MaterialInfo));

    //    TextWriter textWriter = new StreamWriter("./Assets/Resources/MaterialInventory.xml");

    //    ser.Serialize(textWriter, minfo);

    //}



    void Update()
    {
        
        //if (i == 0)
        //{
        //    Debug.Log(mData.MaterialList[0].Name);
        //    i++;
        //}
    }
}