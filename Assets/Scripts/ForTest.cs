using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTest : MonoBehaviour
{
    public Rigidbody ball;
    public Vector3 forceDirection;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ball.AddForce(forceDirection);
        }
    }
}
