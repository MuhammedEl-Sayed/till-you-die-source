using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().loop = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("ground");
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
       // gameObject.GetComponent<ParticleSystem>().Stop();
    }
}
