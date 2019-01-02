using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI[] MaterialCountText;
    public TextMeshProUGUI[] FoodCountText;
    public TextMeshProUGUI[] ToolCountText;



    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < MaterialCountText.Length; i++)
        {
            MaterialCountText[i].text = MaterialData.Instance.MaterialList[i].Count.ToString();
        }

        for (int i = 0; i < FoodCountText.Length; i++)
        {
            FoodCountText[i].text = FoodData.Instance.FoodList[i].Count.ToString();
        }
        for (int i = 0; i < ToolCountText.Length; i++)
        {
            ToolCountText[i].text = ToolData.Instance.ToolList[i].Count.ToString();
        }

    }
}
