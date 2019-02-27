using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuAnimator : SingleTon<MenuAnimator>{
    Animator animator;
    public Button exitButton;
    public Button setupButton;
    public Button gofirstButton;
    public Button yesExit;
    public Button noExit;
    public string state ="";
    public GameObject exitPopup;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
       
	}
	
	// Update is called once per frame
	void Update () {
        
       

    }
    public void TriggerCheck()
    {
        if (state == "triggerOn")
        {

            Debug.Log(state);

            animator.ResetTrigger("TriggerOff");
            animator.SetTrigger("TriggerOn");

        }
        if (state == "triggerOff")
        {

            Debug.Log(state);

            animator.ResetTrigger("TriggerOn");
            animator.SetTrigger("TriggerOff");
        }
    }

    public void ExitButtonClicked()
    {
        exitPopup.SetActive(true);
    }
    public void NoExit()
    {
        exitPopup.SetActive(false);
    }
    public void YesExit() {
        Application.Quit();
    }
}
