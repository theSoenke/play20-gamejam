using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToGuestAction : ActionDescription
{
    public Amounts SusValue;
    public Amounts DrinkValue;
    public float PropabilityFactor = 0.025f;
    public float AddSusProbability = 10;

    public override string Description(GameState state)
    {
        if (state.Drunk < 20)
        {
            return RandomString.Select("I should ask them about the weather.", "Wow, nice party!", "Your shirt look nice!");
        }
        else if (state.Drunk < 40)
        {
            return RandomString.Select("Wow you look great!", "Hey, you, nice shirt!", "Do you heart about the tragedy of darth Plagueis?");
        }
        else
        {
            return RandomString.Select("Hey!", "Heeeeeyyyy", "Jo Bro!", "Whazzzzz uuuuupppp");
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
        if(state.Drunk < 40)
        {
            state.SusAdd(-GameStateManager.Instance.Balancing[SusValue]);
        } 
        else
        {
            if(Random.Range(0, AddSusProbability) == 0)
            {
                state.SusAdd(GameStateManager.Instance.Balancing[SusValue] * 1.5f);
            }
            else
            {
                state.SusAdd(-GameStateManager.Instance.Balancing[SusValue] * 0.5f);
            }
        }
        //if (state.Drunk < 40 && state.Sus > 15 && state.Sus < 60)
        //{
        //    state.SusAdd(-GameStateManager.Instance.Balancing[SusValue]);
        //}
        //else if (state.Drunk >= 40)
        //{
        //    state.SusAdd(GameStateManager.Instance.Balancing[SusValue]);
        //}
        //if (state.Drunk > 20)
        //{
        //    state.SoberUp(GameStateManager.Instance.Balancing[DrinkValue], GameStateManager.Instance.Balancing[DrinkValue] * 0.5f);
        //}
    }
}
