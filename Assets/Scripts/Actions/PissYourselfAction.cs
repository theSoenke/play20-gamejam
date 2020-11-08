﻿using UnityEngine;

public class PissYourselfAction : ActionDescription
{
    //public float SusValue = 50f;
    public Amounts SusValue;

    public float MinPeeLevel = 30;
    //public float PeeLevelFactor = 0.5f;

    public override string Description(GameState state)
    {
        return "I don't think I can hold this any longer";
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside)        
            return 0;

        //return Mathf.RoundToInt(state.PeeLevel * PeeLevelFactor);
        return ProbabilityHelper.CalcWithMinimum(state.PeeLevel, MinPeeLevel, MinPeeLevel + 20, GameStateManager.Instance.Balancing.ProbabilityMax * 0.75f);
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(GameStateManager.Instance.Balancing[SusValue]);
        state.PissReset(true);
    }
}
