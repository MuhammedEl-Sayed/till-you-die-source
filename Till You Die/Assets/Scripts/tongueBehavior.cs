using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tongueBehavior : MonoBehaviour
{
    GameObject player;
    public SpringJoint2D rope;
    public LineRenderer render;
    public float tongueLength = 8f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        render = gameObject.GetComponent<LineRenderer>();
    }

    // Runs on time dependecy, instead of each fram, this excute every 0.02 sec
    private void FixedUpdate()
    {
        //use pythagorean therom to find the distance between player and tongue object
        float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(gameObject.transform.position.x - player.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(gameObject.transform.position.y - player.transform.position.y), 2));
        if(distance >= 10)
        {
            Debug.Log("Destroy Due To length Limit");
            Destroy(gameObject);
        }
    }
    //create lineRender
    private void LateUpdate()
    {
        render.enabled = true;
        render.positionCount = 2;
        render.SetPosition(0, player.transform.position);
        render.SetPosition(1, gameObject.transform.position);
    }

    //if collide with enviroment, spawn tongue (springJoint2D)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "FlatWorm" && collision.gameObject.tag != "Beetle")
        {
            fire(tongueLength);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "FlatWorm")
        {
            Debug.Log("Collide with enemy");
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Beetle")
        {
            Debug.Log("Collide with Beetle");
            Destroy(gameObject);
        }
    }

    //This Fires the tongue
    void fire(float distance)
    {
        SpringJoint2D newRope = player.AddComponent<SpringJoint2D>();
        newRope.enableCollision = false;
        newRope.frequency = 3;
        newRope.dampingRatio = 0.5f;
        newRope.connectedAnchor = gameObject.transform.position;
        newRope.enableCollision = true;
        newRope.distance = distance;
        newRope.enabled = true;
        rope = newRope;
    }
}
