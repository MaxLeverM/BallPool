using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] private int _ballNumber = 0;
    public int ballNumber { get => _ballNumber; }
    [SerializeField] private float sleepThreshold = 0.01f;
    [SerializeField] private float maxAngularVelocity = 25f;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.sleepThreshold = sleepThreshold;
        rig.maxAngularVelocity = maxAngularVelocity;
    }

   /* private Vector3 _velocity;
    void FixedUpdate()
    {
        if (rig.velocity.y > 0)
        {
            _velocity = rig.velocity;
            _velocity.y *= 0.3f;
            rig.velocity = _velocity;
        }
    }*/
}
