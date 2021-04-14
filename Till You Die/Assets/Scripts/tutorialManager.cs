using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public GameObject TO1;
    public GameObject TO2;
    public GameObject TXTDISPLAY;

    private void Start()
    {
        StartCoroutine("TutorialRutine");
    }
    IEnumerator TutorialRutine()
    {
        TO1.SetActive(true);
        yield return new WaitForSeconds(10f);
        TXTDISPLAY.SetActive(true);
        TO2.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<getMousePosition>().PlayerInput(true);
        yield return new WaitForSeconds(20f);
    }
}
