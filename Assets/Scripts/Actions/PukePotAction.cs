using UnityEngine;

public class PukePotAction : ActionDescription
{
    public float SusValue = 10f;
    public float DrunkValue = 2f;
    public float PukeThreshold = 75;
    public float PukeFactor = 1f;

    public override string Description(GameState state)
    {
        if (state.Drunk < 75)
        {
            return "I feel sick, where is this toilet..";
        }
        else
        {
            return "...";
        }
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside)
        {
            return 0;
        }

        var value = Mathf.Max(0, state.Sus - PukeThreshold) * 2 * PukeFactor;
        return Mathf.RoundToInt(value);
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SusValue);
        state.Drink(-DrunkValue, -DrunkValue);
    }   
}

