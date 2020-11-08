using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceArrived : ActionDescription
{

    //public float SuspicionThreshold = 100f;
    public float SusFactor = 1f;

    public override string Description(GameState state)
    {
        return RandomString.Select("Shit... Cops", "The cops are here", "They gonna arrest me!");
    }

    public override int EvaluateProbability(GameState state)
    {
        var value = Mathf.Max(0, state.Sus - GameStateManager.Instance.Balancing.SusMax) * 2 * SusFactor;
        return Mathf.RoundToInt(value);
    }

    public override void Execute(GameState state)
    {
        state.GameOver();
    }
}