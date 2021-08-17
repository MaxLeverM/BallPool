using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsTrajectory : MonoBehaviour,IVisible
{
    [SerializeField] private LineRenderer_contr cueBallLineBeforeCol;
    [SerializeField] private LineRenderer_contr cueBallLineAfterCol;
    [SerializeField] private LineRenderer_contr ballLineAfterCol;
    [SerializeField] private TrajectoryCircle ballCircle;
    [SerializeField] private float lengthAfterColLine = 0.5f;

    private Vector3 centerBallCollision;
    private RaycastHit _hit;

    public void Start()
    {
        SetVisible(false);
    }
    public void UpdateTrajectory(Transform cueBall, Vector3 direction, float lengthMultiplier = 1f)
    {
        float cueBallRadius = cueBall.localScale.y / 2f;
        if (Physics.SphereCast(cueBall.position, cueBallRadius, direction, out _hit, 5f))
        {
            centerBallCollision = PointByDirectionNDistance(cueBall.position, direction, _hit.distance);
            float angle = Vector3.SignedAngle(direction, (_hit.collider.transform.position - centerBallCollision).normalized, Vector3.up);
            cueBallLineBeforeCol.SetupLine(new Vector3[] { cueBall.position, centerBallCollision });
            ballCircle.Position = centerBallCollision;
            if (_hit.collider.tag == "Ball")
            {
                cueBallLineAfterCol.SetVisible(true);
                ballLineAfterCol.SetVisible(true);
                DrawCueBallAfterColLine(lengthMultiplier, angle);
                DrawBallAfterColLine(lengthMultiplier, angle);
            }
            else
            {
                cueBallLineAfterCol.SetVisible(false);
                ballLineAfterCol.SetVisible(false);
            }
        }
    }

    private void DrawCueBallAfterColLine(float lengthMultiplier, float angle)
    {
        float lengthByAngle = (90 - Mathf.Abs(angle)) / 90;
        Vector3 direction = _hit.collider.transform.position - centerBallCollision;
        Vector3 secondPos = PointByDirectionNDistance(_hit.collider.transform.position, direction, lengthAfterColLine * lengthMultiplier * lengthByAngle);
        ballLineAfterCol.SetupLine(new Vector3[] { _hit.collider.transform.position, secondPos });
    }
    private void DrawBallAfterColLine(float lengthMultiplier, float angle)
    {
        float lengthByAngle = Mathf.Abs(angle) / 90;
        Vector3 direction = Quaternion.Euler(0, angle < 0 ? 90 : -90, 0) * (_hit.collider.transform.position - centerBallCollision);
        Vector3 secondPos = PointByDirectionNDistance(centerBallCollision, direction, lengthAfterColLine * lengthMultiplier * lengthByAngle);
        cueBallLineAfterCol.SetupLine(new Vector3[] { centerBallCollision, secondPos });
    }

    public static Vector3 PointByDirectionNDistance(Vector3 origin, Vector3 directionCast, float hitInfoDistance)
    {
        return origin + (directionCast.normalized * hitInfoDistance);
    }
    public static float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n)
    {
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));

        float signed_angle = angle * sign;

        return signed_angle;
    }

    public void SetVisible(bool visible)
    {
        cueBallLineBeforeCol.SetVisible(visible);
        cueBallLineAfterCol.SetVisible(visible);
        ballLineAfterCol.SetVisible(visible);
        ballCircle.SetVisible(visible);
    }
}
