public class DrinkAction : ActionDescription
{
    public float DrinkValue = 2f;
    public float SusValue = 2f;

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
        return 100;
    }

    public override void Execute(GameState state)
    {
        state.Drink(DrinkValue);
        state.SusAdd(SusValue);
    }

    public override string Description(GameState state)
    {
        string[] responses = { "Oh, look at this nice piece of alcohol!", "Do I see a beer over there?" };
        System.Random random = new System.Random();
        int selection = random.Next(0, responses.Length);
        return responses[selection];
    }
}
