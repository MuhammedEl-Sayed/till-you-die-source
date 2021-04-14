using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMousePosition : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    private bool facing = true;
    //true right
    //false left

    public float bulletSpeed = 60.0f;
    private bool setPlayerInput = false;
    private Vector3 target;
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0) && setPlayerInput == true)
        {
            if (target.x < player.transform.position.x && facing == true && player.transform.localScale.x > 0)
            {
                player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
                facing = false;

            }
            else if (target.x > player.transform.position.x && facing == false && player.transform.localScale.x < 0)
            {
                player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
                facing = true;

            }
            if (player.GetComponent<SpringJoint2D>() == null)
            {
                Physics2D.IgnoreLayerCollision(10, 9, true);
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                fireBullet(direction, rotationZ);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(player.GetComponent<SpringJoint2D>());
            GameObject.FindGameObjectWithTag("Player").GetComponent<coolDownTimer>().resetuse();
        }

    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    public void SetFacingLeft()
    {
        facing = false;
    }

    public void SetFacingRight()
    {
        facing = true;
    }

    public void PlayerInput(bool state)
    {
        setPlayerInput = state;
    }

}
