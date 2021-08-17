using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour, IVisible
{
    [SerializeField] private SpriteRenderer cueSprite;
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetVisible(bool visible)
    {
        cueSprite.enabled = visible;
    }

    public void SetRotation(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(0, Vector3.SignedAngle(direction, Vector3.forward, Vector3.down), 0);
    }
}
