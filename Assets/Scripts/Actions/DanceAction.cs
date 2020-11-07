using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceAction : ActionDescription
{
    public float SuspicionValue = -5f;
    public float DrinkValue = -4f;

    public override string Description(GameState state)
    {
        if(state.Drunk < 20)
        {
            return RandomString.Select("I really want to dance right now", "Lets Dance!", "I can show them some moves");
        } 
        else if (state.Drunk < 40)
        {
            return RandomString.Select("Dance! Wohoo!", "Lets get my ass on the floor!", "I can dance way better than anyone here!");
        } 
        else
        {
            return RandomString.Select("Danceeeeeeee", "Gooooo! Danceee!!", "Dance! Dance!! Dance!!!");
        }
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside)
            return 0;

        if(state.Drunk >= 10 && state.Drunk < 30)
        {
            return Mathf.RoundToInt(30 + state.Drunk);
        }
        else if (state.Drunk > 30)
        {
            return Mathf.RoundToInt(100 + state.Drunk * 10);
        }

        return 10;
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SuspicionValue);
        state.Drink(DrinkValue, DrinkValue);
    }
}
