﻿using UnityEngine;

public class PukeToiletAction : ActionDescription
{
    //public float SusValue = 10f;
    //public float DrunkValue = 2f;

    public Amounts SusValue;
    public Amounts DrunkValue;
    public Amounts SicknessValue;

    public float PukeThreshold = 75;
    public float PukeFactor = 1f;

    public override string Description(GameState state)
    {
        if (state.Drunk < 75)
        {
            return "I feel sick, I think I have to throw up..";
        }
        else
        {
            return "BBBLLLAAARRGGGHHH!!!";
        }
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside)
        {
            return 0;
        }

        var value = Mathf.Max(0, state.Sickness - PukeThreshold) * 2 * PukeFactor;
        return Mathf.RoundToInt(value);
    }

    public override void Execute(GameState state)
    {
        state.Puke();
        state.SusAdd(GameStateManager.Instance.Balancing[SusValue]);
        state.SoberUp(GameStateManager.Instance.Balancing[SicknessValue] * 2, GameStateManager.Instance.Balancing[DrunkValue] * 0.5f);
    }
}
