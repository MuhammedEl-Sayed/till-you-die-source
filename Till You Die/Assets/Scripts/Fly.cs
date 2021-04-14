using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.0f;
    public float xPos;
    public float yPos;
    public Vector3 desiredPos;
    public float timer = 0f;
    public float timeToMove = 0.7f;
    float timerSpeed = 1f;
    void Start()
    {
        xPos = Random.Range(-2f, 1f);
        yPos = Random.Range(-.15f, .15f);
        desiredPos = new Vector3(xPos+ transform.position.x, yPos + transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            timer = 0.0f;
        }
    }

    void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        if (timer >= timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
                 if (Vector3.Distance(transform.position, desiredPos) <= 0.01f)
            {
                xPos = Random.Range(-2f, 1f);
                yPos = Random.Range(-.15f, .15f);
                desiredPos = new Vector3(xPos + transform.position.x, yPos + transform.position.y, transform.position.z);
                timer = 0.0f;
            }
        }
    }
}
