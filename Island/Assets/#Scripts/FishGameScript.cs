using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FishGameScript : MonoBehaviour {
    public GameObject CatchArea;
    private float CAreaMin;// -width/2
    private float CAreaMax;// +width/2
    private int LRS = 1;// 1 == goright 2 == goleft 0 == stop
    public GameObject MovingOb;
    private int life = 10;
    public GameObject ResultPopup;
    private string dungeonLv;
	// Use this for initialization
	void Start () {
        dungeonLv = FishDungeonManager.dungeonLv;
        var AreaTransform = CatchArea.transform as RectTransform;
       
        CAreaMax = (AreaTransform.sizeDelta.x )/ 2;
        CAreaMin = -(AreaTransform.sizeDelta.x) / 2;
       
        Debug.Log("Level" + dungeonLv);

        
    }

    // Update is called once per frame
    void Update()
    {


        if (MovingOb.transform.localPosition.x <= -640)
            LRS = 1;
        else if (MovingOb.transform.localPosition.x >= 640)
            LRS = 2;

      
        if (LRS == 1)
            MovingOb.transform.Translate(10f * Time.deltaTime, MovingOb.transform.localPosition.y, 0);
        else if (LRS == 2)
            MovingOb.transform.Translate(-10f * Time.deltaTime, MovingOb.transform.localPosition.y, 0);


    }

    public void CatchButtonClicked() {
        Debug.Log("Clicked");
       
        if (MovingOb.transform.localPosition.x >= CAreaMin && MovingOb.transform.localPosition.x <= CAreaMax)
        {
            Debug.Log("Success");
        }
        else { Debug.Log("failed"); }
        life--;
        if (life == 0)
        {
            ResultPopup.SetActive(true);
            //결과창띄우고 메인신으로
        }
        MovingOb.transform.localPosition = new Vector3(-615, 0, 0);
        LRS = 1;
    }

    public void OkButtonClicked() {
        AutoFade.LoadLevel("MainScene 3", 1, 1, Color.black);
    }
    
}
