using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeAction : ActionDescription
{
    public float SusValue = 10f;
    public float DrunkValue = 2f;

    public override string Description()
    {
        return "I feel sick, i think i must throw up..";
    }

    public override int EvaluateProbability(GameState state)
    {
        if(state.Drunk > 60)
        {
            return Mathf.RoundToInt((state.Drunk-60f) / 40.0f * 500);
        }

        return 0;
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SusValue);
        state.Drink(-DrunkValue);

    }   
}
