using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoThrowWindow : ActionDescription
{
    public float SusValue = 10f;

     public override string Description(GameState state)
    {
        return "I need to get in there, oh look a window..";
    }

    public override int EvaluateProbability(GameState state)
    {
        return state.IsInside?0:1;
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SusValue);
        state.GoInside();
    }   
}
