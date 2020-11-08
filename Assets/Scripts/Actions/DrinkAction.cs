public class DrinkAction : ActionDescription
{
    //public float DrinkStrengthValue = 2f;
    //public float DrinkVolumeValue = 4f;
    //public float SusMaxValue = 2f;

    public Amounts DrinkStrength;
    public Amounts DrinkVolume;
    public Amounts SusValue;

    public string[] Descriptions = new string[]
    {
        "Oh, look at this nice piece of alcohol!",
        "Do I see a beer over there?",
        "Let's grab a cool one!",
        "I could use some beer"
    };

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
        state.Drink(GameStateManager.Instance.Balancing[DrinkStrength], GameStateManager.Instance.Balancing[DrinkVolume]);
        state.SusAdd(GameStateManager.Instance.Balancing[SusValue] * ((state.Sus + GameStateManager.Instance.Balancing[SusValue]) / 100));
    }

    public override string Description(GameState state)
    {
        return RandomString.Select(Descriptions);
        //string[] responses = { "Oh, look at this nice piece of alcohol!", "Do I see a beer over there?", "Let's grab a cool one!", "I could use some beer" };
        //int selection = UnityEngine.Random.Range(0, responses.Length);
        //return responses[selection];
    }
}
