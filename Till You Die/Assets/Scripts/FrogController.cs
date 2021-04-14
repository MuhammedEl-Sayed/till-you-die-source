using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    //Jumping Variables
    Rigidbody2D frogRB;
    public float jumpForce;
    float adjustedForce;    
    float oldjumpForce;
    GameObject MousePosSC;
    public GameObject OverLay;

    bool left = false;
    bool right = false;
    bool jump = false;
    bool prepJump = false;

    bool runCouroutine = true;
    bool bufferRunning = false;

    public Animator anim;
    public static bool freeze = false;
    private bool beetleCo = true;
    public Sprite fourLegs;
    private static bool fourL = false;
    private bool dead = false;
    private bool shittyFix = false;
    Vector3 facing;

    public Sprite jumping;
    public Sprite normal;
    private int jumpCounter = 40;
    private bool runDeath = true;
    private bool runIdle = true;
    //Ground Detection Variables
    public LayerMask ground;
    public Transform checkPos;
    public GameObject GameMaster;
    public bool startPart = false;
    public bool runPart = true;

    //Move Camera
    public static bool[] partArray = new bool[21];

    public GameObject part;


    private void Awake()
    {
        MousePosSC = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
      
       
        frogRB = GetComponent<Rigidbody2D>();
        oldjumpForce = jumpForce;
        anim.SetBool("leap", false);
        facing = transform.localScale;
      
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, new Vector3(0, -1, 0).normalized);
        Gizmos.DrawRay(new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z), new Vector3(0, -1, 0).normalized);
        Gizmos.DrawRay(new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z), new Vector3(0, -1, 0).normalized);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            fourL = false;
            GameMaster.GetComponent<isTongueOpen>().ResetTongue();

            anim.SetBool("twoLegs", true);
            jumpCounter = 40;
        }
        if (collision.gameObject.CompareTag("FlatWorm"))
        {
            Debug.Log("Collide with flat worm");
            shittyFix = true;
        }
        if (collision.gameObject.CompareTag("PartOne"))
        {
            //set part one = true, part arry index 0;
            //set everything = false index 1- 19
            partArray[0] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 0) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("PartTwo"))
        {
            //set part two = true, partarray index 1;
            partArray[1] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 1) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("PartThree"))
        {
            //set part three = true partarray index 2
            partArray[2] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 2) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("PartFour"))
        {
            partArray[3] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 3) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("PartFive"))
        {

            partArray[4] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 4) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("PartSix"))
        {
            partArray[5] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 5) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("PartSeven"))
        {
            partArray[6] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 6) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("PartEight"))
        {
            partArray[7] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 7) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("Part9"))
        {
            partArray[8] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 8) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("Part10"))
        {
            partArray[9] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 9) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part11"))
        {
            partArray[10] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 10) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part12"))
        {
            partArray[11] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 11) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("Part13"))
        {
            partArray[12] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 12) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part14"))
        {
            partArray[13] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 13) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("Part15"))
        {
            partArray[14] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 14) { partArray[i] = false; }
            }
        }
        if (collision.gameObject.CompareTag("Part16"))
        {
            partArray[15] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 15) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part17"))
        {

            partArray[16] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 16) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part18"))
        {
            partArray[17] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 17) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part19"))
        {
            partArray[18] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 18) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part20"))
        {
            partArray[19] = true;
            for (int i = 0; i < 20; i++)
            {
                if (i != 19) { partArray[i] = false; }
            }

        }
        if (collision.gameObject.CompareTag("Part19a"))
        {

            partArray[17] = false;
            partArray[18] = false;
            partArray[21] = true;
        }
    }

    void FixedUpdate()
    {

        if (jump && !freeze)
        {
            if (jumpForce > 10)
            {
                jumpForce = 10f;
            }

            float r = Mathf.Pow(((jumpForce / 4f) - 1.2f), 2) + 5;

            float l = -(Mathf.Pow(((jumpForce / 4) - 1.2f), 2) + 5);
            if(adjustedForce > 25)
            {
                adjustedForce = 25;
            }
            if (fourL)
            {
                r = r * 1.4f;
                l = l * 1.4f;
                adjustedForce = adjustedForce*1.5f;
            }
            if (left)
            {
                 
                frogRB.velocity = new Vector2(l, adjustedForce);

            }
            if (right)
            {
                frogRB.velocity = new Vector2(r, adjustedForce);
            }
            if (!left && !right)
            {
                frogRB.velocity = new Vector3(0, jumpForce, 0);
            }
            Debug.Log(adjustedForce);
            jumpForce = oldjumpForce;
            runCouroutine = true;
            if (fourL)
            {
                jumpCounter--;
            }
            bufferRunning = true;
            jump = false;

        }
    }

    void Update()
    {

        if(frogRB.velocity == new Vector2(0, 0) && runIdle)
        {
            StartCoroutine(idleAnim());
        }
        if (jumpCounter <= 0)
        {
            GameMaster.GetComponent<isTongueOpen>().ResetTongue();
            dead = true;
        }

        if (DamageBehavior.freeze || shittyFix)
        {
            shittyFix = false;
            beetleCo = true;
            Debug.Log("beetleCo");
            if (beetleCo)
            {
                StartCoroutine(beetleSprite());
            }
            
            freeze = true;
        }

        //Checks to see if there are more than one collider in a specific circle, located near the bottom of the player 
        if (landingCheck())
        {
            if (!isGrounded() && !isGroundedleft() && !isGroundedright())
            {
                if (fourL)
                {
                    anim.SetBool("fLand", false);
                }
                else
                {
                    anim.SetBool("land", false);
                }
                
            }
            else
            {
                if (fourL)
                {
                    anim.SetBool("fMidJump", false);
                }
                else
                {
                    anim.SetBool("midJump", false);
                }
                
            }


        }
        if (isGrounded())
        {
            if (startPart && runPart)
            {
                StartCoroutine(spawnPart());
               
                startPart = false;
            }
        }
        if (isGrounded() || isGroundedleft() || isGroundedright())
        {


            if (fourL)
            {

                anim.SetBool("fMidJump", false);
            }
            else
            {
                anim.SetBool("midJump", false);
            }




            Debug.Log("ASd0");
            if (runCouroutine && Input.GetKey("space"))
            {
                jumpForce += 5f * Time.deltaTime;
                CalcJump();
                bufferRunning = false;
                prepJump = true;

            }
            if (!bufferRunning)
            {
                StartCoroutine(bufferLR());
            }
            if (Input.GetKeyUp("space"))
            {
                Debug.Log("jumping");
                anim.SetBool("fNormal", false);
                jump = true;

            }
            if (!Input.GetKey("space"))
            {
                prepJump = false;
            }

        }
        if (!isGrounded() && !isGroundedleft() && !isGroundedright())
        {
            if (fourL)
            {
                anim.SetBool("fNormal", false);
                anim.SetBool("fMidJump", true);
            }
            else
            {
                anim.SetBool("midJump", true);
            }
            if (landingCheck())
            {
                if (fourL)
                {
                    anim.SetBool("fMidJump", false);
                }
                else
                {
                    anim.SetBool("midJump", false);
                }
            }
            if (!landingCheck())
            {
                startPart = true;
            }
            Debug.Log("Landing");
            prepJump = true;

        }

        Movement();
        Dead();
    }

    void Dead()
    {
        if (dead&& runDeath)
        {
            StartCoroutine(Death());
            freeze = true;
            frogRB.velocity = new Vector3(0, 7, 0);

        }
    }
    void CalcJump()
    {
        //
        adjustedForce = Mathf.Pow(((jumpForce / 2) - 2.5f), 2) + 5;
       /* if (adjustedForce >= 5)
        {
            adjustedForce = ((jumpForce / 1.6f) * (Mathf.Log10(jumpForce / 6f))) + 5.6f;
        }*/
    }
    void Movement()
    {
        Vector2 moveLeft = new Vector2(-6f, 0f);
        Vector2 moveRight = new Vector2(6f, 0f);
        if (!prepJump && !freeze && !dead)
        {
            float move = 6f;
            if (fourL)
            {
                move = 1.5f * move;
            }
            else
            {
                move = 6f;
            }
            if (Input.GetKey("a") && !Input.GetKey("d"))
            {
                anim.SetBool("idle", false);
                anim.SetBool("fIdle", false);
                anim.SetBool("fNormal", false);
                if (fourL)
                {
                    anim.SetBool("fLeap", true);
                    
                }
                else
                {
                    anim.SetBool("leap", true);
                    
                }
                
                gameObject.transform.Translate(new Vector3(-move, 0, 0) * Time.deltaTime, Space.World);
                transform.localScale = new Vector3(-facing.x, facing.y, facing.z);
                MousePosSC.GetComponent<getMousePosition>().SetFacingLeft();
            }

            else if (Input.GetKey("d") && !Input.GetKey("a"))
            {
                anim.SetBool("idle", false);
                anim.SetBool("fIdle", false);
                anim.SetBool("fNormal", false);
                if (fourL)
                {
                    anim.SetBool("fLeap", true);
                }
                else
                {
                    anim.SetBool("leap", true);
                }
                Debug.Log("d");
                gameObject.transform.Translate(new Vector3(move, 0, 0) * Time.deltaTime, Space.World);
                transform.localScale = new Vector3(facing.x, facing.y, facing.z);
                MousePosSC.GetComponent<getMousePosition>().SetFacingRight();
            }
            else
            {
                if (fourL)
                {
                    anim.SetBool("fLeap", false);
                    anim.SetBool("fNormal", true);
                }
                else
                {
                    anim.SetBool("fNormal", false);
                    anim.SetBool("leap", false);
                }
               
            }
        }
        else
        {
            if (fourL)
            {
                anim.SetBool("fLeap", false);
            }
            else
            {
                anim.SetBool("leap", false);
            }
        }
    }
    bool isGrounded()
    {
        Vector2 positoin = transform.position;
        Vector2 direction = Vector2.down;
        float distance;

        distance = .7f;

        RaycastHit2D gDet = Physics2D.Raycast(positoin, direction, distance, ground);
        if (gDet.collider != null)
        {
            return true;
        }
        return false;
    }
    bool isGroundedleft()
    {
        Vector2 positoin = new Vector2(transform.position.x - 0.7f, transform.position.y);
        Vector2 direction = Vector2.down;
        float distance;

        distance = .7f;

        RaycastHit2D gDet = Physics2D.Raycast(positoin, direction, distance, ground);
        if (gDet.collider != null)
        {
            return true;
        }
        return false;
    }
    bool isGroundedright()
    {
        Vector2 positoin = new Vector2(transform.position.x + 0.7f, transform.position.y);
        Vector2 direction = Vector2.down;
        float distance;

        distance = .7f;

        RaycastHit2D gDet = Physics2D.Raycast(positoin, direction, distance, ground);
        if (gDet.collider != null)
        {
            return true;
        }
        return false;
    }

    bool landingCheck()
    {
        Vector2 positoin = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = Vector2.down;
        float distance;

        distance = 1f;

        RaycastHit2D gDet = Physics2D.Raycast(positoin, direction, distance, ground);
        if (gDet.collider != null)
        {
            return true;
        }
        return false;
    }

    IEnumerator idleAnim()
    {
        int random = Random.Range(1, 10);
        runIdle = false;
        yield return new WaitForSeconds(1f);
        if(random < 4)
        {
            if (fourL)
            {
                anim.SetBool("fIdle", true);
            }
            else
            {
                anim.SetBool("idle", true);
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fIdle") || anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                anim.SetBool("idle", false); 
                anim.SetBool("fIdle", false);
            }
        }

        yield return new WaitForSeconds(2f);
        runIdle = true;
        
    }
    public IEnumerator Death()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<getMousePosition>().PlayerInput(false);
        runDeath = false;
        yield return new WaitForSeconds(0.6f);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        anim.SetBool("dead", true);
        frogRB.constraints = RigidbodyConstraints2D.FreezePositionX;
        frogRB.constraints = RigidbodyConstraints2D.FreezePositionY;
        OverLay.SetActive(true);
    }

    IEnumerator bufferLR()
    {


        while (Input.GetKey("a"))
        {
            left = true;
            right = false;
           // Debug.Log(left + "Left");
            yield return new WaitForSeconds(0.5f);


        }
        while (Input.GetKey("d"))
        {
            left = false;
            right = true;
          //  Debug.Log(right + "right");
            yield return new WaitForSeconds(0.5f);


        }
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            yield return new WaitForSeconds(0.5f);
            left = false;
            right = false;

        }

    }
    IEnumerator beetleSprite()
    {

            beetleCo = false;
            for(int i = 0; i < 20; i++)
            {
                GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                yield return new WaitForSeconds(0.1f);
                
            }
              GetComponent<SpriteRenderer>().color = Color.white;
             Debug.Log("beetle");
            anim.SetBool("fNormal", true);
            freeze = false;
            fourL = true;
       

        
    }
    IEnumerator spawnPart()
    {
        runPart = false;
        GameObject particle = Instantiate(part, transform) as GameObject;

        particle.GetComponent<ParticleSystem>().loop = false;
        particle.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(particle);
        runPart = true;

    }
}
