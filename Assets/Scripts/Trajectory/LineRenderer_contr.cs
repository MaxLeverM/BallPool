using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderer_contr : MonoBehaviour, IVisible
{
    private LineRenderer lineRenderer;
    private Vector3[] _points;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetupLine(Vector3[] points)
    {
        lineRenderer.positionCount = points.Length;
        _points = points;
        for (int i = 0; i < _points.Length; i++)
        {
            lineRenderer.SetPosition(i, _points[i]);
        }
    }

    public void SetVisible(bool visible)
    {
        lineRenderer.enabled = visible;
    }
}
