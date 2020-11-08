using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkIn : ActionDescription
{
    public float SusValue = 0f;

    public override string Description(GameState state)
    {
        return RandomString.Select("Hi, Marry invited me.", "I am the +1 from Karen", "Sure, i am invited");
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
