using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InvenPopupManager : MonoBehaviour {
    public GameObject invenPopup;
    public GameObject matPop;
    public GameObject toolPop;
    public GameObject cookPop;
    public Button exitbutton1;
    public Button exitbutton2;
    public Button exitbutton3;

    // Use this for initialization
    public void ExitButtonClick() {
        invenPopup.SetActive(false);
    }
    public void MatClick() {
        toolPop.SetActive(false);
        matPop.SetActive(true);
        cookPop.SetActive(false);
    }
    public void ToolClick()
    {
        toolPop.SetActive(true);
        matPop.SetActive(false);
        cookPop.SetActive(false);
    }
    public void CookClick()
    {
        cookPop.SetActive(true);
        toolPop.SetActive(false);
        matPop.SetActive(false);
    }
}
