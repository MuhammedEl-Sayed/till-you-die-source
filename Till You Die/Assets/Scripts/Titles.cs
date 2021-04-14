using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Titles : MonoBehaviour
{
    // Start is called before the first frame update
    public void playEvent()
    {
        SceneManager.LoadScene(1);
    }
    public void quitEvent()
    {
        Application.Quit();
    }
}
