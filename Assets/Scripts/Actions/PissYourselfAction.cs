using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissYourselfAction : ActionDescription 
{
    //public float SusValue = 50f;
    public Amounts SusValue;

    public float MinPeeLevel = 50;
    public float PeeLevelFactor = 0.5f;

    public override string Description(GameState state)
    {
        return "Piss yourself.";
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside || state.PeeLevel < MinPeeLevel)
        {
            return 0;
        }
        return Mathf.RoundToInt(state.PeeLevel * PeeLevelFactor);
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(GameStateManager.Instance.Balancing[SusValue]);
        state.PissReset(true);
    }    
}
