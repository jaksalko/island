using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class ManufactPopupManager : MonoBehaviour {
    public GameObject manufactPopup;
    public Button exitButton;
    public void ExitClick()
    {
        manufactPopup.SetActive(false);
    }
}
