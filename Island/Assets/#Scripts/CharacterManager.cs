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
public class CharacterManager : SingleTon<CharacterManager>
{
    public class Character
    {

        [XmlElement("Name")]
        public string Name = "";

        [XmlElement("MainStat")]
        public int MStat = 0;

        [XmlElement("SubStat")]
        public int Sstat = 0;

        [XmlElement("EtcStat")]
        public int Estat = 0;

        [XmlElement("Form")]
        public string Form = "";



    }

    [XmlRoot("CharacterInfo")]
    public class CharacterInfo
    {

        [XmlIgnore]
        List<Character> Clist = null;

        [XmlElement("Character")]
        public Character[] CharacterList
        {
            get
            {
                return Clist.ToArray();
            }
            set
            {
                Clist = new List<Character>(value);
            }
        }

    }

    public CharacterInfo CData;

    // Use this for initialization
    void Awake ()
    {
        Load();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Load()//불러오기
    {


        TextAsset textAsset = Resources.Load("Character") as TextAsset;

        

        XmlSerializer ser = new XmlSerializer(typeof(CharacterInfo));

       

        CData = ser.Deserialize(new StringReader(textAsset.text)) as CharacterInfo;

       


    }

    public void Save() // 수정
    {
        List<Character> list = new List<Character>();
       

        for (int i = 0; i < CData.CharacterList.Length; i++)
        {



            Character c = new Character();
            
            list.Add(c);


        }



        CharacterInfo cinfo = new CharacterInfo();
        

        cinfo.CharacterList = list.ToArray();
       

        XmlSerializer ser = new XmlSerializer(typeof(CharacterInfo));
       

        TextWriter textWriter = new StreamWriter("./Assets/Resources/Character.xml");
        
        ser.Serialize(textWriter, cinfo);
        
    }

}
