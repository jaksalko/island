using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerGameScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public GameObject ResultPopUp;
    public GameObject PersonImage;

    public int score;
    public int person;
    public static bool moveyes;

	// Use this for initialization
	void Start () {

        Timer.Instance.StartTimer(15);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeText.text = Timer.Instance.Time.ToString();

        if (Timer.Instance.Time == 0)
        {
            ResultPopUp.SetActive(true);
        }

        if (Timer.Instance.Time % 2==0 && moveyes==true)
        {
             PersonImage.transform.localPosition = new Vector3(Random.Range(-240,230), Random.Range(-140, 220), 0f);
            moveyes = false;
                    
        }
           

        if (Input.GetMouseButtonUp(0)&& Timer.Instance.Time>0)
        {
            score++;
                person = score;

            scoreText.text = score.ToString();

        }


       
		
	}
    public void OkButtonClicked()
    {
        PlayerPrefs.SetInt("ClickCount", score);
        AutoFade.LoadLevel("MainScene 3", 1, 1, Color.black);
    }
}
