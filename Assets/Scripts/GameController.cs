using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Rigidbody CueBall;
    public List<Rigidbody> balls;
    public Cue Cue;
    public BallsTrajectory trajectory;
    public float minHitForce = 0.1f;
    public float maxHitForce = 5f;
    public IGameState gameState;
    public InputController inputController;
    public InputHandler hitSlider;
    private Vector3 cueBallStartPos;
    public Vector3 CueBallStartPos { get => cueBallStartPos; }

    void Start()
    {
        gameState = new AimingState(this);
        cueBallStartPos = CueBall.position;
    }
    private void Update()
    {
        gameState.Update();
    }
    private void FixedUpdate()
    {
        gameState.FixedUpdate();
    }
    private void LateUpdate()
    {
        gameState.LateUpdate();
    }
}
