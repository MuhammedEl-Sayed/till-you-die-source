using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    private bool dirRight = true;
    public float speed = 2.0f;
    private Vector3 pos1;
    private Vector3 pos2;
    public Vector3 posDiff = new Vector3(0f, 0f, 20f);
    private bool flip = false;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = gameObject.transform.localScale;

        pos1 = transform.position;
        pos2 = transform.position + posDiff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<FrogController>().Death());
            Debug.Log("collided");
        }

    }

    void Update()
    {
        if (dirRight)
        {
            if (flip)
            {
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            flip = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else
        {
            if (flip)
            {
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            flip = false;
          
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
           

        if (transform.position.x >= 4.0f)
        {
            Debug.Log("flip");
            dirRight = false;
            flip = true;
        }

        if (transform.position.x <= -4)
        {
            Debug.Log("flip");
            dirRight = true;
            flip = true;
        }
    }

}
