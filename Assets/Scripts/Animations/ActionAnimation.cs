using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionAnimation : MonoBehaviour
{
    public bool IsRunning { get; protected set; }
    public abstract void RunAnimation(GameState state);
}
