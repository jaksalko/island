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


public class XMLManager : SingleTon<XMLManager>
{
    public GameObject pop;
    public class Tool
    {

        [XmlElement("이름")]
        public string Name = "";

        [XmlElement("단계")]
        public int Grade = 0;

        [XmlElement("갯수")]
        public int Count = 0;




    }

    [XmlRoot("ToolInfo")]
    public class ToolInfo
    {

        [XmlIgnore]
        List<Tool> Tlist = null;

        [XmlElement("Tool")]
        public Tool[] ToolList
        {
            get
            {
                return Tlist.ToArray();
            }
            set
            {
                Tlist = new List<Tool>(value);
            }
        }

    }

    public class Material
    {

        [XmlElement("Name")]
        public string Name = "";

        [XmlElement("Count")]
        public int Count = 0;

        [XmlElement("Text")]
        public string Text = "";


    }

    [XmlRoot("MaterialInfo")]
    public class MaterialInfo
    {

        [XmlIgnore]
        List<Material> list = null;

        [XmlElement("Material")]
        public Material[] MaterialList
        {
            get
            {
                return list.ToArray();
            }
            set
            {
                list = new List<Material>(value);
            }
        }

    }

    void Oncreate()
    {
        Load();
    }

    bool isPaused;
    public MaterialInfo mData;
    public ToolInfo TData;
    int i = 0;
    public TextMeshProUGUI Test;

    public void Awake()
    {
        Load();

        Application.runInBackground = true;
        isPaused = false;



    }

    void Update()
    {
        
        
        
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
           
            Save();
            isPaused = true;
            
        }

        else
        {
            if (isPaused)
            {
                isPaused = false;
                /* 앱이 활성화 되었을 때 처리 */
                Load();
            }
        }
    }

    public void Load()//불러오기
    {


        TextAsset textAsset = Resources.Load("MaterialInventory") as TextAsset;

        TextAsset TtextAsset = Resources.Load("ToolInventory") as TextAsset;
        print(textAsset.text);

        XmlSerializer ser = new XmlSerializer(typeof(MaterialInfo));

        XmlSerializer Tser = new XmlSerializer(typeof(ToolInfo));

        mData = ser.Deserialize(new StringReader(textAsset.text)) as MaterialInfo;

        TData = Tser.Deserialize(new StringReader(TtextAsset.text)) as ToolInfo;

        foreach (Material mat in mData.MaterialList)
        {
            Debug.Log("name :" + mat.Name);
            Debug.Log("Count :" + mat.Count);
            Debug.Log("Text :" + mat.Text);
        }
        foreach (Tool too in TData.ToolList)
        {
            Debug.Log("이름 :" + too.Name);
            Debug.Log("Grade :" + too.Grade);
            Debug.Log("Count :" + too.Count);

        }
    }

    void Save() // 수정
    {
        List<Material> list = new List<Material>();
        for (int i = 0; i < mData.MaterialList.Length; i++)
        {



            Material m = new Material();
            m.Name = mData.MaterialList[i].Name;
            m.Count = mData.MaterialList[i].Count;
            m.Text = mData.MaterialList[i].Text;
            list.Add(m);
        }

        MaterialInfo minfo = new MaterialInfo();
        minfo.MaterialList = list.ToArray();

        XmlSerializer ser = new XmlSerializer(typeof(MaterialInfo));

        TextWriter textWriter = new StreamWriter("./Assets/Resources/MaterialInventory.xml");

        ser.Serialize(textWriter, minfo);

    }

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
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "FoodInventory", string.Empty);
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


        XmlDocument xmlDoc = new XmlDocument();
        string filepath = Application.dataPath.ToString() + "/Resources/FoodInventory.xml";
        xmlDoc.Load(filepath);
        XmlElement elmRoot = xmlDoc.DocumentElement;

        //string data;
        //복호화
        //data = Decrypt(elmRoot.InnerText);
        //elmRoot.InnerXml = data;
        //xmlDoc.Save(filepath);

        XmlNodeList child = xmlDoc.SelectNodes("FoodInventory/Food");





        Debug.Log(child[0].SelectSingleNode("고래등1").InnerText);

        Debug.Log(child[0].SelectSingleNode("고래등2").InnerText);

        Debug.Log(child[0].SelectSingleNode("고래등3").InnerText);

        Debug.Log(child[0].SelectSingleNode("고래등성공엔딩").InnerText);




        //암호화
        //data = encryData(elmRoot.InnerXml);
        //elmRoot.RemoveAll();
        //elmRoot.InnerText = data;
        //xmlDoc.Save(filepath);
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
    }

}
