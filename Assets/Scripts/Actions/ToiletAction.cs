using UnityEngine;

public class ToiletAction: ActionDescription
{
    //public float SusValue = 10f;
    public Amounts SusValue;

    public float PeeLevelFactor = 1f;

    private void Awake()
    {
        //If(!Animation) AN = null;
    }

    public override int EvaluateProbability(GameState state)
    {
        if (!state.IsInside)
        {
            return 0;
        }
        return Mathf.RoundToInt(state.PeeLevel * 2 * PeeLevelFactor);
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(GameStateManager.Instance.Balancing[SusValue]);   
        state.PissReset();  
    }

    public override string Description(GameState state)
    {
        if (state.PeeLevel > 30)
        {
            return "Oh, I have to take a piss so badly..";
        }

        return "I better get to the toilet soon";
    }
}
