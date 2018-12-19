using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorkPopupManager : MonoBehaviour {
    public Button exitButton;
    public Button[] workButton;
    public GameObject workPopup;
    public GameObject charImage;
    // Use this for initialization

    public void ExitButton()
    {
        workPopup.SetActive(false);
    }
}
