using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenTextScript : MonoBehaviour
{
    public GameObject text;

    public void SpawnText()
    {
        Instantiate(text, gameObject.transform);
    }
}
