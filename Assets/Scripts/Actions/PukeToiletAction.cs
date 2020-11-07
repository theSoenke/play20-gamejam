using UnityEngine;

public class PukeToiletAction : ActionDescription
{
    public float SusValue = 10f;
    public float DrunkValue = 2f;

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

        if(state.Drunk > 60)
        {
            return Mathf.RoundToInt((state.Drunk-60f) / 40.0f * 500);
        }

        return 0;
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SusValue);
        state.Drink(-DrunkValue, -DrunkValue);
    }   
}
