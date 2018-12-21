using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainButtonManager : MonoBehaviour {
    public Button[] peopleicon;
    public Button[] people;
    public Button[] icon;
    public GameObject manufactPopup;
    public GameObject invenPopup;
    public GameObject[] statPopup;
    public GameObject workPopup;
    public GameObject tradePopup;

    public void PeopleiconClick(Button button)
    {
        if ((statPopup[0].activeSelf == false&& statPopup[1].activeSelf == false&& statPopup[2].activeSelf == false))
        {
            switch (button.ToString())
            {
                case ("StatButton1 (UnityEngine.UI.Button)"):
                    statPopup[0].SetActive(true);
                    break;
                case ("StatButton2 (UnityEngine.UI.Button)"):
                    statPopup[1].SetActive(true);
                    break;
                case ("StatButton3 (UnityEngine.UI.Button)"):
                    
                    statPopup[2].SetActive(true);
                    break;
            }
           
        }
        else if (statPopup[0].activeSelf == true)
        {
            statPopup[0].SetActive(false);
            switch (button.ToString())
            {
                case ("StatButton1 (UnityEngine.UI.Button)"):
                   
                    break;
                case ("StatButton2 (UnityEngine.UI.Button)"):
                    statPopup[1].SetActive(true);
                    break;
                case ("StatButton3 (UnityEngine.UI.Button)"):
                    statPopup[2].SetActive(true);
                    break;
            }
        }
        else if (statPopup[1].activeSelf == true)
        {
            
            statPopup[1].SetActive(false);
            switch (button.ToString())
            {
                case ("StatButton1 (UnityEngine.UI.Button)"):
                    statPopup[0].SetActive(true);
                    break;
                case ("StatButton2 (UnityEngine.UI.Button)"):
                    
                    break;
                case ("StatButton3 (UnityEngine.UI.Button)"):
                    statPopup[2].SetActive(true);
                    break;
            }
        }
        else if (statPopup[2].activeSelf == true)
        {
            statPopup[2].SetActive(false);
            switch (button.ToString())
            {
                case ("StatButton1 (UnityEngine.UI.Button)"):
                    statPopup[0].SetActive(true);
                    break;
                case ("StatButton2 (UnityEngine.UI.Button)"):
                    statPopup[1].SetActive(true);
                    break;
                case ("StatButton3 (UnityEngine.UI.Button)"):
                    
                    break;
            }
        }

        /*if (statPopup[0].active == false)
        {
            switch (button.ToString())
            {
                case ("StatButton1 (UnityEngine.UI.Button)"):
                    statPopup[0].SetActive(true);
                    break;
                case ("StatButton2 (UnityEngine.UI.Button)"):
                    statPopup.SetActive(true);
                    break;
                case ("StatButton3 (UnityEngine.UI.Button)"):
                    statPopup.SetActive(true);
                    break;
            }
        }
        else
        {
            switch (button.ToString())
            {
                case ("StatButton1 (UnityEngine.UI.Button)"):
                    statPopup.SetActive(false);
                    break;
                case ("StatButton2 (UnityEngine.UI.Button)"):
                    statPopup.SetActive(false);
                    break;
                case ("StatButton3 (UnityEngine.UI.Button)"):
                    statPopup.SetActive(false);
                    break;
            }
        }*/
    }
    public void PeopleClick(Button button)
    {
        Debug.Log(button.ToString());
        
        switch (button.ToString())
        {
            case ("People1 (UnityEngine.UI.Button)"):
                workPopup.SetActive(true);
                break;
            case ("People2 (UnityEngine.UI.Button)"):
                workPopup.SetActive(true);
                break;
            case ("People3 (UnityEngine.UI.Button)"):
                workPopup.SetActive(true);
                break;
        }

    }
    public void IconClick(Button button)
    {
        switch (button.ToString())
        {
            case ("MissionButton (UnityEngine.UI.Button)"):
                
                break;
            case ("TradeButton (UnityEngine.UI.Button)"):
                tradePopup.SetActive(true);
                break;
            case ("MenuButton (UnityEngine.UI.Button)"):
               
                break;
            case ("InvenButton (UnityEngine.UI.Button)"):
                invenPopup.SetActive(true);
                break;
            case ("ItemButton (UnityEngine.UI.Button)"):
                manufactPopup.SetActive(true);
                break;
        }
    }

}
