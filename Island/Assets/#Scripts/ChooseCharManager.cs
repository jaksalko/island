using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine;
using UnityEngine.UI;
public class ChooseCharManager : MonoBehaviour {
    private int charnum = 0;
    public Button[] charButton;
    public List<Button> selectedChar = new List<Button>();
    public GameObject[] selectedCharImage;
    public GameObject selectPopup;
    public Button ok;
    public Button no;
    public GameObject popupCharImage;
    private string str;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CharClicked() {
        str = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(charnum);
        //selectedChar.Add(new Button )
        selectPopup.SetActive(true);
        popupCharImage.GetComponent<Image>().sprite = GameObject.Find(str).GetComponent<Image>().sprite;


    }

    public void CharCancelClicked() {
        string str = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(str);
        str = str.Replace("Char", "");
        int deletenum = Convert.ToInt32(str);
        //selectedChar.RemoveAt(deletenum);
        for (int k = deletenum; k < (charnum-1); k++) {
            selectedCharImage[k].GetComponent<Image>().sprite = selectedCharImage[k + 1].GetComponent<Image>().sprite;
            Debug.Log("changeImage" + k + "<-" + (k + 1));
        }
            

        selectedChar[charnum-1].gameObject.SetActive(false);
        if (charnum > 0)
        charnum--;
        Debug.Log(selectedChar.Count);
    }

    public void OkButtonClicked(){
        if (selectedChar[charnum].isActiveAndEnabled == false && charnum < 4)
        {
            selectedChar[charnum].gameObject.SetActive(true);
            selectedCharImage[charnum].GetComponent<Image>().sprite = GameObject.Find(str).GetComponent<Image>().sprite;
            if (charnum < 4)
                charnum++;

            Debug.Log("charnum : " + charnum);
        }   //tool_icon1.overrideSprite = GameObject.Find(str).GetComponent<Image>().sprite;
        selectPopup.SetActive(false);
    }
    public void NoButtonClicked() {
        selectPopup.SetActive(false);
    }
}
