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
    private int DdungeonLv;
    private float _speed;
    // Use this for initialization
    void Start () {

        DdungeonLv = FishDungeonManager.DungeonLv;
        var AreaTransform = CatchArea.transform as RectTransform;
       
        
       
        Debug.Log("Level" + DdungeonLv);

        _speed = 10f;

        switch (DdungeonLv)
        {
            case 1: _speed = 10f;    break;
            case 2: _speed = 20f; CatchArea.transform.localScale -= new Vector3(0.1f, 0, 0); break;
            case 3: _speed = 30f; CatchArea.transform.localScale -= new Vector3(0.1f, 0, 0); break;
            case 4: _speed = 30f; CatchArea.transform.localScale -= new Vector3(0.2f, 0, 0); break;
            case 5: _speed = 40f; CatchArea.transform.localScale -= new Vector3(0.2f, 0, 0); break;
        }

        //Timer.Instance.StartTimer(10);
        CAreaMax = (AreaTransform.sizeDelta.x) / 2;
        CAreaMin = -(AreaTransform.sizeDelta.x) / 2;
    }

    // Update is called once per frame
    void Update()
    {


        if (MovingOb.transform.localPosition.x <= -500)
            LRS = 1;
        else if (MovingOb.transform.localPosition.x >= 500)
            LRS = 2;

      

        if (LRS == 1)
            MovingOb.transform.Translate(_speed * Time.deltaTime, 0, 0);
        else if (LRS == 2)
            MovingOb.transform.Translate(-_speed * Time.deltaTime, 0, 0);


    }

    public void CatchButtonClicked() {
        Debug.Log("Clicked");
       
        if (MovingOb.transform.localPosition.x-75 >= CAreaMin && MovingOb.transform.localPosition.x+75 <= CAreaMax)
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
        MovingOb.transform.localPosition = new Vector3(-550, -310, 0);
        LRS = 1;
    }

    public void OkButtonClicked() {
        AutoFade.LoadLevel("MainScene 3", 1, 1, Color.black);
    }
    
}
