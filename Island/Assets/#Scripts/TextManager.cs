using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using TMPro;

public class TextManager : MonoBehaviour
{
    
    public TextMeshProUGUI[] FoodCountText;



    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 12; i++)
        {
            FoodCountText[i].text = FoodData.Instance.FoodList[i].Count.ToString();
        }
        
        
    }
}
