using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceArrived : ActionDescription
{
    public float SusValue = 10f;
    //public float DrunkThreshold = 100f;
    public float DrunkFactor = 1f;


    public override string Description(GameState state)
    {
        return "I am Okkeeee, faaaaaccccckkk uffff";
    }

    public override int EvaluateProbability(GameState state)
    {
        var value = Mathf.Max(0, state.Drunk - GameStateManager.Instance.Balancing.DrunkMax) * 2 * DrunkFactor;
        return Mathf.RoundToInt(value);
    }

    public override void Execute(GameState state)
    {
        state.GameOver(false);
    }   
}