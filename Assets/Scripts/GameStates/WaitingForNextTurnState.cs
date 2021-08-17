using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

class WaitingForNextTurnState : GameStateAbstract
{
    private Rigidbody cueBall;
    private List<Rigidbody> balls;
    private GameController gameController;
    public WaitingForNextTurnState(GameController parent) : base(parent)
    {
        gameController = parent;
        cueBall = parent.CueBall;
        balls = parent.balls;

        cueBall.GetComponent<BallLogic>().BallPocketedAction += BallPocketed;
        foreach (var ball in balls)
        {
            ball.GetComponent<BallLogic>().BallPocketedAction += BallPocketed;
        }
    }

    public override void FixedUpdate()
    {
        if (cueBall.IsSleeping())
        {
            if (balls.All(x => x.IsSleeping()))
            {
                gameController.gameState = new AimingState(gameController);
            }
        }
    }

    private void BallPocketed(BallLogic ballLogic)
    {
        balls.Remove(ballLogic.GetComponent<Rigidbody>());
        if (balls.Count < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (ballLogic.IsCueBall)
        {
            cueBall.Sleep();
            cueBall.position = gameController.CueBallStartPos;
        }
    }
}
