using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cueSprite;
    public void LookAtPosition(Vector3 position)
    {
        transform.LookAt(position);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetVisible(bool visible)
    {
        cueSprite.enabled = visible;
    }
}
