using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnoyAGuestAction : ActionDescription
{
    public float SusValue = 10f;

    public override string Description(GameState state)
    {
        if (state.Drunk < 0.9f)
        {
            return "Uh, what a nice ass...You are so pretty and smart";
        }
        else
        {
            return "Yoaaa wannna get crazzzy in da beeet room!!";
        }
    }

    public override int EvaluateProbability(GameState state)
    {
   
        return 0;
    }

    public override void Execute(GameState state)
    {
         if (state.Drunk < 0.9f)
        {
            // state.flirting
        }
        else
        {
           state.SusAdd(SusValue);
        }
       
   
    }   
}
