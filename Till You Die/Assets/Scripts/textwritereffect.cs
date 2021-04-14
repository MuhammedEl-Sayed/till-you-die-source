using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textwritereffect : MonoBehaviour
{
	Text txt;
	string story;
	public GameObject buttons;
	void Awake()
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.125f);
		}
		buttons.SetActive(true);
	}

}
