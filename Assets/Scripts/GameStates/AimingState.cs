using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class AimingState : GameStateAbstract
{
    private Rigidbody cueBall;
    private List<Rigidbody> balls;
    private Cue cue;
    private BallsTrajectory trajectory;
    private Vector3 _hitDirection;
    private GameController gameController;
    private Slider hitSlider;
    private const float MIN_HIT_SLIDER_VALUE = 0.01f;
    public AimingState(GameController parent) : base(parent)
    {
        cueBall = parent.CueBall;
        cue = parent.Cue;
        trajectory = parent.trajectory;
        gameController = parent;
        balls = parent.balls;

        FindBallToHit();
        trajectory.SetVisible(true);
        cue.SetPosition(cueBall.position);
        cue.SetVisible(true);

        hitSlider = gameController.hitSlider.GetComponent<Slider>();
        hitSlider.interactable = true;

        gameController.inputController.OnDragAction += ChangeHitDirection;
        gameController.hitSlider.OnEndDragAction += HitSliderDragEnd;
    }

    private void HitSliderDragEnd(PointerEventData obj)
    {
        if (hitSlider.value > MIN_HIT_SLIDER_VALUE)
        {
            CueHit(_hitDirection, Mathf.Lerp(gameController.minHitForce, gameController.maxHitForce, hitSlider.value));
            hitSlider.interactable = false;
        }
        hitSlider.value = 0;
    }

    private void ChangeHitDirection(Vector2 touchPos)
    {
        var pos = Camera.main.ScreenToWorldPoint(touchPos);
        pos.y = cueBall.position.y;
        _hitDirection = (cueBall.position - pos).normalized;
        UpdateCueAndTrajectoryDir(_hitDirection);
    }

    private void FindBallToHit()
    {
        float minDistance = float.MaxValue;
        Vector3 ballPos = Vector3.right;
        foreach (var ball in balls)
        {
            if (ball != cueBall)
            {
                float curDist = Vector3.Distance(cueBall.position, ball.position);
                if (curDist < minDistance)
                {
                    minDistance = curDist;
                    ballPos = ball.position;
                }
            }
        }
        _hitDirection = (ballPos - cueBall.position).normalized;
        UpdateCueAndTrajectoryDir(_hitDirection);
    }

    private void UpdateCueAndTrajectoryDir(Vector3 direction)
    {
        cue.SetRotation(direction);
        trajectory.UpdateTrajectory(cueBall.transform, direction);
    }

    private void CueHit(Vector3 direction, float force, Vector3 torque = default)
    {
        cueBall.AddForce(direction * force, ForceMode.Impulse);
        if (torque != default)
        {
            cueBall.AddTorque(torque);
        }
        trajectory.SetVisible(false);
        cue.SetVisible(false);
        gameController.inputController.OnDragAction -= ChangeHitDirection;
        gameController.hitSlider.OnEndDragAction -= HitSliderDragEnd;
        gameController.gameState = new WaitingForNextTurnState(gameController);
    }
}
