using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform[] zones;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 20; i++)
        {
            if (FrogController.partArray[i])
            {
                gameObject.transform.position = zones[i].position;
            }
        }
        if (FrogController.partArray[20])
        {
            gameObject.transform.position = zones[20].position;
            gameObject.GetComponent<Camera>().orthographicSize = 8f;
        }
    }
}
