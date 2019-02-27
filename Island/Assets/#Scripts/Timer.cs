using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Timer : SingleTon<Timer> {

    public int Time;
    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
       
    }

    public void StartTimer(int t)
    {
        if (Time != t)
        {
            
            Time = t;
        }
        StartCoroutine(WaitTime());


       
        
    }

    IEnumerator WaitTime()
    {
        while (Time >0)
        {
            Debug.Log(Time);
            Time--;
            ClickerGameScript.moveyes = true;
            yield return new WaitForSeconds(1);
        }
        

    }
	// Update is called once per frame
	void Update () {
		
	}
}
