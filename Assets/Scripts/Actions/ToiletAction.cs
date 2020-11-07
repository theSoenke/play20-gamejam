public class ToiletAction: ActionDescription
{
    public float SusValue = 10f;

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
        state.SusAdd(SusValue);   
        state.PissReset();  
    }

    public override string Description(GameState state)
    {
        if(state.Drunk == 0)
        {
            return "I better get to the toilet soon";
        } 
        else
        {
            return "Oh, I have to take a piss so badly..";
        }
    }
}
