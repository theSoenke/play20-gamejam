using UnityEngine;

public class PissYourselfAction : ActionDescription
{
    //public float SusValue = 50f;
    public Amounts SusValue;

    //public float MinPeeLevel = 30;
    public float PeeMaxLevelFactor = 0.9f;
    public float PeeProbabilityFactor = 0.15f;

    public override string Description(GameState state)
    {
        return "I don't think I can hold this any longer";
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside)        
            return 0;

        //return Mathf.RoundToInt(state.PeeLevel * PeeLevelFactor);
        var peeLevel = GameStateManager.Instance.Balancing.PeeMax * PeeMaxLevelFactor;
        return ProbabilityHelper.CalcWithMinimum(state.PeeLevel, peeLevel, peeLevel + 20, GameStateManager.Instance.Balancing.ProbabilityMax * PeeProbabilityFactor);
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(GameStateManager.Instance.Balancing[SusValue]);
        state.PissReset(true);
    }
}
