using UnityEngine;

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
        "Oh, look what we've got there. Is this a drink?",
        "Do I see a beer over there?",
        "Let's grab a cool one!",
        "I could use some beer",
        "Omg, is that a Corona?",
        "Blää that's a alcohol free one?"
        
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
        return Mathf.RoundToInt(GameStateManager.Instance.Balancing.ProbabilityMax / 100f);
    }

    public override void Execute(GameState state)
    {
        state.Drink(GameStateManager.Instance.Balancing[DrinkStrength], GameStateManager.Instance.Balancing[DrinkVolume]);
        state.SusAdd(GameStateManager.Instance.Balancing[SusValue] * ((state.Sus + GameStateManager.Instance.Balancing[SusValue]) / 100));
    }

    public override string Description(GameState state)
    {
        return RandomString.Select(Descriptions);
    }
}
