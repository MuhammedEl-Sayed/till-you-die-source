using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coolDownTimer : MonoBehaviour
{
    private float intendedTime = 10f;
    private SpringJoint2D playerTongue;
    [SerializeField]
    public Text txt;
    private bool isTongueUsed = false;
    private int usedOnece = 0;
    private void Start()
    {
        txt.text = "TongueCoolDown: " + intendedTime;

    }
    private void Update()
    {
        playerTongue = gameObject.GetComponent<SpringJoint2D>();
        if (playerTongue != null && usedOnece == 0)
        {
            isTongueUsed = true;
            usedOnece = 1;
        }
        if(isTongueUsed == true)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<getMousePosition>().PlayerInput(false);
            intendedTime -= Time.deltaTime;
            txt.text = "TongueCoolDown: " + Mathf.Round(intendedTime);
            Debug.Log("CountDown Started, Current Time until zero is: " + intendedTime);
        }

        if (isTongueUsed == true && intendedTime <= 0f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<getMousePosition>().PlayerInput(true);
            intendedTime = 10f;
            txt.text = "TongueCoolDown: " + Mathf.Round(intendedTime);
            isTongueUsed = false;
            Debug.Log("TimerReset");
        }
    }

    public void resetuse()
    {
        usedOnece = 0;
    }
}
