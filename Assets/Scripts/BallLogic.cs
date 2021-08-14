using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    private Rigidbody rig;
    public float sleepThreshold = 0.01f;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.sleepThreshold = sleepThreshold;
    }

    private Vector3 _velocity;
    void FixedUpdate()
    {
        if (rig.velocity.y > 0)
        {
            _velocity = rig.velocity;
            _velocity.y *= 0.3f;
            rig.velocity = _velocity;
        }
    }
}
