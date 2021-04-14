using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject EndObject;
    Transform parent;
    private void Awake()
    {
        parent = GameObject.FindGameObjectWithTag("Canvas").transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("EndGame");
            Instantiate(EndObject, parent);
        }
    }
}
