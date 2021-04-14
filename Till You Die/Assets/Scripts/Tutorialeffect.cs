using System.Collections;
using UnityEngine;
using TMPro;

public class Tutorialeffect : MonoBehaviour
{
    TextMeshPro text;
    public GameObject img1;
    string textField;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        textField = text.text;
        text.text = "";

        StartCoroutine("PlayeText");

    }

    IEnumerator PlayeText()
    {
        foreach (char c in textField)
        {
            text.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        img1.SetActive(true);
    }

}
