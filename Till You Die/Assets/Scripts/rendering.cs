using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rendering : MonoBehaviour
{
    public SpringJoint2D rope;
    public LineRenderer render;
    public GameObject player;
    public GameObject startPosition;
    private void Awake()
    {
        render = player.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        rope = player.GetComponent<SpringJoint2D>();
    }

    private void LateUpdate()
    {
        if (rope != null)
        {
            render.enabled = true;
            render.positionCount = 2;
            render.SetPosition(0, startPosition.transform.position);
            render.SetPosition(1, rope.connectedAnchor);
        }
        else
        {
            render.enabled = false;
        }

    }
}
