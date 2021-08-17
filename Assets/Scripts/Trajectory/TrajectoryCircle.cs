using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryCircle : MonoBehaviour, IVisible
{
    public SpriteRenderer circleSprite;

    private void Awake()
    {
        circleSprite = GetComponent<SpriteRenderer>();
    }
    public Vector3 Position { get => transform.position; set => transform.position = value; }

    public void SetVisible(bool visible)
    {
        circleSprite.enabled = visible;
    }
}
