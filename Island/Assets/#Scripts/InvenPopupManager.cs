using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InvenPopupManager : MonoBehaviour {
    public GameObject invenPopup;
    public GameObject matPop;
    public GameObject toolPop;
    public Button exitbutton1;
    public Button exitbutton2;

    // Use this for initialization
    public void ExitButtonClick() {
        invenPopup.SetActive(false);
    }
    public void MatClick() {
        toolPop.SetActive(false);
        matPop.SetActive(true);
    }
    public void ToolClick()
    {
        toolPop.SetActive(true);
        matPop.SetActive(false);
    }
}
