using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkIn : ActionDescription
{
    public float SusValue = 0f;

      public override string Description(GameState state)
    {
        return "Hi, i am Invitet by Marry.";
    }

    public override int EvaluateProbability(GameState state)
    {
       

        return 100;
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SusValue);

    }   
}
