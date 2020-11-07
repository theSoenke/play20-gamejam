public class ToiletAction: ActionDescription
{
    public float SusValue = 10f;

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
