public class DrinkAction : ActionDescription
{
    public float DrinkStrengthValue = 2f;
    public float DrinkVolumeValue = 4f;
    public float SusMaxValue = 2f;

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
        return 10;
    }

    public override void Execute(GameState state)
    {
        state.Drink(DrinkStrengthValue, DrinkVolumeValue);
        state.SusAdd(SusMaxValue * ((state.Sus + SusMaxValue) / 100));
    }

    public override string Description(GameState state)
    {
        string[] responses = { "Oh, look at this nice piece of alcohol!", "Do I see a beer over there?", "Let's grab a cool one!", "I could use some beer" };
        int selection = UnityEngine.Random.Range(0, responses.Length);
        return responses[selection];
    }
}
