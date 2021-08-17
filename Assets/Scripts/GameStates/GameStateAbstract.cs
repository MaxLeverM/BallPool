using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateAbstract : IGameState
{
    protected GameController _parent;

    public GameStateAbstract(GameController parent)
    { _parent = parent; }
    public virtual void FixedUpdate() { }

    public virtual void LateUpdate() { }

    public virtual void Update() { }
}
