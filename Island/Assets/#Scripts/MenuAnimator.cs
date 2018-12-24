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
        
        if (state == "triggerOn")
        {
<<<<<<< HEAD
            //Debug.Log(state);
=======
            Debug.Log(state);
>>>>>>> 7a8e8f29f4f2e625dc0a6a8ed2c76f216cc58586
            animator.ResetTrigger("TriggerOff");
            animator.SetTrigger("TriggerOn");
            
        }
        if (state == "triggerOff")
        {
<<<<<<< HEAD
            //Debug.Log(state);
=======
            Debug.Log(state);
>>>>>>> 7a8e8f29f4f2e625dc0a6a8ed2c76f216cc58586
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
