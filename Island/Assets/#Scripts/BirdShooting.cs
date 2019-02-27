using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BirdShooting : SingleTon<BirdShooting>
{
    private Camera camera;
    public GameObject prefab;
    private GameObject ob;
    private void Start()
    {
        ob = this.gameObject;
        camera = Camera.main;



        
    }

    private void Update()
    {
       

    }

    //public void Shooting()
    //{
        
    //    ob.SetActive(false);
    //    Vector3 vector = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 100);
    //    vector = camera.ScreenToWorldPoint(vector);
        
    //    vector = new Vector3(vector.x * 71.99999424000046f, vector.y * 71.99999424000046f, 100);
        
    //    GameObject shoot = Instantiate(prefab, vector, Quaternion.identity) as GameObject;
    //    HuntingGameScript.Instance.score++;
    //    HuntingGameScript.Instance.scoreTxt.text = HuntingGameScript.Instance.score.ToString();

    //    //Debug.Log(rect.);


    //    shoot.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    //}
}
