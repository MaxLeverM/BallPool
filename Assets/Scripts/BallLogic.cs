using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    [SerializeField] private string ballNumber;
    [SerializeField] private float sleepThreshold = 0.01f;
    [SerializeField] private float maxAngularVelocity = 25f;
    public bool IsCueBall = false;
    private Rigidbody rig;
    public Rigidbody rigidb { get => rig; }
    private Ball _ball;
    public Ball ball { get => _ball; }
    public Action<BallLogic> BallPocketedAction;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.sleepThreshold = sleepThreshold;
        rig.maxAngularVelocity = maxAngularVelocity;
        _ball = new Ball { Number = ballNumber };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pocket")
        {
            BallPocketedAction?.Invoke(this);
            if (!IsCueBall)
            {
                Destroy(gameObject);
            }
        }
    }
}

public class Ball
{
    public string Number { get; set; }
}
