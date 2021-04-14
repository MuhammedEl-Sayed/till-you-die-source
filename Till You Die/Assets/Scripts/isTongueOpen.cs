using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTongueOpen : MonoBehaviour
{
    GameObject Tongue;
    GameObject player;
    LineRenderer playerLine;

    private bool TongueOpen = false;
    public static bool four = false;
    private bool flip = false;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLine = player.GetComponent<LineRenderer>();
    }
     void Update()
    {
        if (four) flip = true;
        else flip = false;
    }
    public void FixedUpdate()
    {
        if (DamageBehavior.freeze)
        {
            four = true;
            
        }
        Tongue = GameObject.FindGameObjectWithTag("tongue");
        if(Tongue != null || playerLine.enabled == true)
        {
            if (flip)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaa");
                player.GetComponent<Animator>().SetBool("fOpenMouth", true);
            }
            else
            {
                player.GetComponent<Animator>().SetBool("openMouth", true);
               
            }
            
            TongueOpen = true;
            Debug.Log("The Tongue is Now Open");
            Debug.Log("is Open? : " + TongueOpen.ToString());
        }

        if(playerLine.enabled == false)
        {
                 if (flip)
            {
                player.GetComponent<Animator>().SetBool("fOpenMouth", false);
            }
            else
            {
                player.GetComponent<Animator>().SetBool("openMouth", false);
            }
            TongueOpen = false;
            Debug.Log("The Tongue is Now Close");
            Debug.Log("is Open? : " + TongueOpen.ToString());
        }
    }

   public void ResetTongue()
    {
       
        four = false;
    }

    public bool getCondition()
    {
        return TongueOpen;
    }
}
