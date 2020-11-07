using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissYourselfAnimation : ActionAnimation
{

    private void Update()
    {
        if (IsRunning)
        {
            IsRunning = false;
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
    }      
}
