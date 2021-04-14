using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFrog : MonoBehaviour
{
    //Jumping Variables
    Rigidbody2D frogRB;
    float adjustedForce;


    bool jump = false;
    bool runCouroutine = true;
    Vector3 facing;

    public Sprite midJump;
    public Sprite landing;
    public Sprite normal;
    //Ground Detection Variables
    public LayerMask ground;
    public Transform checkPos;
    float height = 3f;


    void Start()
    {
        frogRB = GetComponent<Rigidbody2D>();
        //gameObject.GetComponent<SpriteRenderer>().sprite = midJump;
        
        facing = transform.localScale;

    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, new Vector3(0, -1, 0).normalized);

    }


    void FixedUpdate()
    {

        if (jump)
        {
            height = -height;

            frogRB.velocity = new Vector3(height, adjustedForce, 0);
            Debug.Log(adjustedForce);      
            jump = false;

        }
    }

    void Update()
    {

        if (isGrounded() )
        {
            
            //Debug.Log("1");
            if (runCouroutine)
            {
                //Debug.Log("2");
                StartCoroutine(pauseJump());
               
            }

        }


        bool isGrounded()
        {
            Vector2 positoin = transform.position;
            Vector2 direction = Vector2.down;
            float distance;

            distance = .5f;

            RaycastHit2D gDet = Physics2D.Raycast(positoin, direction, distance, ground);
            if (gDet.collider != null)
            {
                return true;
            }
            return false;
        }

        IEnumerator pauseJump()
        {
            Debug.Log("jumping");
            runCouroutine = false;
            StartCoroutine(sprite());
            yield return new WaitForSeconds(1.5f);
            runCouroutine = false;
            adjustedForce = 4f;
            
            jump = true;
            yield return new WaitForSeconds(.8f);
            gameObject.GetComponent<SpriteRenderer>().sprite = normal;
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, facing.y, facing.z);

            yield return new WaitForSeconds(1.5f);
            runCouroutine = true;
         
            

        }
        IEnumerator sprite()
        {
            yield return new WaitForSeconds(1.5f);
            gameObject.GetComponent<SpriteRenderer>().sprite = midJump;
            yield return new WaitForSeconds(.7f);
            gameObject.GetComponent<SpriteRenderer>().sprite = landing;
           
        }

    }
}
