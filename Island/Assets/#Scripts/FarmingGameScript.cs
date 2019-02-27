using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class FarmingGameScript : MonoBehaviour {
    private string buttonNum;
    private int time = 0;
    private int illPosition;
    public Button[] bt;
    private bool[] btState = new bool[20];
    private int score = 0;
    public Animator[] kettle;
    public TextMeshProUGUI scoreTxt;
    Animator animator;
    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            btState[i] = true;
        }

        StartCoroutine(ILL());
        
            
    }
    private void Update()
    {
       

    }
    private void Checkill(int i) {
        if (btState[i] == true)
        {
            bt[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/acreDanger");
            btState[i] = false;
        }
        else {
            illPosition = Random.Range(0, 20);
            Checkill(illPosition);
        }
    }
    IEnumerator ILL()
    {
        while (true)
        {
            
            if (time < 5) {
                illPosition = Random.Range(0, 20);
                Checkill(illPosition);
                Debug.Log(illPosition + btState[illPosition].ToString());
            }
            else if (time < 10) {
                illPosition = Random.Range(0, 20);
                Checkill(illPosition);
                illPosition = Random.Range(0, 20);
                Checkill(illPosition);
            }
            else if (time < 15) {
                illPosition = Random.Range(0, 20);
                Checkill(illPosition);
                illPosition = Random.Range(0, 20);
                Checkill(illPosition);
                illPosition = Random.Range(0, 20);
                Checkill(illPosition);
            }
            else {
              
            }
            time++;
            yield return new WaitForSeconds(1);
        }
    }
    public void ButtonClicked() {
        buttonNum = EventSystem.current.currentSelectedGameObject.name;
        buttonNum = buttonNum.Replace("Button", "");
        

        
        int num = int.Parse(buttonNum.ToString());
        Debug.Log(num);
        if (btState[num - 1] == false)
        {
            Debug.Log("clicked" + (num - 1) + btState[num - 1].ToString());
            kettle[num - 1].SetTrigger("T" + num);
            btState[num - 1] = true;
            bt[num - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Material/acreNormal");
            score++;
            scoreTxt.text = score.ToString();
        }
        else {
            score--;
            scoreTxt.text = score.ToString();
        }
    }
}
