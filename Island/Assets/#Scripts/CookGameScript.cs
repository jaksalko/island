using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookGameScript : MonoBehaviour
{
    public GameObject sugar, salt, fire, back;
    public List<GameObject> ans; 
    public GameObject ResultPopUp;
    public int step;
    public GameObject go;
    public GameObject temp;
    public Vector3 goPosition;
    public bool success,fail;
    int j;
    // Use this for initialization
    void Start () {
        Timer.Instance.StartTimer(15);
        step = 0;
        make();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Timer.Instance.Time == 0)
        {
            ResultPopUp.SetActive(true);
        }

        if (success == true)
        {
            step++;
            success = false;
            make();
        }
        if (fail == true)
        {
            
            while(ans.Count>0)
            { 
                Destroy(ans[0]);
                ans.RemoveAt(0);
                Debug.Log("제거");
            }
            fail = false;
            make();
        }

        

    }

    public void RandomMake()
    {
        go = new GameObject();
        go.AddComponent<Image>();

        switch (Random.Range(0, 4))
        {
            case 0:
                {
                    go.GetComponent < Image >().color = Color.black;
                    go.tag = "sugar";
                    go.name = "sugar";
                    go.transform.localPosition = goPosition;
                    go.transform.SetParent(GameObject.FindGameObjectWithTag("ansList").transform, false);
                    ans.Add(go);

                    break;
                }
            case 1:
                {

                    go.GetComponent<Image>().color = Color.white;
                    go.tag = "salt";
                    go.name = "salt";
                    go.transform.localPosition = goPosition;
                    go.transform.SetParent(GameObject.FindGameObjectWithTag("ansList").transform, false);
                    ans.Add(go);
                    break;
                }
            case 2:
                {
                    go.GetComponent<Image>().color = Color.blue;
                    go.tag = "fire";
                    go.name = "fire";
                    go.transform.localPosition = goPosition;
                    go.transform.SetParent(GameObject.FindGameObjectWithTag("ansList").transform, false);
                    ans.Add(go);
                    break;
                }
            case 3:
                {
                    go.GetComponent<Image>().color = Color.green;
                    go.tag = "back";
                    go.name = "back";
                    go.transform.localPosition = goPosition;
                    go.transform.SetParent(GameObject.FindGameObjectWithTag("ansList").transform, false);
                    ans.Add(go);
                    break;
                }
        }
    }

    public void make()
    {
       
            switch (step)
            {
                case 0:
                    {
                        goPosition = new Vector3(-540f, 0, 0);

                        j = 2;
                        //ans 2개 생성
                        for (int i = 0; i < j; i++)
                        {
                            goPosition += new Vector3(110f, 0, 0);
                            RandomMake();
                            
                        }
                        break;
                    }
                case 1:
                    {
                        goPosition = new Vector3(-540f, 0, 0);
                        j = 4;
                        //ans 4개 생성
                        for (int i = 0; i < j; i++)
                        {
                            goPosition += new Vector3(110f, 0, 0);
                            RandomMake();
                        }
                        break;
                    }
                case 2:
                    {
                        goPosition = new Vector3(-540f, 0, 0);
                        j = 6;
                        //ans 6개 생성
                        for (int i = 0; i < j; i++)
                        {
                            goPosition += new Vector3(110f, 0, 0);
                            RandomMake();
                        }
                        break;
                    }
                case 3:
                    {
                        goPosition = new Vector3(-540f, 0, 0);
                        j = 8;
                        //ans 8개 생성 
                        for (int i = 0; i < j; i++)
                        {
                            goPosition += new Vector3(110f, 0, 0);
                            RandomMake();
                        }
                        break;
                    }
                case 4:
                    {
                        goPosition = new Vector3(-540f, 0, 0);
                        j = 10;
                        //ans 10개 생성
                        for (int i = 0; i < j; i++)
                        {
                            goPosition += new Vector3(110f, 0, 0);
                            RandomMake();
                        }
                        break;
                    }

            }
        
    }

    public void click(Button bu)
    {

        switch (bu.ToString())
        {

            case "sugar (UnityEngine.UI.Button)":
                {
                    if (ans[0].tag == "sugar")
                    {
                        temp = ans[0];
                        Destroy(temp);
                        ans.RemoveAt(0);

                        Debug.Log("맞춤");
                        if (ans.Count == 0)
                        {
                            success = true;

                            Debug.Log("성공");
                        }
                    }
                    else
                    {
                        Debug.Log("실패");
                        fail = true;
                    }

                    break;
                }
            case "salt (UnityEngine.UI.Button)":
                {
                    if (ans[0].tag == "salt")
                    {
                        temp = ans[0];
                        Destroy(temp);
                        ans.RemoveAt(0);
                        Debug.Log("맞춤");
                        if (ans.Count == 0)
                        {
                            success = true;

                            Debug.Log("성공");
                        }
                    }
                    else
                    {
                        Debug.Log("실패");
                        fail = true;
                    }

                    break;
                }
            case "fire (UnityEngine.UI.Button)":
                {
                    if (ans[0].tag == "fire")
                    {
                        temp = ans[0];
                        Destroy(temp);
                        ans.RemoveAt(0);
                        Debug.Log("맞춤");
                        if (ans.Count == 0)
                        {
                            success = true;

                            Debug.Log("성공");
                            
                        }
                    }
                    else
                    {
                        Debug.Log("실패");
                        fail = true;
                    }

                    break;
                }
            case "back (UnityEngine.UI.Button)":
                {
                    if (ans[0].tag == "back")
                    {
                        temp = ans[0];
                        Destroy(temp);
                        ans.RemoveAt(0);
                        Debug.Log("맞춤");
                        if (ans.Count == 0)
                        {
                            success = true;

                            Debug.Log("성공");
                        }
                    }
                    else
                    {
                        Debug.Log("실패");
                        fail = true;
                    }

                    break;
                }

        }

        

        

    }
    public void OkButtonClicked()
    {
        AutoFade.LoadLevel("MainScene 3", 1, 1, Color.black);
    }

}
