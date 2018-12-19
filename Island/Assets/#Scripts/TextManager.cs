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

public class TextManager : MonoBehaviour {
    public TextMeshProUGUI[] MaterialCountText;

    void Awake()
    {
        
    }
    void OnCreate ()
    {
        for (int i = 0; i < MaterialCountText.Length; i++)
        {
            MaterialCountText[i].text = XMLManager.Instance.mData.MaterialList[i].Count.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
