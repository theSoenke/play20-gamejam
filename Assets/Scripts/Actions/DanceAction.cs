using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceAction : ActionDescription
{
    //public float SuspicionValue = 5f;
    //public float DrinkValue = 2f;
    public Amounts SusValue;
    public Amounts DrinkValue;
    public float PropabilityFactor = 0.025f;

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
            return RandomString.Select("Danceeeeeeee", "Gooooo! Danceee!!", "Dance! Dance!! Dance!!!", "Shake, Shake, Shake your  booties", "Y M C A ...  ");
        }
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside)
            return 0;

        //if(state.Drunk >= 10 && state.Drunk < 30)
        //{
        //    return Mathf.RoundToInt(2 + ((state.Drunk-10) / 20) * 18);
        //}
        //else if (state.Drunk > 30)
        //{
        //    return Mathf.RoundToInt(20 + (state.Drunk - 30) / 2);
        //}

        //return 2;
        //if()
        return ProbabilityHelper.CalcWithMinimum(state.Drunk, 15, GameStateManager.Instance.Balancing.DrunkMax * 0.5f, GameStateManager.Instance.Balancing.ProbabilityMax * PropabilityFactor);
            //Mathf.RoundToInt((state.Drunk / GameStateManager.Instance.Balancing.DrunkMax) * GameStateManager.Instance.Balancing.ProbabilityMax;
    }

    public override void Execute(GameState state)
    {
        if(state.Drunk < 40 && state.Sus > 15 && state.Sus < 60)
        {
            state.SusAdd(-GameStateManager.Instance.Balancing[SusValue]);
        } 
        else if (state.Drunk >= 40)
        {
            state.SusAdd(GameStateManager.Instance.Balancing[SusValue]);
        }
        if (state.Drunk > 20)
        {
            state.SoberUp(GameStateManager.Instance.Balancing[DrinkValue], GameStateManager.Instance.Balancing[DrinkValue] * 0.5f);
        }
    }
}
