using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    public static bool freeze = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            freeze = true;
        }

    }

    private void Update()
    {
        if (freeze)
        {
            StartCoroutine("kill");
        }
    }

    IEnumerator kill()
    {
        freeze = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
