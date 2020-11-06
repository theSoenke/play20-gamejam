using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkAction : ActionDescription
{
    public float DrinkValue = 2f;

    private void Awake()
    {
        //If(!Animation) AN = null;
    }

    public override int EvaluateProbability(GameState state)
    {
        return 100;
    }

    public override void Execute(GameState state)
    {
        state.Drink(DrinkValue);       
    }

    public override string Description()
    {
        return "Oh, look at this nice piece of alcohol!";
    }
}
