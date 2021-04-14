using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource ad;
    private void Awake()
    {
        ad = gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        InvokeRepeating("randomSound", 2f, 5f);
    }

    private void randomSound()
    {
        float rand = Random.Range(0f, 10f);
        if (rand < 4)
        {
            Debug.Log("frog auido played");
            ad.Play();
        }
    }
}
